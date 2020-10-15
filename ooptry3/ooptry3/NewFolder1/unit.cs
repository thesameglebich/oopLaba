using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    public class unit
    {
        public int x, y, health;
        public int rows, columns;
        public int closeX, closeY;
        public bool found = false;

   
        public void Move(int num)
        {



            if (num == 0)
                Move0();
            if (num == 1)
                Move1();
            if (num == 2)
                Move2();
            if (num == 3)
                Move3();
        }

        public void Move0()
        {
            if (this.y - 1 >= 0)
            {
                this.y = this.y - 1;
            }

        }

        public void Move1()
        {
            if (this.y + 1 < rows)
                this.y = this.y + 1;
        }

        public void Move2()
        {
            if (this.x - 1 > 0)
                this.x = this.x - 1;
        }

        public void Move3()
        {
            if (this.x + 1 < columns)
                this.x = this.x + 1;
        }

        public void FindClose(Runner runx)
        {
            int min = 1000000000;
            for (int i = 0; i < runx.countfood; i++)
            {
                if (((this.x - runx.food2[i].x) * (this.x - runx.food2[i].x) + (this.y - runx.food2[i].y) * (this.y - runx.food2[i].y)) < min)
                {
                    min = (this.x - runx.food2[i].x) * (this.x - runx.food2[i].x) + (this.y - runx.food2[i].y) * (this.y - runx.food2[i].y);
                    this.closeX = runx.food2[i].x;
                    this.closeY = runx.food2[i].y;
                }

            }
        }

        public void Idontwannadie()
        {
            int nstepX = this.closeX - this.x;
            int nstepY = this.closeY - this.y;
            if (nstepX == 0 && nstepY == 0)
                this.found = false;
            else
            {
                if (Math.Abs(nstepY) >= Math.Abs(nstepX))
                {
                    if (nstepY > 0)
                        this.y++;
                    else this.y--;
                }
                else
                {
                    if (nstepX > 0)
                        this.x++;
                    else this.x--;
                }
            }

        }

  
    }

}
