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

        Player PlayerCharacter;
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

            JohnCena = new Character("JOHN.....cena", 200f, 5f, 2f, Hammer);

            Payton = new Character("Peyton", 300f, 8f, 4f, Bow);

            Lodis = new Character("Lodis", 400f, 10f, 8f, Sword);

            Enemies = new Character[4] { JoePable, JohnCena, Payton, Lodis };

        }

        void Fight(ref Character character)
        {
            PlayerCharacter.PrintStats();
            Console.ReadKey(true);
            Console.Clear();
            character.PrintStats();
            Console.ReadKey(true);
            Console.Clear();

            string battleChoice = PlayerCharacter.GetInput("Choose an action", "Attack", "Deffend", "Flee", "Seduce?");

            if (battleChoice == "1")
            {
                character.TakeDamage(currentEnemyIndex);
                Console.WriteLine("You used " + PlayerCharacter.GetWeapon().Name + "!");
            }
            else if (battleChoice == "2")
            {
                isDefending = true;
                Console.WriteLine("You grit your teeth");
            }
            else if (battleChoice == "3")
            {
                Console.WriteLine("You fled from the battle as fast as you could.");
                currentScene = 2;
                return;
            }


            Console.WriteLine(character.GetName() + " Punches " + PlayerCharacter.GetName() + "!");
            PlayerCharacter.TakeDamage(character.GetDamage());
            Console.ReadKey(true);
            Console.Clear();

            if (isDefending == true)
            {

            }


            character.PrintStats();
            Console.ReadKey(true);
            Console.Clear();
            PlayerCharacter.PrintStats();
            Console.ReadKey(true);
            Console.Clear();


            Console.WriteLine(PlayerCharacter.GetName() + " Punches " + character.GetName()+ " back!");
            character.TakeDamage(PlayerCharacter.GetDamage());
            Console.ReadKey(true);
            Console.Clear();


            character.PrintStats();
            Console.ReadKey(true);
            Console.Clear();
            PlayerCharacter.PrintStats();
        }

        void PlayerCharacter1()
        {

            PlayerCharacter = new Player();
            Console.WriteLine(PlayerCharacter.GetInput("Please select a caracter", "JoePable", "JohnCena", "Payton", "Lodis"));
            
            if (playerChoice == "1")
            {
                PlayerCharacter = new Player(JoePable.GetName(), JoePable.Health(), JoePable.GetDamage(), JoePable.GetDefense(), JoePable.GetWeapon());
            }
            else if (playerChoice == "2")
            {
                PlayerCharacter = new Player(JohnCena.GetName(), JohnCena.Health(), JohnCena.GetDamage(), JohnCena.GetDefense(), JohnCena.GetWeapon());
            }
            else if (playerChoice == "3")
            {
                PlayerCharacter = new Player(Payton.GetName(), Payton.Health(), Payton.GetDamage(), Payton.GetDefense(), Payton.GetWeapon());
            }
            else if (playerChoice == "4")
            {
                PlayerCharacter = new Player(Lodis.GetName(), Lodis.Health(), Lodis.GetDamage(), Lodis.GetDefense(), Lodis.GetWeapon());
            }
            else
            {
                Console.WriteLine("Invalid Input");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }

            //PrintCharacterStats(Player);
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
            PlayerCharacter1();

            
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
                    
                    character.PrintStats();
                }
                else if (playerChoice == "2" || playerChoice == "no")
                {
                    character.PrintStats();
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

        void BattleScene()
        {
            Fight(ref JoePable);

            Console.ReadKey(true);
            Console.Clear();

            if (PlayerCharacter.Health() <= 0 || JoePable.Health() <= 0)
            {
                currentScene = 2;
            }

        }

        void BattleResults()
        { 
            if (JoePable.Health() < 0 && PlayerCharacter.Health() >= 0)
            {
                Console.WriteLine("The winner is " + PlayerCharacter.GetName());
                currentScene = 1;
                currentEnemyIndex++;
            }
            else if (PlayerCharacter.Health() < 0 && JoePable.Health() >= 0)
            {
                Console.WriteLine("The winner is " + JoePable.GetName());
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
            Console.WriteLine(PlayerCharacter.GetInput("You died. Play again?", "1.Yes", "2.No"));

            if (playerChoice == "1")
            {
                currentScene = 0;
            }
            else if (playerChoice == "2")
            {
                gameOver = true;
            }
            
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
