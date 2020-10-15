using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    class populationgroup
    {
        public unit[] populations;
        public int countofp = 200;

        public void Createfirstgen(int col, int r)
        {
            populations = new unit[countofp];
            Random random = new Random();
            for (int i = 0; i < countofp; i++)
            {

                unit test = new unit
                {
                    x = random.Next(col),
                    y = random.Next(r),
                    columns = col,
                    rows = r,
                    health = 1000

                };
                populations[i] = test;

            }
        }

        public void NewStepPop(eat[] food)
        {
            Random rand = new Random();
            for (int i = 0; i < countofp; i++)
            {
                int g = rand.Next(4);
                populations[i].health--;
                populations[i].CheckForFood(food, countofp);
                populations[i].DecidToMove(food, countofp, g);

            }
        }
        /*
        public bool SearchXY(int x, int y)
        {
            for (int i = 0; i < countofp; i++)
            {
                if (x == populations[i].x && y == populations[i].y)
                    return true;
            }
            return false;
        }*/
    }
}
