using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    public class populationgroup
    {
        
        public int countofp = 200;
        public int progress = 1;
        public int deadradius = 15;
        public List<entity> popul = new List<entity>();
        public bool season;
        public int countfood = 200;
        public List<entity> newent = new List<entity>();
        // констуркотры 
        // 
        public void Createfirstfood(int col, int r)
        {
          
            Random random = new Random();
            for (int i = 0; i < countfood; i++)
            {
                eat test = new eat
                {
                    x = random.Next(col),
                    y = random.Next(r),
                    columns = col,
                    rows = r,
                    health = 1000,
                    popl2 = this

                };
                popul.Add(test);
            }
        }
        public void CreatesimpleUnit(int col, int r,Random random)
        {
            
            herbivorous test = new herbivorous
            {
                x = random.Next(col),
                y = random.Next(r),
                columns = col,
                rows = r,
                health = random.Next(950) + 50,
                gender = random.Next(2),
                timer = random.Next(100),
                typeofunit = 0

            };
            popul.Add(test);
        }

        public void CreateHunterUnit(int col,int r, Random random)
        {
            
            hunter test = new hunter
            {
                x = random.Next(col),
                y = random.Next(r),
                columns = col,
                rows = r,
                health = random.Next(950) + 50,
                gender = random.Next(2),
                timer = random.Next(100),
                typeofunit = 1
            };
            popul.Add(test);
         
        }

        public void CreateOmnivorousUnit(int col, int r, Random random)
        {
            
            omnivorous test = new omnivorous
            {
                x = random.Next(col),
                y = random.Next(r),
                columns = col,
                rows = r,
                health = random.Next(950) + 50,
                gender = random.Next(2),
                timer = random.Next(100),
                typeofunit = 2
            };
            popul.Add(test);

        }

        public void Createfirstgen(int col, int r)
        {
           // populations = new unit[countofp];
            Random random = new Random();
            for (int i = 0; i < countofp; i++)
            {
                int typ = random.Next(3);
                if (typ == 0)
                    CreatesimpleUnit(col, r, random);
                if (typ == 1)
                    CreateHunterUnit(col,r,random);
                if (typ == 2)
                    CreateOmnivorousUnit(col, r,random);
            }
        }

        public void DeleteLocation(int x2, int y2)
        {
            for (int i = 0; i < popul.Count; i++)
            {
                if ((Math.Abs(popul[i].x - x2) < 30) && (Math.Abs(popul[i].y - y2) < 30))
                {
                    popul.RemoveAt(i);
                    i--;
                }
            }
        }

        

        
        public void NewStepPop()
        {
            
            progress++;
            if ((progress / 500) % 2 == 0)
                season = true;
            else season = false;
            Random rand = new Random();
            int indherb = 0, indhunt = 0, indomni = 0;
            IEnumerable<herbivorous> herb = popul.OfType<herbivorous>();
            foreach (herbivorous el in herb)
            {
                if (el.pair == false)
                {
                    if (el.CheckForCreatePair())
                    {
                        foreach(herbivorous el2 in herb)
                        {
                            if (el2.CheckForCreatePair() && el2.gender!= el.gender)
                            {
                                el.makepair(el2, rand);
                            }
                        }
                    }
                }
                el.WorkCycle(season, popul, rand.Next(4), newent);
                indherb++;
            }

            IEnumerable<hunter> hunt = popul.OfType<hunter>();
            foreach (hunter el in hunt)
            {
                if (el.pair == false)
                {
                    if (el.CheckForCreatePair())
                    {
                        foreach (hunter el2 in hunt)
                        {
                            if (el2.CheckForCreatePair() && el2.gender != el.gender)
                            {
                                el.makepair(el2, rand);
                            }
                        }
                    }
                }
                el.WorkCycle(season, popul, rand.Next(4), newent);
                indhunt++;
            }

            IEnumerable<omnivorous> omni = popul.OfType<omnivorous>();
            foreach (omnivorous el in omni)
            {
                if (el.pair == false)
                {
                    if (el.CheckForCreatePair())
                    {
                        foreach (omnivorous el2 in omni)
                        {
                            if (el2.CheckForCreatePair() && el2.gender != el.gender)
                            {
                                el.makepair(el2, rand);
                            }
                        }
                    }
                }
                el.WorkCycle(season, popul, rand.Next(4), newent);
                indomni++;
            }
            for (int i = 0; i < popul.Count; i++)
            {
                if (popul[i].health < 0)
                {
                    popul.RemoveAt(i);
                    i--;
                    if (i < 0)
                        i++;
                }
            }
            for(int i = 0; i < newent.Count; i++)
            {
                popul.Add(newent[i]);
            }
            newent.Clear();
           
        }
     
    }
}
