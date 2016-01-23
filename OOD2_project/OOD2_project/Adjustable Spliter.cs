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
        private bool counterIn = false;
        private bool counterUpOut = false;
        private bool counterLowOut = false;

        public Adjustable_Spliter(Image image, int size, Point coordinates)
            : base(image, size, coordinates)
        {
        
            //this.currentFlow = CurrentFlow;
        }

        public void Split(int value)
        {
           // input = base.currentFlow;
            this.upOutFlow = currentFlow * ((value / 100) * currentFlow);
            this.lowOutFlow = ((value / 100) * currentFlow);
        }

        public void setInput(Connection conn, int flow)
        {
            if (counterIn)
                MessageBox.Show("You cannot have more than 1 Input");
            else
            {
                this.Input = conn;
                this.currentFlow = flow;
                counterIn = true;
            }
        }

        public void SetUpOutput(Connection conn)
        {
            if (counterUpOut)
            {
                this.UpOutput = conn;
                counterUpOut = true;
            }
            else
            {
                MessageBox.Show("You can not have more than 2 up Outputs");
            }
        }

        public void SetLowOutput(Connection con)
        {
            if (counterLowOut)
            {
                this.LowOutput = con;
                counterLowOut = true;
            }
            else
            {
                MessageBox.Show("You can not have more than 2 low Outputs");
            }
        }

        public override Point getPosition()
        {
            return base.getPosition();
        }

        
    }
}
