using System;
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

        public Evolution()
        {
            this.configuration = new List<Part>();
            this.score = 0.0d;
        }

        public Evolution(List<Part> given_part_list)
        {
            this.configuration = given_part_list;
            this.score = Calc_Score();
        }

        public double Calc_Score()
        {
            double a_score = 100.0d;
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

            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
