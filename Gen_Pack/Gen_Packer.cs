using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gen_Pack
{
    public class Gen_Packer
    {
        public List<Evolution> evolutions{ get; set; }
        public  List<Part> initial_part_list { get; set; }
        public  Panel panel { get; set; }
        private Random rng = new Random();
        public int Number_Of_Steps = 100;

        public Gen_Packer()
        {
            evolutions = new List<Evolution>();
            initial_part_list = new List<Part>();
            panel = new Panel();
        }

        public void Reset_Evolutions()
        {
            evolutions.Clear();
            int rnd = (int)(rng.NextDouble() * 100000);
            evolutions.Add(new Evolution(initial_part_list,rnd));
        }

        public void Fill_To_N_Evolutions(int N)
        {
            while (evolutions.Count<N)
            {
                int rnd = (int)(rng.NextDouble() * 100000);
                List<Part> part_list_to_add = new List<Part>();
                foreach(Part a_part in initial_part_list)
                {
                    Part part_to_add = new Part(a_part.position_x, a_part.position_y, a_part.size_x, a_part.size_y, a_part.placement_priority);
                    part_list_to_add.Add(part_to_add);
                }
                evolutions.Add(new Evolution(part_list_to_add, rnd));
            }
        }

        public void Evolve()
        {
            for (int N = 0; N < this.Number_Of_Steps; N++)
            {
                foreach (Evolution state in evolutions)
                {
                    state.Shuffle(2, panel.size_x, panel.size_y);
                    state.score = state.Calc_Score();
                }
                
            }
        }

    }
}
