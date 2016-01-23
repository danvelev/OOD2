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
        Rectangle rect;

        public Pump(Image image, int size, Point coordinates, int CurrentFlow)
            : base(image, size, coordinates)
        {
            //rect = new Rectangle(point.X - 1, point.Y - 1, base.size, base.size);
        }

        public void Clear()
        {
        }

        public override void DrawComponent(Graphics gr)
        {
            try
            {
                
                //rect.
                gr.DrawImage(base.image, base.rect);
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

        public override Point getPosition()
        {
            return base.getPosition();
        }

        public void setOutput(Connection con)
        {
            output = con;
        }


    }
}