using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    public class Runner
    {
        Form1 form1;
        populationgroup population;
        Plants plant;
        public Runner(Form1 form)
        {
            form1 = form;
            population = new populationgroup();
            plant = new Plants();
        }

        public void CreateMyWorld()
        {
            form1.InicializeValue();
            population.Createfirstgen(form1.columns, form1.rows);
            plant.Createfirstfood(form1.columns, form1.rows);
        }

        public void CreateNewWorld()
        {
            form1.DrawMap(population.populations,plant.food,population.countofp);
            population.NewStepPop(plant.food);
     
        }

      


    }
}
