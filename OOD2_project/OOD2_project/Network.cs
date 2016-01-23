using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OOD2_project
{
    [Serializable]
    public class Network
    {
        public int maxComponents;
        public int panelWidth;
        public int panelHeight;
        public List<Component> listComponents;
        public List<Connection> listConnections;
       // private int maxFlow;
        public Component component;
        public Connection connection;
        private string savedFile;

        public Network(int height, int width)
        {
            //this.maxFlow = 0;
            this.panelHeight = height;
            this.panelWidth = width;
            this.listComponents = new List<Component>();
            this.listConnections = new List<Connection>();
            this.maxComponents = 20;
        }


        /// <summary>
        /// Draws the component on the woking pannel and saves the drawn component in listComponents..
        /// </summary>
        /// <param name="component"></param>
        /// <param name="gr"></param>
        /// <param name="position"></param>
        public void drawComponent(Graphics gr, Point position, Component component)
        {
            try
            {
                Rectangle rect = new Rectangle(position.X - 1, position.Y - 1, component.size, component.size);
                gr.DrawImage(component.image, rect);   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool checkOverlap(Point p)
        {
            Rectangle r2 = new Rectangle(p, new Size(1, 1));
            foreach (Component comp in listComponents)
            {
                if (comp.rect.IntersectsWith(r2))
                {
                    return true;
                    
                }
            }
            return false;
        }

        public Component getComponent(Point p)
        {
            Rectangle r2 = new Rectangle(p, new Size(5, 5));
            foreach (Component comp in listComponents)
            {
                if (r2.IntersectsWith(comp.rect))
                {
                    return comp;

                }
            }
            return null;
        }

        public Connection getConnection(Connection conn)
        {
            foreach (Connection c in listConnections)
            {
                if (c == conn)
                    return c;
            }
            return null;
        }
        /// <summary>
        /// Method to Open a file with network
        /// </summary>
        public bool OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                BinaryFormatter bf = null;

                openFileDialog.Filter = "SimulatorExtension files (*.simex)|*.simex";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;


                fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                bf = new BinaryFormatter();
                Network loadNetwork = (Network)(bf.Deserialize(fs));
                this.listComponents = loadNetwork.listComponents;
                this.listConnections = loadNetwork.listConnections;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// save as a design 
        /// </summary>
        /// <param name="stream"></param>
        public bool SaveAs(Network network)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.FileName = "Simulation1";
            dialog.Filter = "SimulatorExtension files (*.simex)|*.simex";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                BinaryFormatter bf = null;

                fs = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write);
                bf = new BinaryFormatter();
                this.savedFile = dialog.FileName;
                bf.Serialize(fs, network);
                fs.Close();
                return true;

            }
            return false;

        }

    }
    
    
}
