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
    public class Spliter : Component
    {
        private int upOutFlow;
        private int lowOutFlow;
        private int inFlow;
        private Connection Input;
        private Connection UpOutput;
        private Connection LowOutput;
        private bool counterIn = false;
        private bool counterUpOut = false;
        private bool counterLowOut = false;


        public Spliter(Image image, int size, Point coordinates)
            : base(image, size, coordinates)
        {
            this.lowOutFlow = 0;
            this.upOutFlow = 0;           
        }

        public void Split()
        {
           // input = base.currentFlow;
            this.upOutFlow = currentFlow / 2;
            this.lowOutFlow = currentFlow / 2;
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
                conn.flow = upOutFlow;
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
