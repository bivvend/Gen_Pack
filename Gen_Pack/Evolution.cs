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


            //assume non clash at first
            foreach (Part a_part in configuration)
            {
                a_part.clashes = false;
            }

            foreach (Part a_part in configuration)
            {
                x1 = a_part.position_x;
                y1 = a_part.position_y;

                a_left = x1;
                a_right = x1 + a_part.size_x;

                a_top = y1;
                a_bottom = y1 - a_part.size_y;


                foreach (Part b_part in configuration)
                {
                    x2 = b_part.position_x;
                    y2 = b_part.position_y;

                    b_left = x2;
                    b_right = x2 + b_part.size_x;

                    b_top = y2;
                    b_bottom = y2 - b_part.size_y;

                    if (x1 == x2 && y1 == y2)
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
                        }
                        else
                        {
                            //distance bonus
                            
                            overlap_failure += Math.Abs(x2 - x1)/(a_part.size_x+ b_part.size_x) + Math.Abs(y2 - y1) / (a_part.size_x + b_part.size_x);
                            //
                        }
                    }

                }
            }
            a_score -= overlap_failure;
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

                if(a_part.position_x>(panel_size_x-a_part.size_x))
                {
                    a_part.position_x = panel_size_x - a_part.size_x;
                }
                if (a_part.position_x < 0.0d)
                {
                    a_part.position_x = 0.0d;
                }
                if (a_part.position_y > (panel_size_y))
                {
                    a_part.position_y = panel_size_y;
                }
                if (a_part.position_y < a_part.size_y)
                {
                    a_part.position_y = a_part.size_y;
                }

                //occassionally allow evolutions (10%)
                if(GetRandomNumber(0.0d,1.0d)>0.9d)
                {
                    temp_size_x = a_part.size_x;
                    temp_size_y = a_part.size_y;

                    a_part.size_x = temp_size_y;
                    a_part.size_y = temp_size_x;

                    if (a_part.position_x > (panel_size_x - a_part.size_x))
                    {
                        a_part.position_x = panel_size_x - a_part.size_x;
                    }
                    if (a_part.position_x < 0.0d)
                    {
                        a_part.position_x = 0.0d;
                    }
                    if (a_part.position_y > (panel_size_y))
                    {
                        a_part.position_y = panel_size_y;
                    }
                    if (a_part.position_y < a_part.size_y)
                    {
                        a_part.position_y = a_part.size_y;
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
