using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gen_Pack
{
    public class Panel
    {
        public double size_x { get; set; } //mm
        public double size_y { get; set; } //mm

        public Panel()
        {

        }

        public Panel(double sizex, double sizey)
        {
            this.size_x = sizex;
            this.size_y = sizey;
        }

    }
}
