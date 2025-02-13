using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WarriorsFightToDeath
{
    class MeleeWarrior : Warriors
    {
        Random random = new Random();

        public MeleeWarrior(string name, int health, int attack, int defense) : base(name, health, attack, defense)
        {

        }
        
        public void AwakeningRune(Warriors target)
        {
            int totalDamage = SAttack*2 - target.SDefense;
            SHealth += 100;

            if (totalDamage < 0) totalDamage = 0;
            Console.WriteLine($"{Name} uses Awakening Rune on {target.Name}, dealing {totalDamage} damage!");
            target.TakeDamage(totalDamage);
            SHealth -= 100;
        }

        // TryToStun: Thor tries to stun the enemy, reducing their ability to act
        public void TryToStun(Warriors target)
        {
            if (random.Next(0, 2) == 0)  // 50% chance to stun
            {
                Console.WriteLine($"{Name} attempts to stun {target.Name}!");
                target.IsStunned = true;  // Set stun status
                Console.WriteLine($"{target.Name} is stunned and cannot act next turn!");
            }
            else
            {
                Console.WriteLine($"{Name} fails to stun {target.Name}.");
                target.SHealth += 100;
            }
        }

    }
}
