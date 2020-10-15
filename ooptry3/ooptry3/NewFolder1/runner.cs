using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    public class Runner
    {
       
        public unit[] populations;
        public int countofp;
        public food[] food2;
        public int countfood;
        public int rows;
        public int columns;

        public void InitializeValue()
        {
            countofp = 200;
            countfood = 200;
            populations = new unit[countofp];
            food2 = new food[countfood];
        }

        public void Createfirstfood()
        {
            Random random = new Random();
            for (int i = 0; i < this.countfood; i++)
            {
                food test = new food
                {
                    x = random.Next(this.columns),
                    y = random.Next(this.rows),
                    columns = this.columns,
                    rows = this.rows

                };
                this.food2[i] = test;
            }
        }

        public void Createfirstgen()
        {
            Random random = new Random();
            for (int i = 0; i < this.countofp; i++)
            {

                unit test = new unit
                {
                    x = random.Next(this.columns),
                    y = random.Next(this.rows),
                    columns = this.columns,
                    rows = this.rows,
                    health = 1000

                };
                this.populations[i] = test;

            }
        }

        public void Checkforit(unit t)
        {
            Random rand = new Random();
            for (int i = 0; i < countfood; i++)
            {
                if (t.x == food2[i].x && t.y == food2[i].y && t.health != 1000)
                {
                    t.health = 1000;
                    food2[i].Createeat(rand.Next(t.columns), rand.Next(t.rows));
                }
            }
        }
        public void DecideToMove()
        {
            Random rand = new Random();
            for (int i = 0; i < this.countofp; i++)
            {
                int g = rand.Next(4);
                this.populations[i].health--;
                this.Checkforit(this.populations[i]);

                if (this.populations[i].health < 400)
                {
                    if (this.populations[i].found == false)
                    {
                        this.populations[i].FindClose(this);
                        this.populations[i].found = true;
                    }
                    this.populations[i].Idontwannadie();

                }
                else
                {
                    this.populations[i].Move(g);
                }
            }
        }

    }
}
