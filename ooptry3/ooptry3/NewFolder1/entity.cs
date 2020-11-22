using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    abstract public class entity
    {
        public int x, y, rows, columns;
        public int health;
        public bool pair = false;
        public populationgroup popl2;
        public abstract void DieFood(List<entity> popul);

    }
    
}
