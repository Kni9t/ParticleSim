using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ParticlSim
{
    public class Ball
    {
        Brush Color;
        public int X, Y, Size;

        public Ball(Brush Color, int Size, int X = 50, int Y = 50)
        {
            this.Color = Color;
            this.Size = Size;
            this.X = X;
            this.Y = Y;
        }

        public void Print(Graphics G)
        {
            G.FillEllipse(Color, X - Size/2, Y - Size / 2, Size, Size);
        }
    }
}
