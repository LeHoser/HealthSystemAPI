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
        static int playerLevel;

        static int Rifle;
        static int Shotgun;

        static int enemyHealth;

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
            Console.WriteLine();
            Console.WriteLine("Player HP: " + playerHealth);
            Console.WriteLine();
            Console.WriteLine("Player Stamina: " + playerShield);
            Console.WriteLine();
            Console.WriteLine("Player Lives: " + playerLives);
            Console.WriteLine();
        }

        static void Enemy()
        {
            int enemyEncounter;
            enemyEncounter = rdn.Next(1, 11);

            if(enemyEncounter == 1 || enemyEncounter == 2 || enemyEncounter == 3)
            {
                Console.WriteLine("An Imp has appeared!");
            }
            else if(enemyEncounter == 4 || enemyEncounter == 5 || enemyEncounter == 6)
            {
                Console.WriteLine("A Goblin has appeared!");
            }
            else if(enemyEncounter == 7 || enemyEncounter == 8 || enemyEncounter == 9)
            {
                Console.WriteLine("An Orc has appeared!");
            }
            else
            {
                Console.WriteLine("A Dragon has appeared!");
                Console.WriteLine("Quick!! Run for your life!");
            }
        }

        static void HealHP(int healAmount)
        {
            healAmount = 25;
            playerMana -= 5;
        }

        static void GainEXP(int expPoints)
        {

        }

        static void LevelUp()
        {

        }
    }
}
