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
        public int X, Y;

        int PointX, PointY, Size;

        public Ball(Brush Color, int Size, int PointX = 50, int PointY = 50)
        {
            this.Color = Color;
            this.Size = Size;
            this.PointX = PointX;
            this.PointY = PointY;
            X = PointX + Size / 2;
            Y = PointY + Size / 2;
        }

        public void Print(Graphics G)
        {
            G.FillEllipse(Color, PointX, PointY, Size, Size);
        }
    }
}
