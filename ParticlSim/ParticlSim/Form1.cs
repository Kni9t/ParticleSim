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
        static Random R = new Random();
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.Black;
            Ball b = new Ball(Brushes.Red, 10, R.Next(pictureBox1.Width), R.Next(pictureBox1.Height));

            Bitmap BitMap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics G = Graphics.FromImage(BitMap);

            b.Print(G);

            pictureBox1.Image = BitMap;
        }
    }
}
