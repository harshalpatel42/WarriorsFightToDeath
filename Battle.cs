using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorsFightToDeath
{
    internal class Battle
    {
        // StartFight
        // war1 attacks war2 and war2 is damaged and health deacreses
        // Get attack result
        // war2 attacks war1 and war1 is damaged and health deacreses
        // Get attack result

        // Get Attack result

        public static void StartFight(Warriors warrior1, Warriors warrior2)
        {
            while (true)
            {
                if (GetAttackResult(warrior1, warrior2) == "Game Over")
                {
                    Console.WriteLine("Game Over");
                    break;
                }
                if (GetAttackResult(warrior2, warrior1) == "Game Over")
                {
                    Console.WriteLine("Game Over");
                    break;
                }
            }

        }

        public static string GetAttackResult(Warriors warriorA, Warriors warriorB)
        {
            double warAtkAmt = warriorA.Attack();
            double warBBlkAmt = warriorB.Block();

            double dm2WarB = warAtkAmt - warBBlkAmt;

            if (dm2WarB > 0)
            {
                warriorB.Health = warriorB.Health - dm2WarB;
            }
            else { dm2WarB = 0; }

            Console.WriteLine("{0} Attacks {1}  and deals {2}  damage", warriorA.Name, warriorB.Name, dm2WarB);
            Console.WriteLine("{0} has {1} Health", warriorA.Name, warriorB.Health);

            if (warriorB.Health <= 0)
            {
                Console.WriteLine("{0} has died and  {1} is Victorius\n", warriorA.Name, warriorB.Name);
                return "Game Over";
            }
            else return "Fight Again";
            
        }
    }
}
