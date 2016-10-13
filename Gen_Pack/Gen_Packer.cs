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
        public List<Part> best_ever_part_list { get; set; }

        public  Panel panel { get; set; }
        private Random rng = new Random();
        public int Number_Of_Steps = 100;  //set externally 
        public double best_score = -1000000000.0d;
        public double best_ever_score = -1000000000.0d;
        public double average_score = 0;
        public int N_of_best = 0;
        public int Number_Of_Siblings = 10;  //set externally
        public string error_string = "PACKER_OK";
        public bool allow_rotations = true;

        public Gen_Packer()
        {
            evolutions = new List<Evolution>();
            initial_part_list = new List<Part>();
            panel = new Panel();
            average_score = 0.0d;
            best_score = 0.0d;
            error_string = "PACKER_OK";

        }

        public void Reset_Evolutions()
        {
            evolutions.Clear();
            best_ever_part_list = new List<Part>();
            average_score = 0.0d;
            best_score = -1000000000.0d;
            best_ever_score = -1000000000.0d;
            int rnd = (int)(rng.NextDouble() * 100000);
            evolutions.Add(new Evolution(initial_part_list,rnd));
        }

        public void Fill_To_N_Evolutions(int N, List<Part> best_config)
        {
            Evolution an_evolution;
            while (evolutions.Count<N)
            {
                int rnd = (int)(rng.NextDouble() * 100000);
                List<Part> part_list_to_add = new List<Part>();
                foreach(Part a_part in best_config)
                {
                    Part part_to_add = new Part(a_part.position_x, a_part.position_y, a_part.size_x, a_part.size_y, a_part.placement_priority);
                    part_to_add.clashes = a_part.clashes;
                    part_list_to_add.Add(part_to_add);
                }
                an_evolution = new Evolution(part_list_to_add, rnd);
                //an_evolution.Shuffle(2, panel.size_x, panel.size_y);
                an_evolution.score = best_ever_score;
                evolutions.Add(an_evolution);
            }
        }

        public void Evolve()
        {
            try
            {
                if(best_ever_part_list ==null)
                {
                    best_ever_part_list = initial_part_list;
                }

                Cull();
                Fill_To_N_Evolutions(Number_Of_Siblings, best_ever_part_list);

                for (int N = 0; N < this.Number_Of_Steps; N++)
                {
                    foreach (Evolution state in evolutions)
                    {
                        state.Shuffle(5, panel.size_x, panel.size_y);
                        state.score = state.Calc_Score();
                    }

                }

                Evaluate_Evolutions();
                Store_Best();
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

        private void Store_Best()
        {
            if (best_score > best_ever_score)
            {
                best_ever_score = best_score;
                best_ever_part_list = new List<Part>();
                foreach (Part a_part in evolutions[N_of_best].configuration)
                {
                    Part part_to_add = new Part(a_part.position_x, a_part.position_y, a_part.size_x, a_part.size_y, a_part.placement_priority);
                    part_to_add.clashes = a_part.clashes;
                    best_ever_part_list.Add(part_to_add);
                }
            }
        }

    }
}
