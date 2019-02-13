using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace markettest
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern long mouse_event(Int32 dwFlags, Int32 dx, Int32 dy, Int32 cButtons, Int32 dwExtraInfo);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern void SetCursorPos(Int32 x, Int32 y);

        public const Int32 MOUSEEVENTF_ABSOLUTE = 0x8000;
        public const Int32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        public const Int32 MOUSEEVENTF_LEFTUP = 0x0004;
        public const Int32 MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        public const Int32 MOUSEEVENTF_MIDDLEUP = 0x0040;
        public const Int32 MOUSEEVENTF_MOVE = 0x0001;
        public const Int32 MOUSEEVENTF_RIGHTDOWN = 0x0008;
        public const Int32 MOUSEEVENTF_RIGHTUP = 0x0010;
        public const Int32 MOUSEEVENTF_WHEEL = 0x020A;


        public static void Performscrolldown(Int32 x, Int32 y)
        {
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_WHEEL, 0, 0, -120, 0);
        }

        public static void PerformLeftclick(Int32 x, Int32 y)
        {
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0);
        }

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

        public Form1()
        {
            
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 13, 13));

        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        public class ScreenCapture
        {
            [DllImport("user32.dll")]
            private static extern IntPtr GetForegroundWindow();

            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            public static extern IntPtr GetDesktopWindow();
            public static Point pbasic;

            [StructLayout(LayoutKind.Sequential)]
            private struct Rect
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }

            [DllImport("user32.dll")]
            private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

            public static Image CaptureDesktop(Point p)
            {
                return CaptureWindow(GetDesktopWindow(),p);
            }

            public static Bitmap CaptureActiveWindow()
            {
                return CaptureWindow(GetForegroundWindow(), pbasic);
            }

            public static Bitmap CaptureWindow(IntPtr handle,Point P)
            {
                var rect = new Rect();
                GetWindowRect(handle, ref rect);
                //var bounds = new Rectangle(0, 0, 17, 21);
                var bounds = new Rectangle(0, 0, 82, 48);
                var result = new Bitmap(bounds.Width, bounds.Height);

                using (var graphics = Graphics.FromImage(result))
                {
                    graphics.CopyFromScreen(new Point(P.X, P.Y), Point.Empty, bounds.Size);
                }

                return result;
            }
        }
        
        public void SearchItem(int min, int max, int j){
            Point k;
            int i=min;
            //var image = (Bitmap)ScreenCapture.CaptureDesktop(new Point(37, 140));
            //Bitmap image2 = (Bitmap)grayscale(image);
            do
            {
                var image = (Bitmap)ScreenCapture.CaptureDesktop(new Point(18, 93));
                Bitmap image2 = (Bitmap)grayscale(image);
                pictureBox1.Image = image2;
                var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
                var page = ocr.Process(image2);
                buylist.AppendText(page.GetText());
                pictureBox1.Image = image2;

            } while (false);
            
         
        }

        private void startbtn_Click(object sender, EventArgs e)
        {

            SearchItem(Convert.ToInt32(priceboxmin.Text), Convert.ToInt32(priceboxmax.Text), 1);
            startbtn.Visible = false;
            stopbtn.Visible = true;
            priceboxmin.Enabled = false;

        }

        private void stopbtn_Click(object sender, EventArgs e)
        {
            startbtn.Visible = true;
            stopbtn.Visible = false;
            priceboxmin.Enabled = true;
        }

        private static bool IsInnerImage(Bitmap searchBitmap, Bitmap withinBitmap, int left, int top)
        {
            for (int y = top; y < top + withinBitmap.Height; y++)
            {
                for (int x = left; x < left + withinBitmap.Width; x++)
                {
                    if (searchBitmap.GetPixel(x, y) != withinBitmap.GetPixel(x - left, y - top))
                        return false;
                }
            }

            return true;
        }

        private static bool FindBitmap(Bitmap searchBitmap, Bitmap withinBitmap, out Point point)
        {
            Color innerTopLeft = withinBitmap.GetPixel(0, 0);

            for (int y = 0; y < searchBitmap.Height - withinBitmap.Height; y++)
            {
                for (int x = 0; x < searchBitmap.Width - withinBitmap.Width; x++)
                {
                    Color clr = searchBitmap.GetPixel(x, y);
                    if (innerTopLeft == clr && IsInnerImage(searchBitmap, withinBitmap, x, y))
                    {
                        point = new Point(x, y); // Top left corner of the inner bitmap in searchBitmap - coordinates
                        return true;
                    }
                }
            }

            point = Point.Empty;
            return false;
        }

        private Bitmap grayscale(Bitmap bmp)
        {

            //get image dimension
            int width = bmp.Width;
            int height = bmp.Height;

            //color of pixel
            Color p;

            //grayscale
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    p = bmp.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //find average
                    int avg = (r + g + b) / 3;

                    //set new pixel value
                    bmp.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                }
            }
            return bmp;
            //load grayscale image in picturebox2
            }


        }
    }
