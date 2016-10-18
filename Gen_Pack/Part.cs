using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gen_Pack
{
    public class Part
    {
        public double position_x { get; set; }  //top left
        public double position_y { get; set; }  //top left    w.r.t.  panel 0,0 (at bottom left)
        public double size_x { get; set; }
        public double size_y { get; set; }
        public double border_mm { get; set; }
        public bool is_placed { get; set; }  //set true if part is on panel
        public bool clashes { get; set; } //set to true if part is overlapping with another
        public rotation part_orientation { get; set; }
        public enum rotation
        {
            top, bottom, left,right
        };

        public priority placement_priority { get; set; }

        public enum priority
        {
            high, medium, normal, low
        };

        public Part()
        {
            this.position_x = 0.0d;
            this.position_y = 0.0d;
            this.is_placed = true;
            this.part_orientation = rotation.top;
            this.placement_priority = priority.normal;
            this.clashes = false;
            this.border_mm = 0.0d;
        }

        public Part(double pos_x, double pos_y, double  sizex, double sizey, double border, priority priority_to_set)
        {
            this.position_x = pos_x;
            this.position_y = pos_y;
            this.border_mm = border;
            this.placement_priority = priority_to_set;
            this.size_x = sizex;
            this.size_y = sizey;
            this.is_placed = true;
            this.clashes = false;
        }
    }
}
