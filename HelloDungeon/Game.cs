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

        string PlayerCharacter()
        {
            Console.WriteLine("Please select a caracter");
            Console.WriteLine("1." + JoePable.Name + " 2." + JohnCena.Name + " 3." + Payton.Name + " 4." + Lodis.Name);

            playerChoice = Console.ReadLine();

            if (playerChoice == "1")
            {
                Character player = JoePable;
            }
            else if (playerChoice == "2")
            {
                Character player = JohnCena;
            }
            else if (playerChoice == "3")
            {
                Character player = Payton;
            }
            else if (playerChoice == "4")
            {
                Character player = Lodis;
            }

            return playerChoice;

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

            
            Fight(ref JoePable, ref JohnCena);

            Console.ReadKey(true);
            Console.Clear();

            if (JoePable.Health <= 0 || JohnCena.Health <= 0)
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

        void Fight(ref Character character1,ref Character character2)
        {
            PrintCharacterStats(character1);
            Console.ReadKey(true);
            Console.Clear();
            PrintCharacterStats(character2);
            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine(character1.Name + " Punches " + character2.Name + "!");
            character2.Health = Attack(character1, character2);
            Console.ReadKey(true);
            Console.Clear();


            PrintCharacterStats(character1);
            Console.ReadKey(true);
            Console.Clear();
            PrintCharacterStats(character2);
            Console.ReadKey(true);
            Console.Clear();


            Console.WriteLine(character2.Name + " Punches " + character1.Name + " back!");
            character1.Health = Attack(character2, character1);
            Console.ReadKey(true);
            Console.Clear();


            PrintCharacterStats(character1);
            Console.ReadKey(true);
            Console.Clear();
            PrintCharacterStats(character2);
        }

        void Start()
        {
            Player.Name = PlayerCharacter();
            Player.Health = PlayerCharacter();
            Player.Damage = PlayerCharacter();
            Player.Defense = PlayerCharacter();
            Player.Weapon = PlayerWeapon();


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

            public void Run()
            {
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
