﻿using System;
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
        const int FIRST_TYPE_BALLS_COUNT = 150;

        static Random R = new Random();
        List<Ball> BallsList;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.Black;
            StartGen();
        }

        public void StartGen()
        {
            BallsList = new List<Ball>();
            for (int i = 0; i < FIRST_TYPE_BALLS_COUNT; i++)
            {
                BallsList.Add(new Ball(Brushes.Red, 10, R.Next(pictureBox1.Width), R.Next(pictureBox1.Height)));
            }
        }

        public void Update()
        {
            Bitmap BitMap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics G = Graphics.FromImage(BitMap);

            foreach (Ball b in BallsList) b.Print(G);

            pictureBox1.Image = BitMap;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Update();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                StartGen();
        }
    }
}
