using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    class Plants
    {
        public eat[] food;
        public int countfood = 200;

        public void Createfirstfood(int col, int r)
        {
            food = new eat[countfood];
            Random random = new Random();
            for (int i = 0; i < countfood; i++)
            {
                eat test = new eat
                {
                    x = random.Next(col),
                    y = random.Next(r),
                    columns = col,
                    rows = r

                };
                food[i] = test;
            }
        }
    }
}
