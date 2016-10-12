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

            PointD corner_top_left = new PointD(0.0d, 0.0d);
            PointD corner_top_right = new PointD(0.0d, 0.0d);
            PointD corner_bottom_left = new PointD(0.0d, 0.0d);
            PointD corner_bottom_right = new PointD(0.0d, 0.0d);

            //assume non clash at first
            foreach (Part a_part in configuration)
            {
                a_part.clashes = false;
            }

            foreach(Part a_part in configuration)
            {
                x1 = a_part.position_x;
                y1 = a_part.position_y;               

                foreach (Part b_part in configuration)
                {
                    x2 = b_part.position_x;
                    y2 = b_part.position_y; 

                    if(x1==x2 && y1==y2)
                    {
                        //Part can't clash with itself
                    }
                    else
                    {
                        corner_top_left = new PointD(x2,y2);
                        corner_top_right = new PointD(x2+b_part.size_x, y2);
                        corner_bottom_left = new PointD(x2, y2 - b_part.size_y);
                        corner_bottom_right = new PointD(x2 + b_part.size_x, y2 - b_part.size_y);

                        if( (corner_top_left.X - x1)<=a_part.size_x && (corner_top_left.X-x1)>=0 && (y1 - corner_top_left.Y) <= a_part.size_y && (y1 -corner_top_left.Y) >= 0)
                        {
                            a_part.clashes = true;
                            b_part.clashes = true;

                            overlap_failure += (a_part.size_x - (x2 - x1)) * (a_part.size_y - (y1 - y2));
                        }

                        if ((corner_top_right.X -x1) <= a_part.size_x && (corner_top_right.X - x1) >= 0 && (y1 - corner_top_right.Y) <= a_part.size_y && (y1 - corner_top_right.Y) >= 0)
                        {
                            a_part.clashes = true;
                            b_part.clashes = true;
                            overlap_failure += (a_part.size_x - (corner_top_right.X - x1)) * (a_part.size_y - (y1 - corner_top_right.Y));
                        }

                        if ((corner_bottom_left.X - x1) <= a_part.size_x && (corner_bottom_left.X - x1) >= 0 && (y1 - corner_bottom_left.Y) <= a_part.size_y && (y1 - corner_bottom_left.Y) >= 0)
                        {
                            a_part.clashes = true;
                            b_part.clashes = true;
                            overlap_failure +=  (a_part.size_x - (corner_bottom_left.X - x1)) * (a_part.size_y - (y1 - corner_bottom_left.Y));
                        }

                        if ((corner_bottom_right.X - x1) <= a_part.size_x && (corner_bottom_right.X - x1) >= 0 && (y1 -corner_bottom_right.Y) <= a_part.size_y && (y1 - corner_bottom_right.Y) >= 0)
                        {
                            a_part.clashes = true;
                            b_part.clashes = true;

                            overlap_failure += (a_part.size_x - (corner_bottom_right.X - x1)) * (a_part.size_y - (y1 - corner_bottom_right.Y));
                        }

                    }

                }
            }
            a_score -= overlap_failure;
            return a_score;
        }

        public void Shuffle(double scale, double panel_size_x, double panel_size_y)
        {
           foreach(Part a_part in configuration)
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
            }
        }

        public double GetRandomNumber(double minimum, double maximum)
        {
            double rand_number = random.NextDouble() * (maximum - minimum) + minimum;
            return rand_number;
        }
    }
}
