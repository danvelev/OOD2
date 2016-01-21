﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace OOD2_project
{
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

        public Network(int height, int width)
        {
            //this.maxFlow = 0;
            this.panelHeight = height;
            this.panelWidth = width;
            this.listComponents = new List<Component>();
            this.listConnections = new List<Connection>();
            this.maxComponents = 20;
        }

        public void drawConnection(Graphics g, Point clickPoint, Connection connection)
        {

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

    }
    
    
}