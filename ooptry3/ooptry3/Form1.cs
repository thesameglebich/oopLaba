using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ooptry3
{
   
    public partial class Form1 : Form
    {
        public Graphics graphics;
        public int resolution;
        public Runner runx;
        public int con = 0;
        public Form1()
        {
            InitializeComponent();
        }

     /*   public void DrawMap()
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
        }*/

        private void StartGame()
        {
            if (timer1.Enabled)
                return;
            nudResolution.Enabled = false;
            nudDensity.Enabled = false;
            runx = new Runner();
            runx.InitializeValue();
            resolution = (int)nudResolution.Value;
            runx.rows= pictureBox1.Height / resolution;
            runx.columns= pictureBox1.Width /resolution;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            runx.Createfirstfood();
            runx.Createfirstgen();
            timer1.Start();
            
        }

        private void DrawNewMap()
        {
            graphics.Clear(Color.Green);
            for (int i = 0; i < runx.countofp; i++)
            {
                graphics.FillRectangle(Brushes.Black, runx.populations[i].x * resolution, runx.populations[i].y * resolution, resolution, resolution);
                graphics.FillRectangle(Brushes.Blue, runx.food2[i].x * resolution, runx.food2[i].y * resolution, resolution, resolution);
            }
            
            pictureBox1.Refresh();

        }

        private void NextGen()
        {
            /*
            DrawNewMap();
            runx.DecideToMove();*/
            Random rand = new Random();
            graphics.Clear(Color.Green);
            for (int i = 0; i < runx.countofp; i++)
            {
                int g = rand.Next(4);
                runx.populations[i].health--;
                runx.Checkforit(runx.populations[i]);
                graphics.FillRectangle(Brushes.Black, runx.populations[i].x * resolution, runx.populations[i].y * resolution, resolution, resolution);
                graphics.FillRectangle(Brushes.Blue, runx.food2[i].x * resolution, runx.food2[i].y * resolution, resolution, resolution);
                if (runx.populations[i].health < 400)
                {
                    if (runx.populations[i].found == false)
                    {
                        runx.populations[i].FindClose(runx);
                        runx.populations[i].found = true;
                    }
                    runx.populations[i].Idontwannadie();

                }
                else
                {

                    runx.populations[i].Move(g);
                }
            }
            pictureBox1.Refresh();
        }

      
        private void timer1_Tick(object sender, EventArgs e)
        {
            NextGen();
        }

        private void strartb_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void stopb_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                return;
            timer1.Stop();
            nudDensity.Enabled = true;
            nudResolution.Enabled = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!timer1.Enabled)
                return;
            if (e.Button == MouseButtons.Left)
            {
                var x2 = e.Location.X / resolution;
                var y2 = e.Location.Y / resolution;
                for (int i = 0; i < runx.countofp; i++)
                {
                    if (x2 == runx.populations[i].x && y2 == runx.populations[i].y)
                        label3.Text = $"health:{runx.populations[i].health}";
                }
            }
        }
    }

    public class food
    {
        public int x, y, rows, columns;

        public void Createeat(int rand1, int rand2)
        {
            this.x = rand1;
            this.y = rand2;
        }

    }
}
