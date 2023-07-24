using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Particle
{
    class Ball
    {
        Ellipse Body;
        public Ball(Brush Color, double Size = 8)
        {
            Body = new Ellipse();
            Body.Height = 8;
            Body.Width = Body.Height;
            Body.Fill = Color;
        }
    }
}
