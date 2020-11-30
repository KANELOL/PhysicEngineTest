using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NyHitBoxTest.Class.LineFolder
{

    class LineBox
    {
        public PictureBox backgroundLine = new PictureBox();

        // Dock the PictureBox to the form and set its background to white.
        public LineBox(int width, int height, int x, int y)
        {
            //backgroundLine.Dock = DockStyle.Fill;
            backgroundLine.BackColor = Color.White;
            backgroundLine.Width = width;
            backgroundLine.Height = height;
            backgroundLine.Top = y;
            backgroundLine.Left = x;
            
        }

        public void Spawn()
        {
            Form1.form1.Controls.Add(backgroundLine);
        }

        public void Remove()
        {
            Form1.form1.Controls.Remove(backgroundLine);
        }

        public void drawLine()
        {
            Line line = new Line(backgroundLine.Width / 2, 100, backgroundLine.Height / 2, 60);
            // Connect the Paint event of the PictureBox to the event handler method.
            backgroundLine.Paint += (line.PaintLine);
        }
    }
}
