using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParticlSim
{
    public partial class Form1 : Form
    {
        const int RED_TYPE_BALLS_COUNT = 30;
        const int GREEN_TYPE_BALLS_COUNT = 30;
        const float FORSE = 1;
        const float HighFORCE = 6;

        static Random R = new Random();
        List<Ball> RedBallsList, GreenBallsList;
        Ball B1, B2;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.Black;
            StartGen();
        }

        public void StartGen()
        {
            RedBallsList = new List<Ball>();
            for (int i = 0; i < RED_TYPE_BALLS_COUNT; i++)
            {
                RedBallsList.Add(new Ball(Brushes.Red, 10, R.Next(pictureBox1.Width), R.Next(pictureBox1.Height)));
            }

            GreenBallsList = new List<Ball>();
            for (int i = 0; i < GREEN_TYPE_BALLS_COUNT; i++)
            {
                GreenBallsList.Add(new Ball(Brushes.Green, 10, R.Next(pictureBox1.Width), R.Next(pictureBox1.Height)));
            }
        }

        public void UpdatePrint()
        {
            Bitmap BitMap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics G = Graphics.FromImage(BitMap);

            foreach (Ball b in RedBallsList) b.Print(G);
            foreach (Ball b in GreenBallsList) b.Print(G);

            pictureBox1.Image = BitMap;
        }
        public void UpdateLogic()
        {
            for (int i = 0; i < RedBallsList.Count(); i++)
            {
                for (int j = 0; j < RedBallsList.Count(); j++)
                   Rule(RedBallsList[i], RedBallsList[j], FORSE);
            }

        }

        public void Rule(Ball A, Ball B, float g = 4)
        {
            float fx = 0, fy = 0, F = 0, d = 0, dx = 0, dy =0;

            dx = B.X - A.X;
            dy = B.Y - A.Y;

            d = (float)Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
            if (d > 0) // Можно ограничить расстояние взаимодействия
            {
                F = g * (1 / (float)Math.Pow(d, 2));
                fx += F * dx;
                fy += F * dy;
            }
            A.vx = A.vx + fx;
            A.vy = A.vy + fy;

            if (A.vx < float.MinValue) A.vx = float.MinValue;
            if (A.vx > float.MaxValue) A.vx = float.MaxValue;
            if (A.vy < float.MinValue) A.vy = float.MinValue;
            if (A.vy > float.MaxValue) A.vy = float.MaxValue;

            A.X += A.vx * 0.5f;
            A.Y += A.vy * 0.5f;

            if (A.X < 20 || A.X > pictureBox1.Width - 20) A.vx *= -1;
            if (A.Y < 20 || A.Y > pictureBox1.Height - 20) A.vy *= -1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateLogic();
            UpdatePrint();
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                StartGen();
                GC.Collect();
            }
        }
    }
}
