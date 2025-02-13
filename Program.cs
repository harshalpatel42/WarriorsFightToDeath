using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

using System;

using System;

namespace WarriorsFightToDeath
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the warriors
            MeleeWarrior thor = new MeleeWarrior("Thor", 650, 60, 15);  // Thor with health, attack, and defense values
            MagicWarrior loki = new MagicWarrior("Loki", 250, 50, 15);   // Loki with health, attack, and defense values

            // Create the combat system and start the battle
            Combat combat = new Combat();
            combat.StartBattle(thor, loki);  // Start the battle between Thor and Loki

            // Output the final stats after the battle
            Console.WriteLine("Battle Ended!");
            Console.WriteLine($"{thor.Name}: Health = {thor.SHealth}, Attack = {thor.SAttack}, Defense = {thor.SDefense}");
            Console.WriteLine($"{loki.Name}: Health = {loki.SHealth}, Attack = {loki.SAttack}, Defense = {loki.SDefense}");
        }
    }
}
