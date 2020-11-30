using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Forms.VisualStyles;
using System.Windows.Media;

namespace NyHitBoxTest.Class
{
    class Rope
    {
        public Line _myLine;
        public Rope()
        {
        //_myLine = new Line();

        }

        // Add a Line Element
        public void drawLine(){
        //_myLine.Stroke = Brushes.LightSteelBlue;
        //_myLine.X1 = 1;
        //_myLine.X2 = 50;
        //_myLine.Y1 = 1;
        //_myLine.Y2 = 50;
        ////_myLine.HorizontalAlignment = HorizontalAlignment.Left;
        ////_myLine.VerticalAlignment = VerticalAlignment.Center;
        //_myLine.StrokeThickness = 2;
        }

        public Line returnRope()
        {
            return _myLine;
        }
        }
    }
