using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorsFightToDeath 
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Warriors thor = new Warriors("Thor",100,26,10);
            MagicWarrior loki = new MagicWarrior("Loki",75,20,9,50);
            Battle.StartFight(thor, loki);
        }



    }

}