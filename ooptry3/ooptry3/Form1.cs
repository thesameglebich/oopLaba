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
        private bool[,] field;
        private int rows;
        private int columns;
        public Form1()
        {
            InitializeComponent();
        }
        private void StartGame()
        {
            if (timer1.Enabled)
                return;
            nudResolution.Enabled = false;
            nudDensity.Enabled = false;
            resolution = (int)nudResolution.Value;
            rows = pictureBox1.Height / resolution;
            columns = pictureBox1.Width / resolution;
            field = new bool[columns, rows];
            Random random = new Random();
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    field[i, j] = random.Next((int)nudDensity.Value) == 0;
                }
            }


            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            timer1.Start();


        }

        private void NextGen()
        {
            var pole = new bool[columns, rows];

            graphics.Clear(Color.Green);
            Random rand = new Random();
            for (int i = 0; i < columns; i++)
            {   
                for (int j = 0; j < rows; j++)
                { 
                    if (field[i, j])
                    {
                        graphics.FillRectangle(Brushes.Black, i * resolution, j * resolution, resolution, resolution);
                    }

                   
                   // while (!flagmain)
                   // {
                        int v = rand.Next(4);
                        int num = v;
                        var flag = field[i, j];

                        if ((num == 0) && flag)// && ())
                        {
                        if (j - 1 >= 0)
                        {

                            if ((!pole[i, j - 1]))
                            {
                                pole[i, j - 1] = true;

                            }
                            else pole[i, j] = true;

                        }
                        else pole[i,j]=true;

                        }

                        if ((num == 1) && flag)// && ())
                        {
                        if (j + 1 < rows)
                        {
                            if ((!pole[i, j + 1]))
                                pole[i, j + 1] = true;
                            else pole[i, j] = true;
                        }
                        else pole[i, j] = true;
                           
                        }
                        if ((num == 2) && flag)// && ())
                        {
                        if (i - 1 >= 0)
                        {
                            if ((!pole[i - 1, j]))
                                pole[i - 1, j] = true;
                            else pole[i, j] = true;
                        }
                        else pole[i, j]=true;
                         
                        }
                        if ((num == 3) && flag)// && ())
                        {
                        if (i + 1 < columns)
                        {
                            if (!pole[i + 1, j])
                                pole[i + 1, j] = true;
                            else pole[i, j] = true;
                        }
                        else pole[i, j] = true;
                            
                        }
                   // }

                   
                }
            }
            field = pole;
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
    }
}
