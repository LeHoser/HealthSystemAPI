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

        static public bool impEncounter;
        static public bool goblinEncounter;
        static public bool orcEncounter;
        static public bool dragonEncounter;

        static int Rifle;
        static int Shotgun;

        static int weaponDamage;

        static string choice;

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
                Console.ReadKey(true);
            }
        }

        static void ShowHUD()
        {
            Console.WriteLine("===========");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Player HP: " + playerHealth);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("===========");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Player Stamina: " + playerShield);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("===========");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Player Lives: " + playerLives);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("===========");
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

        static void HealHP(int healAmount)
        {
            if(healAmount < 0)
            {
                Console.WriteLine("The player cannot heal a negative ammount");
            }

            else
            {
                if (playerHealth < 100 && playerMana >= 5)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Player is about to heal " + healAmount + " points of health");
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
                Console.WriteLine("Player cannot take negative experience points");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The player is gaining" + expPoints + " points of experience");
                playerExperience = playerExperience + expPoints;
                if(playerExperience > 100)
                {
                    spillOver = playerExperience - 100;
                    playerExperience = spillOver;
                }
            }
        }

        static void LevelUp()
        {
            if (playerExperience >= playerExperienceThreshhold)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The player is leveling up");
                playerLevel += 1;
            }
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Player is about to take " + damage + " points of damage");
                    playerShield -= damage;
                    if (playerShield < 0)
                    {
                        spillOverAmout = playerShield;
                        playerHealth = playerHealth - spillOverAmout;
                        playerShield = 0;
                        if (playerHealth <= 0)
                        {
                            playerLives -= 1;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Player is about to lose a life");
                            if (playerLives <= 0)
                            {
                                playerLives = 0;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Game Over");
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
                Console.WriteLine("Player cannot regenerate a negative amount");
            }

            else
            {
                if (playerShield < 100)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Player is regenerating " + healAmount + " points of shields");
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
