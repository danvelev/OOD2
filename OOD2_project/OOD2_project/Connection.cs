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
        private int maxFlow;
        private Point[] curvePoints;

        public Connection(Component StartComp, Component EndComp, int currentFlow, int MaxFlow, Point[] points)
        {
            this.startComponent = StartComp;
            this.endComponent = EndComp;
            this.flow = currentFlow;
            this.maxFlow = MaxFlow;
            this.curvePoints = points;
        }



        /// <summary>
        /// Returns a string with the flow in this pipeline..
        /// </summary>
        public string setFlow()
        {
            return "Flow is: " + flow;
        }

        /// <summary>
        /// Returns TRUE if current flow is over the maximum flow..
        /// </summary>
        public bool IsCriticalSection()
        {
            if (flow > maxFlow)
            {
                return true;
            }
            else
                return false;
        }

        //need to be finished..
        public void DrawConnection(Graphics gr)
        {
            if (IsCriticalSection())
            {
                gr.DrawLines(new Pen(Brushes.Red, 5), curvePoints);
            }
            else
                gr.DrawLines(new Pen(Brushes.Green, 5), curvePoints);

        }
    }
}
