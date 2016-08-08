using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices; 
using System.Text;
using System.Windows.Forms;

namespace RangeFinder
{
    public partial class RangeFinderOverlay : Form
    {
        #region Form Dragging API Support

        //The SendMessage function sends a message to a window or windows. 
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        //ReleaseCapture releases a mouse capture 
        [DllImportAttribute("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern bool ReleaseCapture();

        #endregion 

        #region Properties

        public int PixelsInInch
        { get; set; }

        public int InchesToDraw
        { get; set; }

        #endregion

        #region Constructor

        public RangeFinderOverlay()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// When the form is first loaded, this sets the initial parameters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RangeFinderOverlay_Load(object sender, EventArgs e)
        {
            this.PixelsInInch = int.Parse(ConfigurationSettings.AppSettings["PixelsInInch"]);
            this.InchesToDraw = int.Parse(ConfigurationSettings.AppSettings["InchesToDraw"]);

            this.Width = (2 * PixelsInInch * InchesToDraw) + 2;
            this.Height = (2 * PixelsInInch * InchesToDraw) + 2;

            panHandle.Left = (Width / 2) + PixelsInInch;
            panHandle.Top = (Width / 2) + PixelsInInch;
        }

        /// <summary>
        /// This draws the actual ranges
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RangeFinderOverlay_Paint(object sender, PaintEventArgs e)
        {
            int centerX = PixelsInInch * InchesToDraw;
            int centerY = PixelsInInch * InchesToDraw;

            // Get the graphics object 
            Graphics gfx = e.Graphics;

            // Create a new pen that we shall use for drawing the line 
            Pen mainPen = new Pen(Color.Lime);
            Pen secondaryPen = new Pen(Color.Gray);

            // Draw circles marking the distance from the center in 1 inch increments
            for (int i = 3; i <= 12; i++)
            {
                Pen pen;
                if (i % 2 == 0)
                    pen = mainPen;
                else
                    pen = secondaryPen;

                gfx.DrawEllipse(pen, centerX - (i * PixelsInInch), centerY - (i * PixelsInInch), i * PixelsInInch * 2, i * PixelsInInch * 2);
            }

            // Draw 4 lines to point to the center
            gfx.DrawLine(mainPen, new Point(centerX, centerY + 3), new Point(centerX, centerY + 10));
            gfx.DrawLine(mainPen, new Point(centerX + 3, centerY), new Point(centerX + 10, centerY));
            gfx.DrawLine(mainPen, new Point(centerX, centerY - 3), new Point(centerX, centerY - 10));
            gfx.DrawLine(mainPen, new Point(centerX - 3, centerY), new Point(centerX - 10, centerY));

            //Draw the center dot
            Bitmap bm = new Bitmap(1,1);
            bm.SetPixel(0, 0, mainPen.Color);
            gfx.DrawImageUnscaled(bm,centerX, centerY);

            //Draw the range numbers
            Font font = new Font("Verdana", 10, FontStyle.Bold, GraphicsUnit.Point);
            int spacing = -3;

            for (int i = 3; i <= 12; i++)
            {
                if (i % 2 == 0)
                {
                    SizeF size = gfx.MeasureString(i.ToString(), font);
                    int dist = (int)(Math.Ceiling(Math.Sqrt((i * PixelsInInch) * (i * PixelsInInch) / 2)));

                    gfx.DrawString(i.ToString(), font, Brushes.Lime, centerX + dist + spacing, centerY - dist - size.Height - spacing);
                    gfx.DrawString(i.ToString(), font, Brushes.Lime, centerX - dist - size.Width - spacing, centerY + dist + spacing);
                }
            }            
        }

        /// <summary>
        /// This moves the overlay around the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panHandle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xa1, 0x2, 0);
            } 
        }

        /// <summary>
        /// This handles commands that the user gives to the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panHandle_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
                this.Dispose();
            else if (e.Button == MouseButtons.Right)
                WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Private Methods



        #endregion
    }
}
