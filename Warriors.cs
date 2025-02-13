using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorsFightToDeath 
{ 
    class Warriors
    {

        //the warriors have a Name and stats {Health, Attack, Defense} and status wether they are {isALive} 
        public string Name { get; set; }
        public int SHealth { get; set; }
        public int SAttack { get; set; }
        public int SDefense { get; set; }
        public bool IsAlive { get; set; }
        public bool IsStunned { get; set; }

        // Store original stats for resetting
        public int originalHealth { get; set; }
        public int originalAttack { get; set; }
        public int originalDefense { get; set; }

        //constructor for the warriors
        public Warriors(string name = "Yggsguardian", int health = 0, int attack = 0, int def = 0)
        {
            Name = name;
            SHealth = health;
            SAttack = attack;
            SDefense = def;
            IsAlive = true;

            // Save original stats
            originalHealth = health;
            originalAttack = attack;
            originalDefense = def;
        }


        public virtual void Attack(Warriors target)
        {
            if (!target.IsAlive) return;
            int damage = SAttack - target.SDefense;
            if (damage < 0) damage = 0;

            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");
            target.TakeDamage(damage);

        }

        public void TakeDamage(int damage)
        {
            SHealth -= damage;
            if (SHealth <= 0)
            {
                IsAlive = false;
                Console.WriteLine($"{Name} has died!");
            }
        }

        // Reset stats to original state after each turn
        public virtual void ResetStats()
        {
            SHealth = originalHealth;
            SAttack = originalAttack;
            SDefense = originalDefense;
        }
    }
}
