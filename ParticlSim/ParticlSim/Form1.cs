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
        const int RED_TYPE_BALLS_COUNT = 3;
        const int GREEN_TYPE_BALLS_COUNT = 2;
        const double FORSE = 1.5;

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

        public void Rule(Ball A, Ball B, double g = 4)
        {
            double fx = 0, fy = 0, F = 0, d = 0;

            d = Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
            if (d > 0)
            {
                F = g * (1 / d);
                fx += (F * (B.X - A.X));
                fy += (F * (B.Y - A.Y));
            }
            A.vx = A.vx + (int)fx;
            A.vy = A.vy + (int)fy;

            //B.vx = B.vx + (int)fx;
            //B.vy = B.vy + (int)fy;

            A.X += A.vx;
            A.Y += A.vy;

            //B.X -= B.vx;
            //B.Y -= B.vy;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateLogic();
            UpdatePrint();
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                StartGen();
        }
    }
}
