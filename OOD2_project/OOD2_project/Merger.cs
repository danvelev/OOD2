using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace OOD2_project
{
    [Serializable]
    public class Merger : Component
    {
        private Connection upInput { get; set; }
        private Connection lowInput { get; set; }
        private Connection Output { get; set; }
        private int lowInflow;
        private int upInflow;
        private bool counterLowIn = false;
        private bool counterUpIn = false;
        private bool counterOut = false;

        public Rectangle upperLeft;
        public Rectangle lowerLeft;
        public Rectangle output;

        public Merger(Image image, int size, Point coordinates)
            : base(image, size, coordinates)
        {
            //this.upInput = UpInput;
            //this.lowInput = LowInput;
            upperLeft = new Rectangle(0, 0, 30, 20);
            lowerLeft = new Rectangle(0, 21, 30, 20);
            output = new Rectangle(33, 0, 35, 40);
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

        public override Point getPosition()
        {
            return base.getPosition();
            // get the position of the component
        }

        public int Merge()
        {
            //merge the low and up outputs
            return 0;
        }

        public void setLowInput(Connection c, int flow)
        {
            //set the the low input
            if (!counterLowIn)
            {
                lowInput = c;
                counterLowIn = true;
            }
            else
                MessageBox.Show("You cannot have more than 2 low Inputs in a Merger!");

        }

        public void setUpInput(Connection c)
        {
            if (!counterUpIn)
            {
                upInput = c;
                counterUpIn = true;
            }
            else
                MessageBox.Show("You cannot have more than 2 low Inputs in a Merger!");
            //set the up input of the component
        }

        public void setOutput(Connection c)
        {
            if (!counterOut)
            {
                Output = c;
                counterOut = true;
            }
            else
                MessageBox.Show("You cannot have more than 2 low Inputs in a Merger!");
        }




    }
}
