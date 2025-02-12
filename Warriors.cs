using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorsFightToDeath 
{ 
    internal class Warriors
    {
        public string Name { get; set; }
        public double Health { get; set; }
        public double AttackMax { get; set; }

        public double BlockMax { get; set; }

        Random random = new Random();

        public Warriors(string name = "Yggsguardian", double health = 0, double attackMax = 0, double blockMax = 0)
        {
            Name = name;
            Health = health;
            AttackMax = attackMax;
            BlockMax = blockMax;
        }

        public double Attack()
        {
            return random.Next(1, (int)AttackMax);
        }

        public virtual double Block()
        {
            return random.Next(1, (int)BlockMax);
        }
    }
}
