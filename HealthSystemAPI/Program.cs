using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystemAPI
{
    internal class Program
    {
        static int playerHealth;
        static int playerLives;
        static int playerShield;
        static int playerMana;
        static int playerExperience;
        static int playerExperienceThreshhold;
        static int playerLevel;

        static bool impEncounter;
        static bool goblinEncounter;
        static bool orcEncounter;
        static bool dragonEncounter;

        static Random rdn = new Random();

        static void Main(string[] args)
        {
            playerHealth = 100;
            playerShield = 100;
            playerMana = 20;
            playerLives = 3;
            playerExperience = 0;
            playerExperienceThreshhold = 100;
            playerLevel = 1;

            Enemy();

            while(playerLives > 0)
            {
                ShowHUD();
                TakeDamage(150);
                ShowHUD();
                HealHP(35);
                ShowHUD();
                
                Console.ReadKey(true);
            }
        }

        static void ShowHUD()
        {
            if(playerLives > 0)
            {
                Console.WriteLine("===========");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Player HP: " + playerHealth);
                HealthStatus();
                Console.WriteLine("Player Mana: " + playerMana);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("===========");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Player shields: " + playerShield);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("===========");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Player Lives: " + playerLives);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("===========");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Player Level: " + playerLevel);
                Console.WriteLine("Player Experience: " + playerExperience);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("===========");
            }
            else
            {
                Console.WriteLine();
                Console.Write("The player has ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(0);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" lives left");
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static void Enemy()
        {
            int enemyEncounter;
            enemyEncounter = rdn.Next(1, 11);

            if(enemyEncounter == 1 || enemyEncounter == 2 || enemyEncounter == 3)
            {
                impEncounter = true;
                goblinEncounter = false;
                orcEncounter = false;
                dragonEncounter = false;

                Console.WriteLine("An Imp has appeared!");
            }
            else if(enemyEncounter == 4 || enemyEncounter == 5 || enemyEncounter == 6)
            {
                impEncounter = false;
                goblinEncounter = true;
                orcEncounter = false;
                dragonEncounter = false;

                Console.WriteLine("A Goblin has appeared!");
            }
            else if(enemyEncounter == 7 || enemyEncounter == 8 || enemyEncounter == 9)
            {
                impEncounter = false;
                goblinEncounter = false;
                orcEncounter = true;
                dragonEncounter = false;

                Console.WriteLine("An Orc has appeared!");
            }
            else
            {
                impEncounter = false;
                goblinEncounter = false;
                orcEncounter = false;
                dragonEncounter = true;

                Console.WriteLine("A Dragon has appeared!");
                Console.WriteLine("Quick!! Run for your life!");
            }
        }

        static void HealthStatus()
        {
            if(playerHealth >= 75)
            {
                Console.WriteLine("Immaculate");
            }
            else if(playerHealth < 75 && playerHealth >= 50)
            {
                Console.WriteLine("Player has sustained some bumps and brusies");
            }
            else if(playerHealth < 50 && playerHealth > 25)
            {
                Console.WriteLine("Player is injured. Consider healing soon");
            }
            else if(playerHealth <= 25 && playerHealth > 0)
            {
                Console.WriteLine("Death is imminent");
            }
        }

        static void HealHP(int healAmount)
        {
            if(healAmount < 0)
            {
                Console.WriteLine();
                Console.WriteLine("The player cannot heal a negative ammount");
                Console.WriteLine();
            }

            else
            {
                if (playerHealth < 100 && playerMana >= 5)
                {
                    Console.WriteLine();
                    Console.Write("Player is about to heal ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(healAmount);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" points of health");
                    Console.WriteLine();
                    Console.WriteLine();
                    playerMana -= 5;
                    if (playerHealth > 100)
                    {
                        playerHealth = 100;
                    }
                }
                else if (playerHealth == 100 || playerMana < 5)
                {
                    Console.WriteLine("Unable to heal!");
                    if (playerMana < 5)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Not enough mana!");
                    }
                    else if (playerHealth == 100)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Player has max health");
                    }
                }
            }
        }

        static void GainEXP(int expPoints)
        {
            int spillOver;

            if(expPoints < 0)
            {
                Console.WriteLine();
                Console.WriteLine("Player cannot take negative experience points");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.Write("The player is gaining ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(expPoints);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" points of experience");
                Console.WriteLine();
                playerExperience = playerExperience + expPoints;
                if(playerExperience > 100)
                {
                    Console.WriteLine();
                    Console.WriteLine("The player is about to level up");
                    spillOver = playerExperience - 100;
                    playerExperience = spillOver;
                    playerLevel += 1;
                }
            }
            Console.WriteLine();
            Console.Write("The player has ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(playerExperience);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" experience points");
            Console.WriteLine();
            Console.WriteLine();
        }

        static void LevelUp()
        {
            Console.WriteLine();
            Console.WriteLine("Player is gaining experience!");
            Console.WriteLine();
            if (playerExperience >= playerExperienceThreshhold)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The player is leveling up");
                Console.WriteLine();
                playerLevel += 1;
            }

            Console.WriteLine("Player Level: " + playerLevel);
        }

        static void TakeDamage(int damage)
        {
            int spillOverAmout;

            if(damage < 0)
            {
                Console.WriteLine("The player cannot take negative damage!");
            }

            else
            {
                if (playerShield > 0)
                {
                    Console.Write("Player is about to take ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(damage);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Points of damage");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    playerShield -= damage;
                    if (playerShield < 0)
                    {
                        spillOverAmout = playerShield;
                        playerHealth = playerHealth + spillOverAmout;
                        playerShield = 0;
                        if (playerHealth <= 0)
                        {
                            playerLives -= 1;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Player is about to lose a life");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            playerHealth = 100;
                            playerShield = 100;
                            if (playerLives <= 0)
                            {
                                playerLives = 0;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Game Over");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                    }
                }
                else if (playerShield <= 0)
                {
                    Console.WriteLine("Player is about to take " + damage + " points of damage");
                    playerShield = 0;
                    playerHealth = playerHealth - damage;
                    if (playerHealth <= 0)
                    {
                        playerLives -= 1;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Player is about to lose a life");
                        Console.WriteLine();
                        playerHealth = 100;
                        playerShield = 100;
                        if (playerLives <= 0)
                        {
                            playerLives = 0;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Game Over");
                        }
                    }
                }
            }
        }

        static void RegenerateShield(int healAmount)
        {
            if(healAmount < 0)
            {
                Console.WriteLine();
                Console.WriteLine("Player cannot regenerate a negative amount");
                Console.WriteLine();
            }

            else
            {
                if (playerShield < 100)
                {
                    Console.WriteLine();
                    Console.Write("Player is regenerating ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(healAmount);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" points of shields");
                    Console.WriteLine();
                    Console.WriteLine();
                    playerShield = playerShield + healAmount;
                    if (playerShield > 100)
                    {
                        playerShield = 100;
                    }
                }
            }
        }
    }
}
