using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    public class point
    {
        public int x, y;
    }
    public abstract class organisms<TFood>:entity
        where TFood: foodmain
    {
        
        public int closeX, closeY;
        public bool found = false;
        public int gender;
      
        public int index;
        public int timer;
        

        public point tochka = new point();
        
        public int typeofunit;
        

     
        public void WorkCycle(bool check, List<entity> popul, int g, List<entity> entnew)
        {
            Changeattributes(check);
            CheckForFood(popul);
       
            if (this.pair == true)
                Iwantachild(popul, entnew);
            else DecidToMove(g, popul);
                

        }
       
        public void CheckForFood(List<entity> popul)
        {
            for (int i = 0; i < popul.Count; i++)
            {
                if (this.x == popul[i].x && this.y == popul[i].y && (popul[i] is TFood))
                {
                    this.health = 1000;
                    this.found = false;
                    popul[i].DieFood(popul);
                    break;
                }
            }
        }

       

       
        public override void DieFood(List<entity> popul)
        {
            //popul.Remove(popul.Find(entity => entity is TFood && entity.x == this.x && entity.y == this.y));
            this.health = -1;
        }

        public void Changeattributes(bool check)
        {
            if (check)
            {
                this.health--;
                this.timer++;
            }
            else
            {
                this.health -= 2;
                this.timer++;
            }
        }

        public string Information()
        {
            string info = $" gender:{this.gender} \n timer:{this.timer} \n typeofunit:{this.typeofunit} \n health:{this.health}";
            return info;
        }
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

       

        public void FindCloseFood(List<entity> popul)
        {
            int min = 10000000;
            for (int i = 0; i < popul.Count; i++)
            {
                if (popul[i] is TFood)
                {
                    if ((Math.Abs(this.x - popul[i].x) + Math.Abs(this.y - popul[i].y)) < min)
                    {
                        min = Math.Abs(this.x - popul[i].x) + Math.Abs(this.y - popul[i].y);
                        this.closeX = popul[i].x;
                        this.closeY = popul[i].y;
                    }
                   
                }
            }
        }

        public void DecidToMove(int g, List<entity> popul)
        {
            if (this.health < 200)
            {
                if (this.found == false)
                {
                    this.FindCloseFood(popul);
                    this.found = true;
                }

                this.Idontwannadie();
            }
            else
            {

                this.Move(g);
            }
        }
       // public abstract void DecidToMove(int g, List<entity> popul);

        
        public bool CheckForCreatePair()
        {
            if (this.health > 600 && this.pair == false && this.timer >= 100)
                return true;
            else return false;
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


        public abstract void makepair(entity el2, Random rand);


        public abstract void MakeChild(List<entity> popul, List<entity> entnew);
        public void Iwantachild(List<entity> popul, List<entity> entnew)
        {
            int nstepX = this.tochka.x - this.x;
            int nstepY = this.tochka.y - this.y;
            if (nstepX == 0 && nstepY == 0)
            {
                this.MakeChild(popul, entnew);
            }
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

       

        
        public bool Dead()
        {
            if (this.health < 0)
                return true;
            else return false;

        }

       
        public void CreateChildren(int typeunit, Random random, List<entity> entnew)
        {
            if (typeunit == 0)
            {
                herbivorous test = new herbivorous
                {
                    x = this.x,
                    y = this.y,
                    columns = this.columns,
                    rows = this.rows,
                    health = random.Next(950) + 50,
                    gender = random.Next(2),
                    timer = random.Next(100),
                    typeofunit = 0

                };
                entnew.Add(test);
            }
            if (typeunit == 1)
            {
                hunter test = new hunter
                {
                    x = this.x,
                    y = this.y,
                    columns = this.columns,
                    rows = this.rows,
                    health = random.Next(950) + 50,
                    gender = random.Next(2),
                    timer = random.Next(100),
                    typeofunit = 1
                };
                entnew.Add(test);
            }

            if (typeunit == 2)
            {
                omnivorous test = new omnivorous
                {
                    x = this.x,
                    y = this.y,
                    columns = this.columns,
                    rows = this.rows,
                    health = random.Next(950) + 50,
                    gender = random.Next(2),
                    timer = random.Next(100),
                    typeofunit = 2
                };
                entnew.Add(test);
            }
        }


    }
}
