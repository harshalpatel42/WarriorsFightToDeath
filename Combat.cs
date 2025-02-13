using System;
using System.Threading;

using System;

namespace WarriorsFightToDeath
{

    class Combat : Warriors
    {
        // Save original stats for resetting after each action
        private void SaveOriginalStats(Warriors warrior)
        {
            warrior.originalHealth = warrior.SHealth;
            warrior.originalAttack = warrior.SAttack;
            warrior.originalDefense = warrior.SDefense;
        }

        private void RestoreOriginalStats(Warriors warrior)
        {
            warrior.SHealth = warrior.originalHealth;
            warrior.SAttack = warrior.originalAttack;
            warrior.SDefense = warrior.originalDefense;
        }

        public void StartBattle(MeleeWarrior thor, MagicWarrior loki)
        {
            // Basic combat loop: Alternate turns between Thor and Loki until one of them dies
            while (thor.IsAlive && loki.IsAlive)
            {
                // Thor's turn
                PerformAction(thor, loki);

                if (!loki.IsAlive) break;

                // Loki's turn
                PerformAction(loki, thor);
            }
        }

        // Perform an action for each warrior
        private void PerformAction(Warriors attacker, Warriors defender)
        {
            // Save original stats before modifying them
            SaveOriginalStats(attacker);
            SaveOriginalStats(defender);

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
                }
                else
                {
                    loki.Heal();
                }
            }

            // Restore stats to their original values after the action is performed
            RestoreOriginalStats(attacker);
            RestoreOriginalStats(defender);

            // Print both warriors' status after each action
            Console.WriteLine($"{attacker.Name}: Health = {attacker.SHealth}, Attack = {attacker.SAttack}, Defense = {attacker.SDefense}");
            Console.WriteLine($"{defender.Name}: Health = {defender.SHealth}, Attack = {defender.SAttack}, Defense = {defender.SDefense}");
            Console.WriteLine();
        }
    }
}

