using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HelloDungeon
{
    class Game
    {
        string playerChoice;
        int currentScene = -1;
        bool isDefending;
        struct Character
        {
            public string Name;
            public float Health;
            public float Damage;
            public float Defense;
            public Weapon Weapon;
        }
        struct Weapon
        {
            public string Name;
            public float WeaponDamage;
            public float WeaponDefense;
            public float WeaponDurability;
        }

        bool gameOver;

        Character Player;
        Character JoePable;
        Character JohnCena;
        Character Payton;
        Character Lodis;

        Weapon Sword;
        Weapon Sheild;
        Weapon Bow;
        Weapon Hammer;
        Weapon Axe;

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

        void PrintCharacterStats(Character character)
        {
            Console.WriteLine("Name: " + character.Name);
            Console.WriteLine("Health: " + character.Health);
            Console.WriteLine("Damage: " + character.Damage);
            Console.WriteLine("Defense: " + character.Defense);

            return;
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
            if (JoePable.Health > 0 && JohnCena.Health <= 0)
            {
                Console.WriteLine("The winner is " + JoePable.Name);
            }
            else if (JohnCena.Health > 0 && JoePable.Health <= 0)
            {
                Console.WriteLine("The winner is " + JohnCena.Name);
            }

            Console.ReadKey(true);
            Console.Clear();

        }

        void Fight(ref Character character1)
        {
            PrintCharacterStats(character1);
            Console.ReadKey(true);
            Console.Clear();
            PrintCharacterStats(Player);
            Console.ReadKey(true);
            Console.Clear();

            string battleChoice = GetInput("Choose an action", "Attack", "Deffend", "Flee", "Seduce?");  

            if (battleChoice == "1")
            {
                character1.Health = Attack(Player, character1);
                Console.WriteLine("You used " + Player.Weapon.Name + "!");
            }
            else if (battleChoice == "2")
            {
                isDefending = true;
                Player.Defense *= 5;
                Console.WriteLine("You grit your teeth");
            }
            else if (battleChoice == "3")
            {
                Console.WriteLine("You fled from the battle as fast as you could.");
                currentScene = 2;
                return;
            }
            

            Console.WriteLine(character1.Name + " Punches " + Player.Name + "!");
            Player.Health = Attack(character1, Player);
            Console.ReadKey(true);
            Console.Clear();

            if (isDefending == true)
            {

            }


            PrintCharacterStats(character1);
            Console.ReadKey(true);
            Console.Clear();
            PrintCharacterStats(Player);
            Console.ReadKey(true);
            Console.Clear();


            Console.WriteLine(Player.Name + " Punches " + character1.Name + " back!");
            character1.Health = Attack(Player, character1);
            Console.ReadKey(true);
            Console.Clear();


            PrintCharacterStats(character1);
            Console.ReadKey(true);
            Console.Clear();
            PrintCharacterStats(Player);
        }

        void Start()
        {
            


            JoePable.Name = "JoePable";
            JoePable.Health = 100f;
            JoePable.Damage = 3f;
            JoePable.Defense = 1f;
            JoePable.Weapon = Axe;


            JohnCena.Name = "JOHN.....cena";
            JohnCena.Health = 200f;
            JohnCena.Damage = 5f;
            JohnCena.Defense = 2f;
            JohnCena.Weapon = Hammer;


            Payton.Name = "Payton";
            Payton.Health = 300f;
            Payton.Damage = 8f;
            Payton.Defense = 4f;
            Payton.Weapon = Bow;


            Lodis.Name = "Lodis";
            Lodis.Health = 400f;
            Lodis.Damage = 10f;
            Lodis.Defense = 8f;
            Lodis.Weapon = Sword;


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
        }

        void End()
        {
            Console.WriteLine("Thanks for Playing :)");
        }

        void Array(int[] prompt)
        {


            
            for (int i = 0; i < prompt.Length; i++)
            {
                Console.WriteLine(i + prompt[i]);
            }

        }

        public void Run()
        {
            ///Create a function that takes in an integer array
            ///The function should print out the sum of all of the values in the array
            ///input: int[] numbers = new int[3] { 1, 2, 3 };
            ///Output: 6
            ///


            Array();


            return;

            int[] grades = new int[5];

            int count = 0;

            while (count < 5)
            {


                Console.WriteLine(count);
                count++;
            }

            for (int i = 0; i < grades.Length; i++)
            {
                Console.WriteLine(grades[i]);
            }


            ///Create a weapon struct should contain a name variable 
            ///add a variable that has the weapon struct type to the monster struct


            Start();

            while (gameOver == false)
            {
                Update();
            }

            End();

        }
        
    }
}
