using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WarriorsFightToDeath
{
    class MagicWarrior : Warriors
    {
        Random rand = new Random();
        public int numberOfClones; //making this value persistant across method calls
        public MagicWarrior(string name, int health, int attack, int defense)
                  : base(name, health, attack, defense)
        { }

        // Teleportation: Loki can avoid damage by teleporting.
        public void Teleport()
        {
            Console.WriteLine($"{Name} teleports away, avoiding damage!");
        }

        // Illusions: Loki creates illusions that increase defense and reduce chance of being stunned.
        public int CreateIllusion()
        {
            //this is to randomize the number of clones created
            numberOfClones = rand.Next(1, 4);
            SHealth += 5*numberOfClones;

            //attack increases based on the number of clones created
            SAttack *= numberOfClones;
            Console.WriteLine($"{Name} creates an illusion, increasing defense by 5!");
            return numberOfClones;
        }

        // Healing: Loki can heal a portion of his health.
        public void Heal()
        {
            //we'll also increase the healing based on the number of clones created
            int healAmount = 10 * CreateIllusion();
            SHealth += healAmount;
            Console.WriteLine($"{Name} heals for {healAmount} health!");
        }

 


        // Attack Method for Loki: Override if needed, considering teleport and other abilities.
        public override void Attack(Warriors target)
        {
            if (IsStunned)
            {
                Console.WriteLine($"{Name} is stunned and cannot attack!");
                IsStunned = false;
                return;
            }

            // If Loki teleports, skip damage calculation
            if (numberOfClones > 0)
            {
                Console.WriteLine($"{Name} avoids damage completely by teleporting!");
                return; // Skip damage
            }

            // Default attack logic (if no teleport or special condition)
            base.Attack(target);
        }


        // Reset stats after each turn
        public override void ResetStats()
        {
            base.ResetStats();  // Reset to original stats
            // After using illusions, reset the stats for next turn
            SAttack /= numberOfClones;  // Adjust back attack based on number of clones
            SHealth -= 5 * numberOfClones;  // Adjust health after illusion
        }
    }
}
