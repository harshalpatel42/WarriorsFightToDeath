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
        public void CreateIllusion()
        {
            //this is to randomize the number of clones created
            Console.WriteLine($"{Name} creates an illusion, increasing attack based on 3 of the loki clones");

            numberOfClones = rand.Next(3, 4);
        }

        // Healing: Loki can heal a portion of his health.
        public void Heal()
        {
            //we'll also increase the healing based on the number of clones created
            int healAmount = 100;
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

            // If Loki has clones, he and all clones attack together
            if (numberOfClones > 0)
            {
                int totalDamage = SAttack * (numberOfClones + 1); // +1 to include Loki himself
                Console.WriteLine($"{Name} and his {numberOfClones} clones attack {target.Name} for {totalDamage} total damage!");
                target.TakeDamage(totalDamage);

                // Clones disappear after attacking
                numberOfClones = 0;
            }
            else
            {
                // Normal attack if there are no clones
                Console.WriteLine($"{Name} attacks {target.Name} for {SAttack} damage!");
                target.TakeDamage(SAttack);
            }
        }


    }
}
