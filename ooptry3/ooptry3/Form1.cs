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
        private Graphics graphics;
        private int resolution;
       
        public int rows;
        public int columns;


        public Form1()
        {
            InitializeComponent();
            run = new Runner(this);
        }

        Runner run;

        public void InicializeValue()
        {
            resolution = (int)nudResolution.Value;
            rows = pictureBox1.Height / resolution;
            columns = pictureBox1.Width / resolution;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
        }
        public void StartGame()
        {
            if (timer1.Enabled)
                return;
            nudResolution.Enabled = false;
            nudDensity.Enabled = false;
            run.CreateMyWorld();
            timer1.Start();
            
        }

    
        public void DrawMap(unit[] populations,eat[] food, int countofp)
        {
            graphics.Clear(Color.Green);
            for (int i = 0; i < countofp; i++)
            {
               // graphics.FillRectangle(Brushes.Black, populations[i].x * resolution, populations[i].y * resolution, resolution, resolution);
                graphics.FillRectangle(Brushes.Blue, food[i].x * resolution, food[i].y * resolution, resolution, resolution);
            }
            
           

            pictureBox1.Refresh();
        }

   

        private void timer1_Tick(object sender, EventArgs e)
        {
            run.CreateNewWorld();
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
               /* for (int i = 0; i < countofp; i++)
                {
                    if (x2 == populations[i].x && y2 == populations[i].y)
                        label3.Text = $"health:{populations[i].health}";
                }*/
            }
        }
    }


}
