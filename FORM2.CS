using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trainingapp
{

    public partial class Form1 : Form
    {
        System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 10);
        System.Drawing.Font drawFont2 = new System.Drawing.Font("Comic Sans MS", 16);
        System.Drawing.Font drawFont3 = new System.Drawing.Font("Comic Sans MS", 14);
        Pen line = new Pen(Color.FromArgb(85, 84, 92), 3);
        Pen line2 = new Pen(Color.FromArgb(85, 84, 92), 2);
        Pen line3 = new Pen(Color.FromArgb(85, 84, 92), 1);
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        Bitmap tile = new Bitmap((Bitmap)Image.FromFile("./tile1.png"));
        Bitmap soil = new Bitmap((Bitmap)Image.FromFile("./soil.png"));
        Bitmap item = new Bitmap((Bitmap)Image.FromFile("./item.png"));
        Bitmap floor = new Bitmap((Bitmap)Image.FromFile("./floor.png"));

        public Form1()
        {
            InitializeComponent();
            mapimage.Image = new Bitmap(mapimage.Width, mapimage.Height);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 13, 13));
            roundtext.Parent = rewardpanel;
            roundtext.Text = "1/4";
            roundtext.Font = drawFont3;
            roundtext.ForeColor = Color.FromArgb(234, 187, 44);
            roundtext.BackColor = Color.Transparent;
            roundtext.Location = new Point(30, 16);
            roundtext.Refresh();
            percenttext.Parent = rewardpanel;
            percenttext.Text = "100 %";
            percenttext.Font = drawFont3;
            percenttext.ForeColor = Color.FromArgb(234, 187, 44);
            percenttext.BackColor = Color.Transparent;
            percenttext.Location = new Point(100, 147);
            draw(12);
            floorpicture.Location=new Point(12+200, 41+200);
            floorpicture.Image = floor;
            floorpicture.Refresh();
            percenttext.Refresh();
        }

        private void mapimage_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
          //  MessageBox.Show(""+this.DisplayRectangle.Height);
            e.Graphics.DrawRectangle(line,new Rectangle(2,2,DisplayRectangle.Width-5,DisplayRectangle.Height-5));
            e.Graphics.DrawLine(line2, new Point(1, 34), new Point(DisplayRectangle.Width-1,34));
        }

        private void rewardpanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(line2, new Rectangle(1, 1, rewardpanel.Width-2, rewardpanel.Height-2));
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Rectangle(10, 3, 168, 50), Color.FromArgb(28, 32, 44), Color.FromArgb(28, 32, 44), 1);
            LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(new Rectangle(10, 110, 168, 50), Color.FromArgb(28, 32, 44), Color.FromArgb(28, 32, 44), 1);
            
            ColorBlend cblend = new ColorBlend(3);
            cblend.Colors = new Color[3] { Color.FromArgb(28, 32, 44), Color.FromArgb(50, 68, 107), Color.FromArgb(28, 32, 44) };
            cblend.Positions = new float[3] { 0f, 0.5f, 1f };

            linearGradientBrush.InterpolationColors = cblend;
            linearGradientBrush2.InterpolationColors = cblend;

            e.Graphics.FillRectangle(linearGradientBrush, new Rectangle(10, 3, 168, 50));
            e.Graphics.FillRectangle(linearGradientBrush2, new Rectangle(10, 130, 168, 55));

            e.Graphics.DrawRectangle(line3, new Rectangle(40, 200, 13, 400));
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(135, 106, 14)), new Rectangle(41, 201, 12, 399));
            int x = 0;
            int y = 0;
            int percent=100;
            for (int i = 0; i < 6; i++)
            {
                e.Graphics.DrawImage(item, new Point(73, 200 + y));
                y += 70;
            }
            for (int i = 0; i < 5; i++)
            {
                e.Graphics.DrawString(percent.ToString(), drawFont, new SolidBrush(Color.FromArgb(234, 187, 44)), new PointF(12, 188 + x));
                e.Graphics.DrawLine(new Pen(Color.Black,1),new Point(40,280+x),new Point(54,280+x));

                percent -= 20;
                x += 80;
            }
            e.Graphics.DrawString("0" ,drawFont, new SolidBrush(Color.FromArgb(234, 187, 44)), new PointF(15, 584));
            e.Graphics.DrawString("Round", drawFont2, new SolidBrush(Color.FromArgb(234, 187, 44)), new PointF(75, 13));
            e.Graphics.DrawString("Lakiahro: ", drawFont3, new SolidBrush(Color.FromArgb(234, 187, 44)), new PointF(15, 145));
        }

        private void mapimage_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                justpoint(coordinates);
            }
            if (me.Button == System.Windows.Forms.MouseButtons.Left)
            {
                drawareaPRI(coordinates);
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

                    if (p.X >= 50 && p.X <= 100)
                    {
                        firstcell.X = 50;
                        if (p.X == 0 && p.X < 50)
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
                            if (p.X > 50)
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

        private void justpoint(Point startp)
        {

            Point startpoint = new Point(getdrawpos(startp).X, getdrawpos(startp).Y);
            using (var g = Graphics.FromImage(mapimage.Image))
            {
                g.DrawImage(soil, startpoint);
                mapimage.Refresh();
            }
        }

        private void draw(int max)
        {
            int x = 0;
            int a = 0;
            int b = 0;
            using (var g = Graphics.FromImage(mapimage.Image))
            {

                for (int i = 0; i < max; i++)
                {
                    for (int y = 0; y < max; y++)
                    {
                        g.DrawImage(tile, 0 + a, 0 + b);
                        a += 50;
                    }
                    b += 50;
                    a = 0;
                }     
            }
            mapimage.Refresh();
        }

        private void drawareaPEN(Point startp, Brush bg, Pen l)
        {
            Point startpoint = new Point(getdrawpos(startp).X, getdrawpos(startp).Y);
            using (var g = Graphics.FromImage(mapimage.Image))
            {
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y - 50), new Point(startpoint.X + 100, startpoint.Y - 50));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y - 50), new Point(startpoint.X - 50, startpoint.Y + 100));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y + 100), new Point(startpoint.X + 100, startpoint.Y + 100));
                g.DrawLine(l, new Point(startpoint.X + 100, startpoint.Y - 50), new Point(startpoint.X + 100, startpoint.Y + 100));
                mapimage.Refresh();
            }
        }

        private void drawareaTET(Point startp, Brush bg, Pen l)
        {
            Point startpoint = new Point(getdrawpos(startp).X, getdrawpos(startp).Y);
            using (var g = Graphics.FromImage(mapimage.Image))
            {
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y - 50), new Point(startpoint.X + 100, startpoint.Y - 50));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y - 50), new Point(startpoint.X - 50, startpoint.Y + 100));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y + 100), new Point(startpoint.X + 50, startpoint.Y + 100));
                g.DrawLine(l, new Point(startpoint.X + 100, startpoint.Y - 50), new Point(startpoint.X + 100, startpoint.Y + 50));
                g.DrawLine(l, new Point(startpoint.X + 100, startpoint.Y + 50), new Point(startpoint.X + 50, startpoint.Y + 50));
                g.DrawLine(l, new Point(startpoint.X + 50, startpoint.Y + 100), new Point(startpoint.X + 50, startpoint.Y + 50));
                mapimage.Refresh();
            }
        }

        private void drawareaTRI(Point startp, Brush bg, Pen l)
        {
            Point startpoint = new Point(getdrawpos(startp).X, getdrawpos(startp).Y);
            using (var g = Graphics.FromImage(mapimage.Image))
            {
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y - 50), new Point(startpoint.X + 100, startpoint.Y - 50));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y - 50), new Point(startpoint.X - 50, startpoint.Y + 100));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y + 100), new Point(startpoint.X, startpoint.Y + 100));
                g.DrawLine(l, new Point(startpoint.X + 100, startpoint.Y - 50), new Point(startpoint.X + 100, startpoint.Y + 50));
                g.DrawLine(l, new Point(startpoint.X + 100, startpoint.Y + 50), new Point(startpoint.X, startpoint.Y + 50));
                g.DrawLine(l, new Point(startpoint.X, startpoint.Y + 50), new Point(startpoint.X, startpoint.Y + 100));
                mapimage.Refresh();
            }
        }

        private void drawareaDUO(Point startp, Brush bg, Pen l)
        {
            Point startpoint = new Point(getdrawpos(startp).X, getdrawpos(startp).Y);
            using (var g = Graphics.FromImage(mapimage.Image))
            {
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y - 50), new Point(startpoint.X + 100, startpoint.Y - 50));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y - 50), new Point(startpoint.X - 50, startpoint.Y + 50));
                g.DrawLine(l, new Point(startpoint.X - 50, startpoint.Y + 50), new Point(startpoint.X + 100, startpoint.Y + 50));
                g.DrawLine(l, new Point(startpoint.X + 100, startpoint.Y - 50), new Point(startpoint.X + 100, startpoint.Y + 50));
                mapimage.Refresh();
            }
        }

        private void drawareaPRI(Point startp)
        {
            Point startpoint = new Point(getdrawpos(startp).X, getdrawpos(startp).Y);
            using (var g = Graphics.FromImage(mapimage.Image))
            {
                g.DrawImage(soil, new Point(startpoint.X, startpoint.Y));
                g.DrawImage(soil, new Point(startpoint.X-50, startpoint.Y));
                g.DrawImage(soil, new Point(startpoint.X - 50, startpoint.Y-50));
                g.DrawImage(soil, new Point(startpoint.X, startpoint.Y - 50));
                g.DrawImage(soil, new Point(startpoint.X+50, startpoint.Y - 50));
                mapimage.Refresh();
            }
        }
    }
}
