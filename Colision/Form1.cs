using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Colision
{
    public partial class Form1 : Form
    {
        private Bitmap bmp;
        private Graphics g;
        private int ballWidth = 50;
        private int ballHeight = 50;
        private int moveStepX = 4;
        private int moveStepY = 4;
        private int n = 5;
        private List<Pelota> Pelotas = new List<Pelota>();
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            for (int i = 0; i < n; i++)
            {
                int rn1 = random.Next(10, 20);
                int ballPosy = random.Next(0, 100);
                int ballPosx = random.Next(0, 100);
                Pelota newPelota = new Pelota(new Size(rn1, rn1), new Point(ballPosx, ballPosy));
                Pelotas.Add(newPelota);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.Black);
            foreach (Pelota pelota in Pelotas)
            {
                g.FillEllipse(Brushes.Red, pelota.Location.X, pelota.Location.Y, pelota.Size.Width, pelota.Size.Height);
                g.DrawEllipse(Pens.Black, pelota.Location.X, pelota.Location.Y, pelota.Size.Width, pelota.Size.Height);
                pelota.Update();
            }
            MoveBalls();
            pictureBox1.Invalidate();
        }

        private void MoveBalls()
        {
            foreach (Pelota pelota in Pelotas)
            {
                int ballPosx = pelota.Location.X;
                int ballPosy = pelota.Location.Y;
                ballPosx += moveStepX;
                if (ballPosx < 0 || ballPosx + pelota.Size.Width > pictureBox1.ClientSize.Width)
                {
                    moveStepX = -moveStepX;
                }
                ballPosy += moveStepY;
                if (ballPosy < 0 || ballPosy + pelota.Size.Height > pictureBox1.ClientSize.Height)
                {
                    moveStepY = -moveStepY;
                }
                pelota.Location = new Point(ballPosx, ballPosy);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PaintCircle (object sender, EventArgs e)
        {

        }
    }
}