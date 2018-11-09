  using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lakiahrotest2
{
    public partial class Helper : Form
    {
        Graphics g;
        Graphics g2;
        Graphics g3;

        Point f = new Point(100, 100);

        int max = 12;

        Pen line1 = new Pen(Color.Red,3);
        Pen line2 = new Pen(Color.Black, 1);

        bool toolselected = false;

        public Helper()
        {
            InitializeComponent();
            pictureBox1.Height = max * 50 + 2;
            pictureBox1.Width = max * 50 + 2;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox2.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox3.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            comboBox1.Items.Add("PRI");
            comboBox1.Items.Add("DUO");
            comboBox1.Items.Add("TRI");
            comboBox1.Items.Add("TET");
            comboBox1.Items.Add("PEN");
            asdToolStripMenuItem.Enabled = false;
            x12ToolStripMenuItem.Enabled = false;
            x14ToolStripMenuItem.Enabled = false;
        }

        private void refresh()
        {
            pictureBox1.Image.Dispose();
            pictureBox2.Image.Dispose();
            pictureBox3.Image.Dispose();
            pictureBox1.Height = max * 50 + 2;
            pictureBox1.Width = max * 50 + 2;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox2.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox3.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (toolselected)
            {
                refresh();
                draw(max);
            }
            else
            {
                MessageBox.Show("Select tool!");
            }
        }

        private void draw(int max)
        {
            int x = 0;
            using (var g = Graphics.FromImage(pictureBox1.Image))
            {
                var g2 = Graphics.FromImage(pictureBox2.Image);
                var g3 = Graphics.FromImage(pictureBox3.Image);
                g.FillRectangle(Brushes.SandyBrown, new Rectangle(0, 0, max * 50, max * 50));
                for (int i = 0; i <= max; i++)
                {
                    g2.DrawString(i+1+"", new System.Drawing.Font("Arial", 10), new System.Drawing.SolidBrush(System.Drawing.Color.Black), 3, x+20);
                    g3.DrawString(i + 1 + "", new System.Drawing.Font("Arial", 10), new System.Drawing.SolidBrush(System.Drawing.Color.Black), x+20, 5);
                    g.DrawLine(Pens.Black, 0, 0 + x, max * 50, 0 + x);
                    g.DrawLine(Pens.Black, 0 + x, 0, 0 + x, max * 50);
                    x += 50;
                }
                g.FillRectangle(Brushes.Green, new Rectangle(((max * 50) - 200) / 2, ((max * 50) - 200) / 2, 200, 200));
                pictureBox1.Refresh();
                pictureBox2.Refresh();
                pictureBox3.Refresh();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            //MessageBox.Show(coordinates + "");
            switch (comboBox1.SelectedIndex)
            {
                case 0: drawareaPRI(coordinates, Brushes.Black, line1); break;
                case 1: drawareaDUO(coordinates, Brushes.Black, line1); break;
                case 2: drawareaTRI(coordinates, Brushes.Black, line1); break;
                case 3: drawareaTET(coordinates, Brushes.Black, line1); break;
                case 4: drawareaPEN(coordinates, Brushes.Black, line1); break;
            }
           
        }

        private void drawareaPEN(Point startp, Brush bg, Pen l)
        {
            Point startpoint = new Point(getdrawpos(startp).X, getdrawpos(startp).Y);
            using (var g = Graphics.FromImage(pictureBox1.Image))
            {
                g.FillEllipse(bg, new Rectangle(startpoint.X + 15, startpoint.Y + 15, 20, 20));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y - 50), new Point(startpoint.X + 100, startpoint.Y - 50));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y - 50), new Point(startpoint.X - 50, startpoint.Y + 100));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y + 100), new Point(startpoint.X + 100, startpoint.Y + 100));
                g.DrawLine(l, new Point(startpoint.X + 100, startpoint.Y - 50), new Point(startpoint.X + 100, startpoint.Y + 100));
                pictureBox1.Refresh();
            }
        }

        private void drawareaTET(Point startp,Brush bg,Pen l)
        {
            Point startpoint = new Point(getdrawpos(startp).X, getdrawpos(startp).Y);
              using (var g = Graphics.FromImage(pictureBox1.Image))
            {
                g.FillEllipse(bg, new Rectangle(startpoint.X + 15, startpoint.Y + 15, 20, 20));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y - 50), new Point(startpoint.X + 100, startpoint.Y - 50));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y - 50), new Point(startpoint.X - 50, startpoint.Y + 100));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y + 100), new Point(startpoint.X +50, startpoint.Y + 100));
                g.DrawLine(l, new Point(startpoint.X + 100, startpoint.Y - 50), new Point(startpoint.X + 100, startpoint.Y+ 50));
                g.DrawLine(l, new Point(startpoint.X + 100, startpoint.Y + 50), new Point(startpoint.X + 50, startpoint.Y + 50));
                g.DrawLine(l, new Point(startpoint.X + 50, startpoint.Y + 100), new Point(startpoint.X + 50, startpoint.Y + 50));
                pictureBox1.Refresh();
            }
        }

        private void drawareaTRI(Point startp, Brush bg, Pen l)
        {
            Point startpoint = new Point(getdrawpos(startp).X, getdrawpos(startp).Y);
            using (var g = Graphics.FromImage(pictureBox1.Image))
            {
                g.FillEllipse(bg, new Rectangle(startpoint.X + 15, startpoint.Y + 15, 20, 20));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y - 50), new Point(startpoint.X + 100, startpoint.Y - 50));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y - 50), new Point(startpoint.X - 50, startpoint.Y + 100));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y + 100), new Point(startpoint.X, startpoint.Y + 100));
                g.DrawLine(l, new Point(startpoint.X + 100, startpoint.Y - 50), new Point(startpoint.X + 100, startpoint.Y + 50));
                g.DrawLine(l, new Point(startpoint.X + 100, startpoint.Y + 50), new Point(startpoint.X, startpoint.Y + 50));
                g.DrawLine(l, new Point(startpoint.X, startpoint.Y + 50), new Point(startpoint.X, startpoint.Y + 100));
                pictureBox1.Refresh();
            }
        }

        private void drawareaDUO(Point startp, Brush bg, Pen l)
        {
            Point startpoint = new Point(getdrawpos(startp).X, getdrawpos(startp).Y);
            using (var g = Graphics.FromImage(pictureBox1.Image))
            {
                g.FillEllipse(bg, new Rectangle(startpoint.X + 15, startpoint.Y + 15, 20, 20));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y - 50), new Point(startpoint.X + 100, startpoint.Y - 50));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y - 50), new Point(startpoint.X - 50, startpoint.Y + 50));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y + 50), new Point(startpoint.X + 100, startpoint.Y + 50));
                g.DrawLine(l, new Point(startpoint.X + 100, startpoint.Y - 50), new Point(startpoint.X + 100, startpoint.Y + 50));
                pictureBox1.Refresh();
            }
        }

        private void drawareaPRI(Point startp, Brush bg, Pen l)
        {
            Point startpoint = new Point(getdrawpos(startp).X, getdrawpos(startp).Y);
            using (var g = Graphics.FromImage(pictureBox1.Image))
            {
                g.FillEllipse(bg, new Rectangle(startpoint.X + 15, startpoint.Y + 15, 20, 20));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y - 50), new Point(startpoint.X + 100, startpoint.Y - 50));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y - 50), new Point(startpoint.X - 50, startpoint.Y + 50));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y + 50), new Point(startpoint.X + 50, startpoint.Y + 50));
                g.DrawLine(l, new Point(startpoint.X + 100, startpoint.Y - 50), new Point(startpoint.X + 100, startpoint.Y));
                g.DrawLine(l, new Point(startpoint.X + 100, startpoint.Y), new Point(startpoint.X + 50, startpoint.Y));
                g.DrawLine(l, new Point(startpoint.X + 50, startpoint.Y + 50), new Point(startpoint.X + 50, startpoint.Y));
                pictureBox1.Refresh();
            }
        }

        private Point getdrawpos(Point p)
        {
            Point firstcell = new Point(0, 0);
            int firstnumx = Convert.ToInt16((Convert.ToString(p.X).Substring(0, 1)));
            int x1 = Convert.ToInt16((Convert.ToString(p.X).Substring(0, 1) + "50"));
            int x2 = Convert.ToInt16((Convert.ToString(p.X).Substring(0, 1) + "00"));
            int y1 = Convert.ToInt16((Convert.ToString(p.Y).Substring(0, 1) + "50"));
            int y2 = Convert.ToInt16((Convert.ToString(p.Y).Substring(0, 1) + "00"));

            if (p.X >= 100 && p.Y >= 100)
            {

                if (p.X >= x1)
                {
                    firstcell.X = x1;
                }
                else
                {
                    firstcell.X = x2;
                }
                if (p.Y >= y1)
                {
                    firstcell.Y = y1;
                }
                else
                {
                    firstcell.Y = y2;
                }
            }
            else
            {
                if (p.X == 0)
                {
                    firstcell.X = 0;
                }
                else if (p.Y == 0)
                {
                    firstcell.Y = 0;
                }
                else
                {

                    if (p.X >= 50 && p.X<=100)
                    {
                        firstcell.X = 50;
                        if (p.X == 0 && p.X<50)
                        {
                            firstcell.X = 0;
                        }
                    }
                    else
                    {
                        if (p.X >= x1)
                        {
                            firstcell.X = x1;
                        }
                        else
                        {
                            if (p.X>50)
                            {
                                firstcell.X = x2; 
                            }

                        }
                    }
                    if (p.Y >= 50 && p.Y <= 100)
                    {
                        firstcell.Y = 50;
                        if (p.Y == 0 && p.Y < 50)
                        {
                            firstcell.Y = 0;
                        }
                    }
                    else
                    {
                        if (p.Y >= y1)
                        {
                            firstcell.Y = y1;
                        }
                        else
                        {
                            if (p.Y > 50)
                            {
                                firstcell.Y = y2;
                            }

                        }
                    }
                }
            }
            return firstcell;
        }

        private void asdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            max = 10;
            refresh();
            draw(max);
            
        }

        private void x12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            max = 12;
            refresh();
            draw(max);
        }

        private void x14ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            max = 14;
            refresh();           
            draw(max);
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            //MessageBox.Show(coordinates + "");
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                     drawareaPRI(coordinates, Brushes.SandyBrown, new Pen(Color.SandyBrown, 3));
                     drawareaPRI(coordinates, Brushes.SandyBrown, line2); 
                    break;
                case 1:
                     drawareaDUO(coordinates, Brushes.SandyBrown, new Pen(Color.SandyBrown, 3));
                     drawareaDUO(coordinates, Brushes.SandyBrown, line2);
                    break;
                case 2: 
                     drawareaTRI(coordinates, Brushes.SandyBrown, new Pen(Color.SandyBrown, 3));
                     drawareaTRI(coordinates, Brushes.SandyBrown, line2); 
                    break;
                case 3:
                    drawareaTET(coordinates, Brushes.SandyBrown, new Pen(Color.SandyBrown, 3));
                    drawareaTET(coordinates, Brushes.SandyBrown, line2); 
                    break;
                case 4: 
                    drawareaPEN(coordinates, Brushes.SandyBrown, new Pen(Color.SandyBrown, 3));
                    drawareaPEN(coordinates, Brushes.SandyBrown, line2);  
                    break;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex!=-1)
            {
                MessageBox.Show("Tool setted");
                asdToolStripMenuItem.Enabled = true;
                x12ToolStripMenuItem.Enabled = true;
                x14ToolStripMenuItem.Enabled = true;
                toolselected = true;
                refresh();
            }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            g2 = e.Graphics;
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            g3 = e.Graphics;
        }
    }
}
