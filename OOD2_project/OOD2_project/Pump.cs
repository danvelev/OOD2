using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace OOD2_project
{
    public class Pump : Component
    {
        private int maxFlow;
        private Connection output;

        public Pump(Image image, int size, Point coordinates, int CurrentFlow)
            : base(image, size, coordinates)
        {

        }

        public void Clear()
        {
        }

        public override void DrawComponent(Graphics gr, Point position)
        {
            try
            {
                Rectangle rect = new Rectangle(position.X - 1, position.Y - 1, base.size, base.size);
                gr.DrawImage(base.image, rect);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Connection getOutput()
        {
            return output;
        }

        public Point getPosition()
        {
            return base.point;
        }

        public void setOutput(Connection con)
        {
            output = con;
        }


    }
}