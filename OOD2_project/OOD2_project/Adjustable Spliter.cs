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
        private int inFlow;
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
            inFlow = 0;
            upOutFlow = 0;
            lowOutFlow = 0;
            //this.currentFlow = CurrentFlow;
        }

        public void Split(int value)
        {
           // input = base.currentFlow;
            this.upOutFlow = inFlow * ((value / 100) * inFlow);
            this.lowOutFlow = ((value / 100) * inFlow);
        }

        public void setInput(ref Connection conn)
        {
            if (counterIn)
                MessageBox.Show("You cannot have more than 1 Input");
            else
            {
                this.Input = conn;
                this.inFlow = conn.flow;
                counterIn = true;
            }
        }

        public void SetUpOutput(ref Connection conn)
        {
            if (counterUpOut)
            {
                this.UpOutput = conn;
                conn.flow = upOutFlow;
                counterUpOut = true;
            }
            else
            {
                MessageBox.Show("You can not have more than 2 up Outputs");
            }
        }

        public void SetLowOutput(ref Connection con)
        {
            if (counterLowOut)
            {
                this.LowOutput = con;
                con.flow = lowOutFlow;
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
