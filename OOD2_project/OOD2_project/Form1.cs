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
        List<Point> pointsList;
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
        Connection con;
        private Point[] points;
        private bool pipeActivate;

        public Form1()
        {
            InitializeComponent();
            pointsList = new List<Point>();
            this.network = new Network(workPanel.Height, workPanel.Width);
            cm.MenuItems.Add("Remove");
            cm.MenuItems.Add("Edit");
        }

        private void workPanel_MouseDown(object sender, MouseEventArgs e)
        {
            //Point p = new Point(e.X, e.Y);      //workPanel.PointToClient(new Point(e.X, e.Y));
            ////foreach (var compt in this.network.listComponents)
            ////{
            ////    if (compt.point == p)
            ////    {
            ////        cm.Show(this.workPanel, );
            ////    }
            ////}

            //// dasdas
            //if (pipeActivate)
            //{
            //    if (startComponent == null || endComponent == null)
            //    {
            //        this.addConnectionPoints(p);
            //    }
            //}
        }

        //Drawing the component on the workPanel..
        private void workPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            if (isSelected)
            {
                
                switch (selectedComponent)
                {
                    case "pump":   // CUrrent flow added...
                        if (tbCurrentFlow.Text == "" && tbMaxFlow.Text == "")
                        {
                            MessageBox.Show("Please enter the current and max flow");
                        }
                        else
                        {
                            if (!this.network.checkOverlap(point))
                            {

                                this.network.listComponents.Add(new Pump(selectedImage, (this.workPanel.Width - (this.workPanel.Width - selectedImage.Width)), point, Convert.ToInt32(tbCurrentFlow.Text)));

                            }
                            else
                                MessageBox.Show("Components cannot overlap!");
                        }
                        break;
                    case "adjSpliter":
                        trackBar1.Visible = true;
                        btSet.Visible = true;
                        if (!this.network.checkOverlap(point))
                        {
                            this.adjSpliter = new Adjustable_Spliter(selectedImage, (this.workPanel.Width - (this.workPanel.Width - selectedImage.Width)), point);
                            this.network.listComponents.Add(adjSpliter);
                        }
                        else
                            MessageBox.Show("Components cannot overlap!");
                        break;
                    case "spliter":
                        if (!this.network.checkOverlap(point))
                        {
                            this.network.listComponents.Add(new Spliter(selectedImage, (this.workPanel.Width - (this.workPanel.Width - selectedImage.Width)), point));
                        }
                        else
                            MessageBox.Show("Components cannot overlap!");
                        break;
                    case "merger":
                        if (!this.network.checkOverlap(point))
                        {
                            this.network.listComponents.Add(new Merger(selectedImage, (this.workPanel.Width - (this.workPanel.Width - selectedImage.Width)), point));
                        }
                        else
                            MessageBox.Show("Components cannot overlap!");
                        break;
                    case "sink":
                        if (!this.network.checkOverlap(point))
                        {
                            this.network.listComponents.Add(new Sink(selectedImage, (this.workPanel.Width - (this.workPanel.Width - selectedImage.Width)), point));
                        }
                        else
                            MessageBox.Show("Components cannot overlap!");
                        break;
                    case "pipe":
                        //this.network.listConnections.Add(new Connection(startComponent, endComponent, Convert.ToInt32(tbCurrentFlow.Text),Convert.ToInt32(tbMaxFlow),points));
                        break;
                }
                foreach(Component com in this.network.listComponents)
                {
                    // foreach loop to draw
                    if(com is Pump)
                        com.DrawComponent(gr);
                    else
                        com.DrawComponent(gr);
                }
                foreach (Connection c in this.network.listConnections)
                {
                    c.DrawConnection(gr);
                }
            }
            if (pipeActivate && endComponent != null)
            {
                con.DrawConnection(gr);
                pointsList = new List<Point>();
                startComponent = null;
                endComponent = null;
                pipeActivate = false;
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
            //isSelected = false;
            Cursor.Current = Cursors.Cross;
            pbPump.BorderStyle = BorderStyle.FixedSingle;
            selectedImage = pbPipe.Image;
            selectedComponent = "pipe";
            pbPump.DoDragDrop(selectedImage, DragDropEffects.Copy);
            //isSelected = true;
            pipeActivate = true;
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
            Point p = new Point(e.X, e.Y); //workPanel.PointToClient(new Point(e.X, e.Y));
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
                if (startComponent == null || endComponent == null)
                {
                    this.addConnectionPoints(p);
                }
            }
          
        }

        /// <summary>
        /// Collects and assigns points to the connections
        /// </summary>
        /// <param name="p"></param>
        private void addConnectionPoints(Point p)
        {
            if (this.network.getComponent(p) != null)
            {
                if (startComponent == null)
                {
                    startComponent = this.network.getComponent(p);
                    if (startComponent is Sink)
                    {
                        MessageBox.Show("You cannot start with Sink");
                        startComponent = null;
                    }
                    else
                        pointsList.Add(p);
                }
                else if (endComponent == null)
                {
                    endComponent = this.network.getComponent(p);
                    pointsList.Add(p);
                    points = pointsList.ToArray();
                    con = new Connection(startComponent, endComponent, Convert.ToInt32(tbCurrentFlow.Text), Convert.ToInt32(tbMaxFlow.Text), points);
                    this.network.listConnections.Add(con);
                    this.workPanel.Invalidate();
                }

            }
            else if (startComponent == null)
            {
                MessageBox.Show("You must select a starting component first");
            }
            else if (endComponent == null)
                pointsList.Add(p);

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

        private void pbPipe_Click(object sender, EventArgs e)
        {
            pipeActivate = true;
        }

    }
}
