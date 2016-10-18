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
        public List<double> score_history { get; set; }
        public  List<Part> initial_part_list { get; set; }
        public List<Part> best_ever_part_list { get; set; }

        public  Panel panel { get; set; }
        private Random rng = new Random();
        public int Number_Of_Steps = 100;  //set externally 
        public double border = 0.0; //set externally
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
            score_history = new List<double>();
            panel = new Panel();
            average_score = 0.0d;
            best_score = 0.0d;
            error_string = "PACKER_OK";

        }

        public void Reset_Evolutions()
        {
            evolutions.Clear();
            best_ever_part_list = new List<Part>();
            score_history.Clear();
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
                    Part part_to_add = new Part(a_part.position_x, a_part.position_y, a_part.size_x, a_part.size_y, a_part.border_mm,a_part.placement_priority);
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
                score_history.Clear();
                if (best_ever_part_list ==null)
                {
                    best_ever_part_list = initial_part_list;
                }
                Evaluate_Evolutions();
                for (int N = 0; N < this.Number_Of_Steps; N++)
                {
                    Cull();
                    Fill_To_N_Evolutions(Number_Of_Siblings, best_ever_part_list);


                    foreach (Evolution state in evolutions)
                    {
                        if (state.number_of_clashes == 0)
                        {
                            state.Shuffle(panel.size_x / 4.0 + panel.size_y / 4.0, panel.size_x, panel.size_y);
                        }
                        else
                        {
                            state.Shuffle(panel.size_x / 20.0 + panel.size_y / 20.0, panel.size_x, panel.size_y);
                        }
                        state.score = state.Calc_Score();
                    }

                    Evaluate_Evolutions();                   
                    Neaten(evolutions[N_of_best]);
                    //need to recalc scores to reset any clashes after neatening
                    foreach (Evolution state in evolutions)
                    {
                        state.score = state.Calc_Score();
                    }
                    Evaluate_Evolutions();
                    Store_Best();
                    score_history.Add(best_ever_score);

                    //should abort if not changing
                    //if clashes when score not changing should start removing parts starting with lowest priority ones

                }                
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
                    Part part_to_add = new Part(a_part.position_x, a_part.position_y, a_part.size_x, a_part.size_y, a_part.border_mm, a_part.placement_priority);
                    part_to_add.clashes = a_part.clashes;
                    best_ever_part_list.Add(part_to_add);
                }
            }
        }

        //tidy up to ensure good packing to left/top
        private void Neaten(Evolution ev)
        {
            int counter = 0;
            int count_max = 100;
            double prev_x = 0.0;
            double prev_y = 0.0;
            double prev_score = 0.0;
            bool previous_clashes = false;


            foreach (Part a_part in ev.configuration)
            {
                counter = 0;
                while (counter < count_max)
                {
                    counter++;
                    //record old setup
                    prev_x = a_part.position_x;
                    prev_score = ev.score;
                    previous_clashes = a_part.clashes;
                    //shuffle 
                    a_part.position_x -= 1.0d;
                    ev.score = ev.Calc_Score();
                    if(ev.score>prev_score && a_part.position_x>=a_part.border_mm && a_part.position_x<(panel.size_x-a_part.border_mm))
                    {
                        //counter = counter;
                    }
                    else
                    {
                        a_part.position_x = prev_x;
                        ev.score = prev_score;
                        previous_clashes = a_part.clashes;
                        counter = count_max;
                    }                    

                }
                counter = 0;
                while (counter < count_max)
                {
                    counter++;
                    //record old setup
                    prev_y = a_part.position_y;
                    prev_score = ev.score;
                    previous_clashes = a_part.clashes;
                    //shuffle 
                    a_part.position_y += 1.0;
                    ev.score = ev.Calc_Score();
                    if (ev.score>prev_score && a_part.position_y >= a_part.border_mm + a_part.size_y && a_part.position_y < (panel.size_y - a_part.border_mm))
                    {

                    }
                    else
                    {
                        a_part.position_y = prev_y;
                        ev.score = prev_score;
                        counter = count_max;
                        a_part.clashes = previous_clashes;
                    }

                }

            }
        }

    }
}
