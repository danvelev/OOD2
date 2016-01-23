using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OOD2_project
{
    public partial class Form1 : Form
    {
        List<Point> p;
        private Image selectedImage;
        private string selectedComponent;
        private bool isSelected = false; //To show that there is a selected component..
        public Network network;
        public ContextMenu cm = new ContextMenu();
        private Point point;
        private Component startComponent;
        private Component endComponent;
        private int upPercentage;
        private int lowPercentage;
        private Adjustable_Spliter adjSpliter;
        private Point[] points;
        private bool pipeActivate;

        public Form1()
        {
            InitializeComponent();
            p = new List<Point>();
            this.network = new Network(workPanel.Height, workPanel.Width);
            cm.MenuItems.Add("Remove");
            cm.MenuItems.Add("Edit");
        }

        private void workPanel_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        //Drawing the component on the workPanel..
        private void workPanel_Paint(object sender, PaintEventArgs e)
        {
            if (isSelected)
            {
                Graphics gr = e.Graphics;
                switch (selectedComponent)
                {
                    case "pump":   // CUrrent flow added...
                        if (tbCurrentFlow.Text == "" && tbMaxFlow.Text == "")
                        {
                            MessageBox.Show("Please enter the current and max flow");
                        }
                        else
                        {
                            this.network.listComponents.Add(new Pump(selectedImage, (this.workPanel.Width - (this.workPanel.Width - selectedImage.Width)), point, Convert.ToInt32(tbCurrentFlow.Text)));
                        }
                        break;
                    case "adjSpliter":
                        trackBar1.Visible = true;
                        btSet.Visible = true;
                        this.adjSpliter = new Adjustable_Spliter(selectedImage, (this.workPanel.Width - (this.workPanel.Width - selectedImage.Width)), point);
                        this.network.listComponents.Add(adjSpliter);
                        break;
                    case "spliter":
                        this.network.listComponents.Add(new Spliter(selectedImage, (this.workPanel.Width - (this.workPanel.Width - selectedImage.Width)), point ));
                        break;
                    case "merger":
                        this.network.listComponents.Add(new Merger(selectedImage, (this.workPanel.Width - (this.workPanel.Width - selectedImage.Width)), point));
                        break;
                    case "sink":
                        this.network.listComponents.Add(new Sink(selectedImage, (this.workPanel.Width - (this.workPanel.Width - selectedImage.Width)), point));
                        break;
                    case "pipe":
                        this.network.listConnections.Add(new Connection(startComponent, endComponent, Convert.ToInt32(tbCurrentFlow.Text),Convert.ToInt32(tbMaxFlow),points));
                        break;
                }
                for (int i = 0; i < network.listComponents.Count; i++)
                {
                    this.network.drawComponent(gr, network.listComponents[i].point, network.listComponents[i]);
                }
            }
            this.network.panelHeight = Convert.ToInt32(this.workPanel.Size.Height);
            this.network.panelWidth = Convert.ToInt32(this.workPanel.Size.Width);

        }
        private void pbPump_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Cross;
            pbPump.BorderStyle = BorderStyle.FixedSingle;
            selectedImage = pbPump.Image;
            selectedComponent = "pump";
            pbPump.DoDragDrop(selectedImage, DragDropEffects.Copy);
            isSelected = true;
        }

        private void pbSink_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Cross;
            pbPump.BorderStyle = BorderStyle.FixedSingle;
            selectedImage = pbSink.Image;
            selectedComponent = "sink";
            pbPump.DoDragDrop(selectedImage, DragDropEffects.Copy);
            isSelected = true;            
        }

        private void pbAdjustableSpliter_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Cross;
            pbPump.BorderStyle = BorderStyle.FixedSingle;
            selectedImage = pbAdjustableSpliter.Image;
            selectedComponent = "adjSpliter";
            pbPump.DoDragDrop(selectedImage, DragDropEffects.Copy);
            isSelected = true;
        }

        private void pbSpliter_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Cross;
            pbPump.BorderStyle = BorderStyle.FixedSingle;
            selectedImage = pbSpliter.Image;
            selectedComponent = "spliter";
            pbPump.DoDragDrop(selectedImage, DragDropEffects.Copy);
            isSelected = true;
        }

        private void pbMerger_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Cross;
            pbPump.BorderStyle = BorderStyle.FixedSingle;
            selectedImage = pbMerger.Image;
            selectedComponent = "merger";
            pbPump.DoDragDrop(selectedImage, DragDropEffects.Copy);
            isSelected = true;
            
        }

        private void pbPipe_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Cross;
            pbPump.BorderStyle = BorderStyle.FixedSingle;
            selectedImage = pbPipe.Image;
            selectedComponent = "pipe";
            pbPump.DoDragDrop(selectedImage, DragDropEffects.Copy);
            isSelected = true;
        }

        private void workPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        //Checks where the client clicks on the workPanel and add the point to the listComponent..
        private void workPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (selectedImage != null)
            {
                point = workPanel.PointToClient(new Point(e.X, e.Y));
                //this.network.component = new Component(selectedImage, (this.workPanel.Width - (this.workPanel.Width - selectedImage.Width)), p, Convert.ToInt32(this.tbCurrentFlow.Text));
                //network.component.point = p;
                //this.network.listComponents.Add(this.network.component);
                this.workPanel.Invalidate();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.workPanel.AllowDrop = true;
        }

        private void pbPump_MouseUp(object sender, MouseEventArgs e)
        {
            selectedImage = null;
            pbPump.BorderStyle = BorderStyle.None;
            point = new Point(e.X, e.Y);
        }

        private void pbSink_MouseUp(object sender, MouseEventArgs e)
        {
            selectedImage = null;
            pbSink.BorderStyle = BorderStyle.None;
            point = new Point(e.X, e.Y);
        }

        private void pbAdjustableSpliter_MouseUp(object sender, MouseEventArgs e)
        {
            selectedImage = null;
            pbAdjustableSpliter.BorderStyle = BorderStyle.None;
            point = new Point(e.X, e.Y);
            trackBar1.Visible = true;
            
        }

        private void pbSpliter_MouseUp(object sender, MouseEventArgs e)
        {
            selectedImage = null;
            pbSpliter.BorderStyle = BorderStyle.None;
            point = new Point(e.X, e.Y);
        }

        private void pbMerger_MouseUp(object sender, MouseEventArgs e)
        {
            selectedImage = null;
            pbMerger.BorderStyle = BorderStyle.None;
            point = new Point(e.X, e.Y);
        }

        private void pbPipe_MouseUp(object sender, MouseEventArgs e)
        {
            selectedImage = null;
            pbPipe.BorderStyle = BorderStyle.None;
        }

        private void workPanel_MouseClick(object sender, MouseEventArgs e)
        {
            //Point p = workPanel.PointToClient(new Point(e.X, e.Y));
            //foreach (var compt in this.network.listComponents)
            //{
            //    if (compt.point == p)
            //    {
            //        cm.Show(this.workPanel, );
            //    }
            //}

            // dasdas
            if (pipeActivate)
            {
                while (startComponent == null && endComponent == null)
                {
                    if (this.network.getComponent(new Point(e.X, e.Y)) != null)
                    {
                        if (startComponent == null)
                        {
                            startComponent = this.network.getComponent(new Point(e.X, e.Y));
                        }
                        else if (endComponent == null)
                        {
                            endComponent = this.network.getComponent(new Point(e.X, e.Y));
                        }

                    }
                }
            }
          
        }

        private void btSet_Click(object sender, EventArgs e)
        {
            trackBar1.Visible = false;
            btSet.Visible = false;
            adjSpliter.Split(trackBar1.Value);
             
        }

        private void pbPipe_MouseClick(object sender, MouseEventArgs e)
        {
            pipeActivate = true;
        }

    }
}
