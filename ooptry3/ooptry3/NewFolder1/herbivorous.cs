using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    public class herbivorous: organisms<eat>, foodhunt, foodomni
    {
        

        public override void makepair(entity el2, Random rand)
        {
            this.pair = ((herbivorous)el2).pair = true;
            this.tochka.x = ((herbivorous)el2).tochka.x = (this.x + el2.x) / 2;
            this.tochka.y = ((herbivorous)el2).tochka.y = (this.y + el2.y) / 2;
            this.index = ((herbivorous)el2).index = rand.Next(1000);
        }

        public override void MakeChild(List<entity> popul, List<entity> entnew)
        {
            
            IEnumerable<herbivorous> herb = popul.OfType<herbivorous>();
            foreach (herbivorous el2 in herb)
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
