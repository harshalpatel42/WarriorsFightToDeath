using System;
using System.Threading;

using System;

namespace WarriorsFightToDeath
{
    class Combat : Warriors
    {
        // Save original stats for resetting after each action
      

        public void StartBattle(MeleeWarrior thor, MagicWarrior loki)
        {
            // Basic combat loop: Alternate turns between Thor and Loki until one of them dies
            while (thor.IsAlive && loki.IsAlive)
            {
                // Thor's turn
                PerformAction(thor, loki);

                if (!loki.IsAlive) // Check if Loki is dead after Thor's turn
                {
                    Console.WriteLine($"{loki.Name} has died! {thor.Name} wins!");
                    break; // Exit the loop if Loki is dead
                }

                // Loki's turn
                PerformAction(loki, thor);

                if (!thor.IsAlive) // Check if Thor is dead after Loki's turn
                {
                    Console.WriteLine($"{thor.Name} has died! {loki.Name} wins!");
                    break; // Exit the loop if Thor is dead
                }
            }
        }

        // Perform an action for each warrior
        private void PerformAction(Warriors attacker, Warriors defender)
        {
            // Save original stats before modifying them

            if (attacker is MeleeWarrior)
            {
                MeleeWarrior thor = (MeleeWarrior)attacker;
                Random random = new Random();

                // Randomly decide Thor's action: Attack, Try to Stun, or Awakening Rune
                int actionChoice = random.Next(0, 3);
                if (actionChoice == 0)
                {
                    thor.Attack(defender);
                }
                else if (actionChoice == 1)
                {
                    thor.TryToStun(defender);
                }
                else
                {
                    thor.AwakeningRune(defender);
                }
            }
            else if (attacker is MagicWarrior)
            {
                MagicWarrior loki = (MagicWarrior)attacker;
                Random random = new Random();

                // Randomly decide Loki's action: Attack, Create Illusion, or Heal
                int actionChoice = random.Next(0, 3);
                if (actionChoice == 0)
                {
                    loki.Attack(defender);
                }
                else if (actionChoice == 1)
                {
                    loki.CreateIllusion();
                    loki.Attack(defender);
                }
                else
                {
                    loki.Heal();
                }
            }

            ResetStats();
            // Print both warriors' status after each action
            Console.WriteLine($"{attacker.Name}: Health = {attacker.SHealth}, Attack = {attacker.SAttack}, Defense = {attacker.SDefense}");
            Console.WriteLine($"{defender.Name}: Health = {defender.SHealth}, Attack = {defender.SAttack}, Defense = {defender.SDefense}");
            Console.WriteLine();
        }
    }
}
