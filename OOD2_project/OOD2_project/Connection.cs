using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOD2_project
{
    public class Connection
    {
        public Component startComponent;
        public Component endComponent;
        public Color color;
        private int flow;
        private List<Point> listPoints;

        public Connection(Component StartComp, Component EndComp, Color Color)
        {
            this.startComponent = StartComp;
            this.endComponent = EndComp;
            this.color = Color;
            this.flow = 0;
            this.listPoints = new List<Point>();
        }



        /// <summary>
        /// Returns a string with the flow in this pipeline..
        /// </summary>
        public string setFlow()
        {
            return "Flow is: " + flow;
        }
    }
}
