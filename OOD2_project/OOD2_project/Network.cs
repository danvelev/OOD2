﻿using System;
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

        /// <summary>
        /// Check if two components are overlaping 
        /// </summary>
        /// <param name="p"></param>
        public bool checkOverlap(Point p)
        {
            Rectangle r2 = new Rectangle(p, new Size(1, 1));
            foreach (Component comp in listComponents)
            {
                //Checks the intersection
                if (comp.rect.IntersectsWith(r2))
                {
                    return true;
                    
                }
            }
            return false;
        }

        /// <summary>
        /// Get component from the components list
        /// </summary>
        /// <param name="p"></param>
        public Component getComponent(Point p)
        {
            Rectangle r2 = new Rectangle(p, new Size(5, 5));
            foreach (Component comp in listComponents)
            {
                //Check if the clicked position intersect with some of the components
                if (r2.IntersectsWith(comp.rect))
                {
                    return comp;

                }
            }
            return null;
        }

        /// <summary>
        /// Get connection from the connections list
        /// </summary>
        /// <param name="conn"></param>
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
        /// Add connection to the connections list
        /// </summary>
        /// <param name="con"></param>
        public void AddConnection(ref Connection con)
        {
            

            if (con.startComponent is Pump)
            {

                for (int i = 0; i < listComponents.Count; i++)
                {
                    if (listComponents.ElementAt(i) == con.startComponent)
                    {
                        Pump p = listComponents.ElementAt(i) as Pump;
                        p.setOutput(ref con);
                        if (con != null)
                        {
                            listComponents[i] = p;
                            con.startComponent = p;
                           // this.listConnections.Add(con);
                        }

                        break;
                    }
                }
            }
            else if (con.startComponent is Spliter)
            {

                for (int i = 0; i < listComponents.Count; i++)
                {
                    if (listComponents.ElementAt(i) == con.startComponent)
                    {
                        Spliter p = listComponents.ElementAt(i) as Spliter;
                        Rectangle r1 = new Rectangle(con.curvePoints[0], new Size(2, 2));
                        if (r1.IntersectsWith(p.upperRight))
                        {
                            p.SetUpOutput(ref con);
                            if (con != null)
                            {
                                listComponents[i] = p;
                                con.startComponent = p;
                                //this.listConnections.Add(con);
                            }
                        }
                        else if (r1.IntersectsWith(p.lowerRight))
                        {
                            p.SetLowOutput(ref con);
                            if (con != null)
                            {
                                listComponents[i] = p;
                                con.startComponent = p;
                                //this.listConnections.Add(con);
                            }
                        }
                        break;
                    }
                }
            } 
            else if (con.startComponent is Adjustable_Spliter)
            {

                for (int i = 0; i < listComponents.Count; i++)
                {
                    if (listComponents.ElementAt(i) == con.startComponent)
                    {
                        Spliter p = listComponents.ElementAt(i) as Spliter;
                        Rectangle r1 = new Rectangle(con.curvePoints[0], new Size(2, 2));
                        if (r1.IntersectsWith(p.upperRight))
                        {
                            p.SetUpOutput(ref con);
                            if (con != null)
                            {
                                listComponents[i] = p;
                                con.startComponent = p;
                                //this.listConnections.Add(con);
                            }
                        }
                        else if (r1.IntersectsWith(p.lowerRight))
                        {
                            p.SetLowOutput(ref con);
                            if (con != null)
                            {
                                listComponents[i] = p;
                                con.startComponent = p;
                                //this.listConnections.Add(con);
                            }
                        }
                        break;
                    }
                }
            } 
            else if (con.startComponent is Merger)
            {

                for (int i = 0; i < listComponents.Count; i++)
                {
                    if (listComponents.ElementAt(i) == con.startComponent)
                    {
                        Merger m = listComponents.ElementAt(i) as Merger;
                        m.setOutput(ref con);
                        if (con != null)
                        {
                            listComponents[i] = m;
                            con.startComponent = m;
                           // this.listConnections.Add(con);
                        }
                        break;
                    }
                }
            }
            if (con != null)
            {
                if (con.endComponent is Merger)
                {
                    for (int i = 0; i < listComponents.Count; i++)
                    {
                        if (listComponents.ElementAt(i) == con.endComponent)
                        {
                            Merger m = listComponents.ElementAt(i) as Merger;
                            Rectangle r1 = new Rectangle(con.curvePoints[con.curvePoints.Count() - 1], new Size(2, 2));
                            if (r1.IntersectsWith(m.lowerLeft))
                            {
                                m.setLowInput(ref con);
                                if (con != null)
                                {
                                    listComponents[i] = m;
                                    con.endComponent = m;
                                    this.listConnections.Add(con);
                                }
                                break;
                            }

                            else if (r1.IntersectsWith(m.upperLeft))
                            {
                                m.setUpInput(ref con);
                                if (con != null)
                                {
                                    listComponents[i] = m;
                                    con.endComponent = m;
                                    this.listConnections.Add(con);
                                }
                                break;
                            }
                        }

                    }
                }
            }
            
        }


        /// <summary>
        /// Remove component from the components list
        /// </summary>
        /// <param name="comp"></param>
        public void RemoveComponent(Component comp)
        {
                   // this.RemoveConnection();
                    this.listComponents.Remove(comp);
        }

        /// <summary>
        /// Remove connection from the connections list
        /// </summary>
        /// <param name="con"></param>
        public void RemoveConnection(Connection con)
        {
            this.listConnections.Remove(con);
        }

        /// <summary>
        /// SaveAs method to save the whole network
        /// </summary>
        /// <param name="network"></param>
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
