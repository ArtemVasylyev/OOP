using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Lab_9 
{
    public partial class Form1 : Form
    {
        private double x0 = 0, y0 = 0, R = 100;
        private bool canDraw = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {

            double.TryParse(txtX0.Text, out x0);
            double.TryParse(txtY0.Text, out y0);
            double.TryParse(txtR.Text, out R);

            canDraw = true;
            pictureBox1.Invalidate(); 
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (!canDraw) return;

            Graphics g = e.Graphics; 
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int cx = pictureBox1.Width / 2;
            int cy = pictureBox1.Height / 2;


            Pen blackPen = new Pen(Color.Black, 1);
            g.DrawLine(blackPen, 0, cy, pictureBox1.Width, cy); 
            g.DrawLine(blackPen, cx, 0, cx, pictureBox1.Height); 


            Pen redPen = new Pen(Color.Red, 2);
            PointF? prev = null;

            for (double t = 0; t <= Math.PI * 2; t += 0.05)
            {

                double x = x0 + R * Math.Cos(t);
                double y = y0 + R * Math.Sin(t);

                float sx = cx + (float)x;
                float sy = cy - (float)y;

                PointF current = new PointF(sx, sy);
                if (prev != null) g.DrawLine(redPen, prev.Value, current);
                prev = current;
            }
        }
    }
}