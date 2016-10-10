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

        public Gen_Packer()
        {
            evolutions = new List<Evolution>();
            initial_part_list = new List<Part>();
            panel = new Panel();
        }

        public void Reset_Evolutions()
        {
            evolutions.Clear();
            evolutions.Add(new Evolution(initial_part_list));
        }

        public void Fill_To_N_Evolutions(int N)
        {
            while (evolutions.Count<N)
            {
                evolutions.Add(new Evolution(initial_part_list));
            }
        }

        public void Evolve()
        {
            foreach(Evolution state in evolutions)
            {
                state.Shuffle(0.2, panel.size_x, panel.size_y);
                state.Calc_Score();
            }
        }

    }
}
