using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NyHitBoxTest.Class
{
    class Line
    {
        private int _x1;
        private int _x2;
        private int _y1;
        private int _y2;
        private Font fnt = new Font("Arial", 10);

        public Line(int x1, int x2, int y1, int y2)
        {
            //_boxCanvas = x;
            _x1 = x1;
            _x2 = x2;
            _y1 = y1;
            _y2 = y2;
        }

        public void PaintLine(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Create a local version of the graphics object for the PictureBox.
            Graphics g = e.Graphics;

            // Draw a string on the PictureBox.
            //g.DrawString("This is a diagonal line drawn on the control",
            //    fnt, System.Drawing.Brushes.Blue, new Point(30, 30));
            // Draw a line in the PictureBox.
            g.DrawLine(System.Drawing.Pens.Red, _x1, _y1,
                _x2, _y2);
        }
    }
}
