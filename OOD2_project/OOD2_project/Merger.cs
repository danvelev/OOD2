using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOD2_project
{
    public class Merger : Component
    {
        private int upInput { get; set; }
        private int lowInput { get; set; }

        public Merger(Image image, int size, Point coordinates, int CurrentFlow)
            : base(image, size, coordinates, CurrentFlow)
        {
            //this.upInput = UpInput;
            //this.lowInput = LowInput;
        }

        public void Clear(Connection con)
        {
            //remove all connections related to a component
            this.connections.Remove(con);
        }

        public void DrawComponent(Graphics gr, Point p)
        {
            // draw the certain component on the work panel
        }

        public Point getPosition()
        {
            return point;
            // get the position of the component
        }

        public int Merge()
        {
            //merge the low and up outputs
            return 0;
        }

        public int setLowInput(Connection c)
        {
            //set the the low input
            return 0;
        }

        public int setUpInput(Connection c)
        {
            return 0;
            //set the up input of the component
        }



    }
}
