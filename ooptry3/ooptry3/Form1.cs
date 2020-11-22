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
        public int sch = 1;

        public Form1()
        {
            InitializeComponent();
            run = new Runner(this);
        }

        Runner run;
        

        public void InicializeValue()
        {
            resolution = (int)nudResolution.Value;
            // rows = pictureBox1.Height / resolution;
            //columns = pictureBox1.Width / resolution;
            rows = 1000;
            columns = 1000;
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


        public void DrawMap(List<entity> popul)
        {
            if ((sch / 500) % 2 == 0)
            {
                graphics.Clear(Color.Green);
            }
            else graphics.Clear(Color.White);

            for (int i = 0; i < popul.Count; i++)
            {
                if (popul[i].health < 200)
                {
                    if (popul[i] is herbivorous)
                        graphics.FillRectangle(Brushes.Red, popul[i].x * resolution, popul[i].y * resolution, resolution, resolution);
                    if (popul[i] is hunter)
                        graphics.FillRectangle(Brushes.Gold, popul[i].x * resolution, popul[i].y * resolution, resolution, resolution);
                    if (popul[i] is omnivorous)
                        graphics.FillRectangle(Brushes.Brown, popul[i].x * resolution, popul[i].y * resolution, resolution, resolution);
                }
                else
                {
                    if (popul[i].pair == true)
                        graphics.FillRectangle(Brushes.Violet, popul[i].x * resolution, popul[i].y * resolution, resolution, resolution);
                    else if (!(popul[i] is eat)) graphics.FillRectangle(Brushes.Black, popul[i].x * resolution, popul[i].y * resolution, resolution, resolution);
                    else graphics.FillRectangle(Brushes.Blue, popul[i].x * resolution, popul[i].y * resolution, resolution, resolution);
                }
                
               
            }

       
            pictureBox1.Refresh();
        }

   

        private void timer1_Tick(object sender, EventArgs e)
        {
            run.CreateNewWorld();
            label4.Text = $"{sch++}";
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
                for (int i = 0; i < run.population.popul.Count; i++)
                {
                    if (x2 == run.population.popul[i].x && y2 == run.population.popul[i].y)
                    {
                        // label3.Text = $"health:{run.population.popul[i].health} Pair:{run.population.popul[i].pair}";
                        //label5.Text = $"timer:{run.population.popul[i].timer}";
                        if (run.population.popul[i] is omnivorous)
                        label3.Text = ((omnivorous)run.population.popul[i]).Information();
                        if (run.population.popul[i] is herbivorous)
                            label3.Text = ((herbivorous)run.population.popul[i]).Information();
                        if (run.population.popul[i] is hunter)
                            label3.Text = ((hunter)run.population.popul[i]).Information();
                    }
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                var x2 = e.Location.X / resolution;
                var y2 = e.Location.Y / resolution;
                timer1.Stop();
                run.population.DeleteLocation(x2, y2);
                for (int i =x2-run.population.deadradius;i<x2+ run.population.deadradius; i++)
                    for(int j = y2- run.population.deadradius; j <  y2+ run.population.deadradius; j++)
                    {
                        graphics.FillRectangle(Brushes.Orange, i * resolution, j * resolution, resolution, resolution);
                    }
                pictureBox1.Refresh();

                timer1.Start();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }


}
