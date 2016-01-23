using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOD2_project
{
    public class Spliter : Component
    {
        private int upOutFlow;
        private int lowOutFlow;
        private int inFlow;
        private Connection Input;
        private Connection UpOutput;
        private Connection LowOutput;


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
