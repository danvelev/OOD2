using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace OOD2_project
{
    public class Sink : Component
    {
        private Connection input;
        private bool isEmpty;

        public Sink(Image image, int size, Point coordinates) 
            : base(image, size, coordinates) 
        {
            isEmpty = true;
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

        /// <summary>
        /// return the position of the component
        /// </summary>
        /// <returns></returns>
        public Point getPosition()
        {
            return base.point;
        }

        /// <summary>
        /// sets the pipe connected to the component
        /// </summary>
        /// <param name="con"></param>
        public void setInput(Connection con)
        {
            input = con;
        }

    }
}