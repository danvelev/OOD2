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
        private List<Point> listPoints;

        public Connection(Component StartComp, Component EndComp, int currentFlow, int MaxFlow)
        {
            this.startComponent = StartComp;
            this.endComponent = EndComp;
            this.flow = currentFlow;
            this.maxFlow = MaxFlow;
            this.listPoints = new List<Point>();
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

        }
    }
}
