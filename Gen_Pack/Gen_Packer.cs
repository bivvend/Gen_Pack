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
        public int Number_Of_Steps = 100;  //set externally 
        public double best_score = 0;
        public double average_score = 0;
        public int N_of_best = 0;
        public int Number_Of_Siblings = 10;  //set externally
        public string error_string = "PACKER_OK";

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

        public void Fill_To_N_Evolutions(int N, List<Part> best_config)
        {
            while (evolutions.Count<N)
            {
                int rnd = (int)(rng.NextDouble() * 100000);
                List<Part> part_list_to_add = new List<Part>();
                foreach(Part a_part in best_config)
                {
                    Part part_to_add = new Part(a_part.position_x, a_part.position_y, a_part.size_x, a_part.size_y, a_part.placement_priority);
                    part_list_to_add.Add(part_to_add);
                }
                evolutions.Add(new Evolution(part_list_to_add, rnd));
            }
        }

        public void Evolve()
        {
            try
            {
                for (int N = 0; N < this.Number_Of_Steps; N++)
                {
                    foreach (Evolution state in evolutions)
                    {
                        state.Shuffle(2, panel.size_x, panel.size_y);
                        state.score = state.Calc_Score();
                    }

                }
                Evaluate_Evolutions();
                Cull();
                Evaluate_Evolutions();
                Fill_To_N_Evolutions(Number_Of_Siblings, evolutions[N_of_best].configuration);
            }
            catch(Exception ex)
            {
                error_string = ex.ToString();
            }
        }

        private void Cull()
        {
            evolutions.RemoveAll(IsFitEnough);
            
        }

        private bool IsFitEnough(Evolution ev)
        {
            if (ev.score < average_score)
                return true;
            else
                return false;
        }

        private void Evaluate_Evolutions()
        {
            double ave = 0;
            best_score = -10000000000000000000.0d;
            for (int N = 0; N < evolutions.Count; N++)
            {
                ave+= evolutions[N].score;
                if (evolutions[N].score > best_score)
                {
                    N_of_best= N;
                    best_score= evolutions[N].score;                   

                }
            }
            if (evolutions.Count > 0)
            {
                average_score = ave / (double)evolutions.Count;
            }
        }

    }
}
