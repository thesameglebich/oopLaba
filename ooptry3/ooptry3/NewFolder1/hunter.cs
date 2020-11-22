using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    class hunter : organisms<herbivorous>
    {
        public int huntersteps = -1;
        public int typeforhunt = 0;

       

        public override void makepair(entity el2, Random rand)
        {
            this.pair = ((hunter)el2).pair = true;
            this.tochka.x = ((hunter)el2).tochka.x = (this.x + el2.x) / 2;
            this.tochka.y = ((hunter)el2).tochka.y = (this.y + el2.y) / 2;
            this.index = ((hunter)el2).index = rand.Next(1000);
        }

        public void FindVictim()
        {
            this.closeX = this.x + this.huntersteps;
            if (this.huntersteps % 2 == 0)
                this.closeY = this.y + 10;
            else this.closeY = this.y - 10;
            if (this.closeX < 0)
                this.closeX = this.closeX + 20;
            if (this.closeX >= columns)
                this.closeX = this.closeX - 20;
            if (this.closeY < 0)
                this.closeY = this.closeY + 20;
            if (this.closeY >= rows)
                this.closeY = this.closeY - 20;

        }

        public override void MakeChild(List<entity> popul, List<entity> entnew)
        {

            IEnumerable<hunter> hunt = popul.OfType<hunter>();
            foreach (hunter el2 in hunt)
            {
                if (el2.index == this.index)
                {
                    if (this.x == el2.x && this.y == el2.y)
                    {
                        Random random = new Random();
                        this.timer = 0;
                        el2.timer = 0;
                        this.pair = false;
                        el2.pair = false;
                        int typeunit = random.Next(3);
                        CreateChildren(typeunit, random, entnew);

                    }
                }

            }


        }
    }
}