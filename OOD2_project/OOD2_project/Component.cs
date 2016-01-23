using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace OOD2_project
{
    [Serializable]
    public class Component
    {
        public Point point { get; set; }
        public Image image { get; set; }
        //private bool selected = false;
        public int currentFlow;
        public int size { get; set; }
        public List<Connection> connections;

        public Component(Image Image, int Size, Point coordinates)
        {
            this.point = coordinates;
            this.image = Image;
            this.size = Size;
            this.connections = new List<Connection>();
            //this.currentFlow = CurrentFlow;
        }

        /// <summary>
        /// Add connection to the connections list
        /// </summary>
        /// <param name="con"></param>
        public void AddConnection(Connection con)
        {
            this.connections.Add(con);
        }

        /// <summary>
        /// Remove connection from the connections list
        /// </summary>
        /// <param name="con"></param>
        public void RemoveConnection(Connection con)
        {
            this.connections.Remove(con);
        }

        /// <summary>
        /// Returns the position of the component. It will be implemented in the sub classes
        /// </summary>
        /// <param name="p"></param>
        public virtual Point getPosition() { return point; }

        /// <summary>
        /// Returns a list of connections..
        /// </summary>
        public List<Connection> getConnections() { return connections; }

        public virtual void DrawComponent(Graphics gr, Point position)
        {
            try
            {
                Rectangle rect = new Rectangle(position.X - 1, position.Y - 1, size, size);
                gr.DrawImage(image, rect);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }

}
