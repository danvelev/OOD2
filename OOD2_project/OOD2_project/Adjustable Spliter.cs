using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOD2_project
{
    public class Adjustable_Spliter : Component
    {
        private int lowPercentage;
        private int upPercentage;
        private int currentFlow;
        public int upOutFlow;
        public int lowOutFlow;
        private Connection Input;
        private Connection UpOutput;
        private Connection LowOutput;

        public Adjustable_Spliter(Image image, int size, Point coordinates, int LowPercentage, int UpPercentage)
            : base(image, size, coordinates)
        {
            this.lowPercentage = LowPercentage;
            this.upPercentage = UpPercentage;
            //this.currentFlow = CurrentFlow;
        }

        public void Spliter()
        {
           // input = base.currentFlow;
            this.upOutFlow = currentFlow - upPercentage;
            this.lowOutFlow = currentFlow - lowPercentage;
        }

        public void setInput(Connection conn, int flow)
        {
            this.Input = conn;

        }

        public void SetUpOutput(Connection conn)
        {
            this.UpOutput = conn;
        }

        public void SetLowOutput(Connection con)
        {
            this.LowOutput = con;
        }

        
    }
}
