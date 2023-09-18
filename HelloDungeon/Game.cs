using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HelloDungeon
{
    struct Weapon
    {
        public string Name;
        public float WeaponDamage;
        public float WeaponDefense;
        public float WeaponDurability;
    }
    class Game
    {
        string playerChoice;
        int currentScene = -1;
        bool isDefending;
       
        

        bool gameOver;

        Character Player;
        Character JoePable;
        Character JohnCena;
        Character Payton;
        Character Lodis;
        Character[] Enemies;
        int currentEnemyIndex = 0;

        Weapon Sword;
        Weapon Sheild;
        Weapon Bow;
        Weapon Hammer;
        Weapon Axe;

        void Enemys()
        {


            JoePable = new Character("JoePable", 100f, 3f, 1f, Axe);


            JoePable.Name = "JoePable";
            JoePable.Health = 100f;
            JoePable.Damage = 3f;
            JoePable.Defense = 1f;
            JoePable.Weapon = Axe;


            JohnCena = new Character("JOHN.....cena", 200f, 5f, 2f, Hammer);


            JohnCena.Name = "JOHN.....cena";
            JohnCena.Health = 200f;
            JohnCena.Damage = 5f;
            JohnCena.Defense = 2f;
            JohnCena.Weapon = Hammer;


            Payton = new Character("Peyton", 300f, 8f, 4f, Bow);


            Payton.Name = "Payton";
            Payton.Health = 300f;
            Payton.Damage = 8f;
            Payton.Defense = 4f;
            Payton.Weapon = Bow;


            Lodis = new Character("Lodis", 400f, 10f, 8f, Sword);


            Lodis.Name = "Lodis";
            Lodis.Health = 400f;
            Lodis.Damage = 10f;
            Lodis.Defense = 8f;
            Lodis.Weapon = Sword;

            Enemies = new Character[4] { JoePable, JohnCena, Payton, Lodis };

        }

        string GetInput(string prompt, string option1, string option2, string option3, string option4)
        {

            Console.WriteLine(prompt);
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.WriteLine("3." + option3);
            Console.WriteLine("4." + option4);

            playerChoice = Console.ReadLine();

            return playerChoice;
        }

        void PlayerCharacter()
        {
            Console.WriteLine("Please select a caracter", JoePable, JohnCena, Payton, Lodis);
            
            if (playerChoice == "1")
            {
                Player = JoePable;
            }
            else if (playerChoice == "2")
            {
                Player = JohnCena;
            }
            else if (playerChoice == "3")
            {
                Player = Payton;
            }
            else if (playerChoice == "4")
            {
                Player = Lodis;
            }
            else
            {
                Console.WriteLine("Invalid Input");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }

            PrintCharacterStats(Player);
            Console.ReadKey(true);
            Console.Clear();

           

        }
        string PlayerWeapon(Weapon weapon)
        {
            Console.WriteLine("Now please select a weapon");
            Console.WriteLine("1." + Sword.Name + " 2." + Sheild.Name + " 3." + Bow.Name + " 4." + Hammer.Name + " 5." + Axe);

            playerChoice = Console.ReadLine();

            if (playerChoice == "1")
            {
                weapon = Sword;
            }
            else if (playerChoice == "2")
            {
                weapon = Sheild;
            }
            else if (playerChoice == "3")
            {
                weapon = Bow;
            }
            else if (playerChoice == "4")
            {
                weapon = Hammer;
            }
            else if (playerChoice == "5")
            {
                weapon = Axe;
            }

            return playerChoice;

        }

        //setting up an array
        char[] letters = new char[5] { 'e', 't', 'h', 'a', 'n' };

        int[] numbers = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

        void PlayerStart()
        {
            PlayerCharacter();

            
        }

        

        void PrintWeaponStats(Weapon weapon)
        {
            Console.WriteLine("Name: " + weapon.Name);
            Console.WriteLine("Health: " + weapon.WeaponDurability);
            Console.WriteLine("Damage: " + weapon.WeaponDamage);
            Console.WriteLine("Defense: " + weapon.WeaponDefense);

            return;
        }

        string HealCharacter(Character character)
        {
            string playerChoice = "";

            while (playerChoice == "")
            {
                Console.Clear();
                Console.WriteLine("Would you like to Heal " + character + " by 10?");
                Console.WriteLine("1.Yes or 2.No?");

                if (playerChoice == "1" || playerChoice == "yes")
                {
                    character.Health += 10;
                    PrintCharacterStats(character);
                }
                else if (playerChoice == "2" || playerChoice == "no")
                {
                    PrintCharacterStats(character);
                }
                else
                {
                    Console.WriteLine("Invalid input try again");
                }

                Console.ReadLine();

                playerChoice = Console.ReadLine();

            }

            return playerChoice;

        }

        float Attack(Character attacker, Character defender)
        {
            float totalDamage = attacker.Damage - defender.Defense;

            return defender.Health - totalDamage;
        }

        void BattleScene()
        {

            
            Fight(ref JohnCena);

            Console.ReadKey(true);
            Console.Clear();

            if (Player.Health <= 0 || JohnCena.Health <= 0)
            {
                currentScene = 2;
            }

        }

        void BattleResults()
        { 
            if (JoePable.Health < 0 && Player.Health >= 0)
            {
                Console.WriteLine("The winner is " + Player.Name);
                currentScene = 1;
                currentEnemyIndex++;
            }
            else if (Player.Health < 0 && JoePable.Health >= 0)
            {
                Console.WriteLine("The winner is " + JoePable.Name);
                currentScene = 3;
            }

            Console.ReadKey(true);
            Console.Clear();

        }

        

        void Start()
        {
            


            Sword.Name = "The sword of Aragon";
            Sword.WeaponDurability = 100f;
            Sword.WeaponDamage = 10f;
            Sword.WeaponDefense = 1f;


            Sheild.Name = "The Sheild of the Hero";
            Sheild.WeaponDurability = 150f;
            Sheild.WeaponDamage = 1f;
            Sheild.WeaponDefense = 9f;


            Bow.Name = "the Bow of Legolas";
            Bow.WeaponDurability = 80f;
            Bow.WeaponDamage = 8f;
            Bow.WeaponDefense = 0f;


            Hammer.Name = "The Hammer of Vormier";
            Hammer.WeaponDurability = 100f;
            Hammer.WeaponDamage = 12f;
            Hammer.WeaponDefense = 3f;


            Axe.Name = "The Axe of Steve";
            Axe.WeaponDurability = 90f;
            Axe.WeaponDamage = 9f;
            Axe.WeaponDefense = 3f;
        }

        void Update()
        {
            if (currentScene == 1)
            {
                BattleScene();
            }
            else if (currentScene == 2)
            {
                BattleResults();
            }
            else if (currentScene == 3)
            {
                
            }
        }

        void GameOver()
        {

        }

        void End()
        {
            Console.WriteLine("Thanks for Playing :)");
        }

        public void Run()
        {
            Start();

            while (gameOver == false)
            {
                Update();
            }

            End();
        }
        
    }
}
