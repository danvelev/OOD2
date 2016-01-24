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
        public int upOutFlow;
        public int lowOutFlow;
        public int inFlow;
        private Connection Input;
        private Connection UpOutput;
        private Connection LowOutput;
        private bool counterIn = false;
        private bool counterUpOut = false;
        private bool counterLowOut = false;

        public Rectangle upperRight;
        public Rectangle lowerRight;
        public Rectangle input;


        public Spliter(Image image, int size, Point coordinates)
            : base(image, size, coordinates)
        {
            this.lowOutFlow = 0;
            this.upOutFlow = 0;
            this.inFlow = 0;
            upperRight = new Rectangle((base.rect.Right - (base.rect.Width / 2)+10), base.rect.Bottom - base.rect.Height, 30, 27);
            lowerRight = new Rectangle((base.rect.Right - (base.rect.Width / 2)+12), base.rect.Top + (base.rect.Height / 2), base.rect.Width / 2, (base.rect.Height / 2) + 1);
            input = new Rectangle(base.rect.Left, base.rect.Top, base.rect.Width / 2, base.rect.Height);

            //upperRight = new Rectangle(base.rect.Left + (base.rect.Width / 2), base.rect.Top + (base.rect.Width / 2), base.rect.Width / 2, base.rect.Height / 2);
            //lowerRight = new Rectangle(base.rect.Left + (base.rect.Width / 2), base.rect.Top + (base.rect.Height / 2), base.rect.Width / 2, base.rect.Height / 2);
            //input = new Rectangle(base.rect.Left, base.rect.Top, base.rect.Width / 2, base.rect.Height);
        }

        public void Split()
        {
           // input = base.currentFlow;
            this.upOutFlow = currentFlow / 2;
            this.lowOutFlow = currentFlow / 2;
        }

        public void setInput( ref Connection conn)
        {
            if (counterIn)
            {
                MessageBox.Show("You cannot have more than 1 Input");
                conn = null;
            }
            else
            {
                this.Input = conn;
                this.inFlow = conn.flow;
                counterIn = true;
            }
            
        }

        public void SetUpOutput(ref Connection conn)
        {
            if (!counterUpOut)
            {
                this.UpOutput = conn;
                conn.flow = upOutFlow;
                counterUpOut = true;
            }
            else
            {
                MessageBox.Show("You can not have more than 2 up Outputs");
                conn = null;
            }
        }

        public void SetLowOutput(ref Connection con)
        {
            if (!counterLowOut)
            {
                this.LowOutput = con;
                con.flow = lowOutFlow;
                counterLowOut = true;
            }
            else
            {
                MessageBox.Show("You can not have more than 2 low Outputs");
                con = null;
            }
        }

        public override Point getPosition()
        {
            return base.getPosition();
        }


    }
    
}
