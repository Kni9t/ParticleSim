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
        const int FIRST_TYPE_BALLS_COUNT = 2;

        static Random R = new Random();
        List<Ball> RedBallsList;
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
            for (int i = 0; i < FIRST_TYPE_BALLS_COUNT; i++)
            {
                RedBallsList.Add(new Ball(Brushes.Red, 10, R.Next(pictureBox1.Width), R.Next(pictureBox1.Height)));
            }
        }

        public void UpdatePrint()
        {
            Bitmap BitMap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics G = Graphics.FromImage(BitMap);

            foreach (Ball b in RedBallsList) b.Print(G);

            pictureBox1.Image = BitMap;
        }
        public void UpdateLogic()
        {
            for (int i = 0; i < RedBallsList.Count(); i++)
            {
                Rule(RedBallsList[0], RedBallsList[1]);
            }
        }

        public void Rule(Ball A, Ball B, double g = 6)
        {
            double fx = 0, fy = 0, F = 0,
            dx = A.X - B.X, dy = A.Y - B.Y,
            d = Math.Sqrt(dx * dx + dy * dy);
            if (d > 0)
            {
                F = g * (1 / d);
                fx += (F * dx);
                fy += (F * dy);
            }
            B.X += (int)fx;
            B.Y += (int)fy;
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
