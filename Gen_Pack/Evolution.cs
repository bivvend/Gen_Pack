using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gen_Pack
{
    public class Evolution
    {
        public List<Part> configuration { get; set; }
        public double score { get; set; }
        Random random = new Random();
        public int number_of_clashes { get; set; }


        public struct PointD
        {
            public double X;
            public double Y;

            public PointD(double x, double y)
            {
                X = x;
                Y = y;
            }
            public override bool Equals(object obj)
            {
                return obj is PointD && this == (PointD)obj;
            }
            public override int GetHashCode()
            {
                return X.GetHashCode() ^ Y.GetHashCode();
            }
            public static bool operator ==(PointD a, PointD b)
            {
                return a.X == b.X && a.Y == b.Y;
            }
            public static bool operator !=(PointD a, PointD b)
            {
                return !(a == b);
            }
        }

        public Evolution()
        {
            this.configuration = new List<Part>();
            this.score = 0.0d;
        }

        public Evolution(List<Part> given_part_list, int seed)
        {
            this.configuration = given_part_list;
            this.score = Calc_Score();
            random = new Random(seed);

        }

        public double Calc_Score()
        {
            double a_score = 0.0d;
            double x1 = 0.0d;
            double y1 = 0.0d;
            double x2 = 0.0d;
            double y2 = 0.0d;

            double overlap_failure = 0.0d;

            double a_right = 0.0d;
            double a_left = 0.0d;
            double a_top = 0.0d;
            double a_bottom = 0.0d;

            double b_right = 0.0d;
            double b_left = 0.0d;
            double b_top = 0.0d;
            double b_bottom = 0.0d;

            Part a_part;
            Part b_part;

            int no_clashes = 0;

            //assume non clash at first
            foreach (Part part in configuration)
            {
                part.clashes = false;
            }

            for(int M= 0; M < configuration.Count; M++)
            {
                a_part = configuration[M];
                x1 = a_part.position_x;
                y1 = a_part.position_y;

                a_left = x1 - a_part.border_mm;
                a_right = x1 + a_part.size_x + a_part.border_mm;

                a_top = y1 + a_part.border_mm;
                a_bottom = y1 - a_part.size_y - a_part.border_mm;


                //foreach (Part b_part in configuration)
                for(int N=0; N<configuration.Count; N++)
                {
                    b_part = configuration[N];
                    x2 = b_part.position_x;
                    y2 = b_part.position_y;

                    b_left = x2 -b_part.border_mm;
                    b_right = x2 + b_part.size_x + b_part.border_mm;

                    b_top = y2 + b_part.border_mm;
                    b_bottom = y2 - b_part.size_y - b_part.border_mm;

                    if (N==M)
                    {
                        //Part can't clash with itself
                    }
                    else
                    {
                        if (a_left <= b_right && a_right >= b_left && a_top >= b_bottom && a_bottom <= b_top)
                        {
                            overlap_failure += 1000.0d;
                            a_part.clashes = true;
                            b_part.clashes = true;
                            no_clashes += 2;
                        }
                        else
                        {
                            //overlap_failure += x1 / (double)a_part.size_x + x2 / (double)b_part.size_x - y1/ (double)a_part.size_y -  y2 / (double)b_part.size_y;
                            overlap_failure += (x1 + x2 - y1 - y2)/100.0d;
                        }
                    }

                }
            }
            a_score -= overlap_failure;
            number_of_clashes = no_clashes;
            return a_score;
        }

        public void Shuffle(double scale, double panel_size_x, double panel_size_y)
        {
            double temp_size_x = 0.0d;
            double temp_size_y = 0.0d;
            foreach (Part a_part in configuration)
            {
                a_part.position_x += GetRandomNumber(-1.0d*scale,1.0d*scale);
                a_part.position_y += GetRandomNumber(-1.0d*scale, 1.0d*scale);

                if(a_part.position_x>(panel_size_x-a_part.size_x-1 -a_part.border_mm))
                {
                    a_part.position_x = panel_size_x - a_part.size_x -1 - a_part.border_mm;
                }
                if (a_part.position_x < a_part.border_mm)
                {
                    a_part.position_x = a_part.border_mm;
                }
                if (a_part.position_y > (panel_size_y-1 -a_part.border_mm))
                {
                    a_part.position_y = panel_size_y-1 -a_part.border_mm;
                }
                if (a_part.position_y < a_part.size_y +1 + a_part.border_mm)
                {
                    a_part.position_y = a_part.size_y +1 + a_part.border_mm;
                }

                //occassionally allow evolutions (10%)
                if(GetRandomNumber(0.0d,1.0d)>0.9d)
                {
                    temp_size_x = a_part.size_x;
                    temp_size_y = a_part.size_y;

                    a_part.size_x = temp_size_y;
                    a_part.size_y = temp_size_x;

                    if (a_part.position_x > (panel_size_x - a_part.size_x - 1 - a_part.border_mm))
                    {
                        a_part.position_x = panel_size_x - a_part.size_x - 1 - a_part.border_mm;
                    }
                    if (a_part.position_x < a_part.border_mm)
                    {
                        a_part.position_x = a_part.border_mm;
                    }
                    if (a_part.position_y > (panel_size_y - 1 - a_part.border_mm))
                    {
                        a_part.position_y = panel_size_y - 1 - a_part.border_mm;
                    }
                    if (a_part.position_y < a_part.size_y + 1 + a_part.border_mm)
                    {
                        a_part.position_y = a_part.size_y + 1 + a_part.border_mm;
                    }
                }
            }
        }

        public double GetRandomNumber(double minimum, double maximum)
        {
            double rand_number = random.NextDouble() * (maximum - minimum) + minimum;
            return rand_number;
        }
    }
}
