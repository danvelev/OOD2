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
    public class Sink : Component
    {
        private Connection input;
        private bool isEmpty;
        Rectangle rect;

        public Sink(Image image, int size, Point coordinates) 
            : base(image, size, coordinates) 
        {
            isEmpty = true;
        }

        public void Clear()
        {

        }

        public override void DrawComponent(Graphics gr)
        {
            try
            {
                rect = new Rectangle(point.X - 1, point.Y - 1, base.size, base.size);
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
        public override Point getPosition()
        {
            return base.getPosition();
        }

        /// <summary>
        /// sets the pipe connected to the component
        /// </summary>
        /// <param name="con"></param>
        public void setInput(Connection con)
        {
            if (isEmpty)
                input = con;
            else
                MessageBox.Show("You cannot have more than one Input in the Sink!");
        }

    }
}