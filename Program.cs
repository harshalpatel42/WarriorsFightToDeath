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
            MeleeWarrior Thor = new MeleeWarrior("Thor", 650, 60, 15);  // Thor with health, attack, and defense values
            MagicWarrior Loki = new MagicWarrior("Loki", 250, 50, 15);   // Loki with health, attack, and defense values

            // Create the combat system and start the battle
            Combat combat = new Combat();
            combat.StartBattle(Thor, Loki);  // Start the battle between Thor and Loki

            // Output the final stats after the battle
            Console.WriteLine("\n\n\n\n\nBattle has Ended!\n\n\n\n");
            Console.WriteLine($"{Thor.Name}: Health = {Thor.SHealth}, Attack = {Thor.SAttack}, Defense = {Thor.SDefense}");
            Console.WriteLine($"{Loki.Name}: Health = {Loki.SHealth}, Attack = {Loki.SAttack}, Defense = {Loki.SDefense}");
        }
    }
}
