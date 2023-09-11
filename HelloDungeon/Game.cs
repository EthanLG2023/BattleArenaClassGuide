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
        struct Monster
        {
            public string Name;
            public float Health;
            public float Damage;
            public float Defense;
            public float Stamina;
        }

        void PrintStats(Monster monster)
        {
            Console.WriteLine("Name: " + monster.Name);
            Console.WriteLine("Health: " + monster.Health);
            Console.WriteLine("Damage: " + monster.Damage);
            Console.WriteLine("Defense: " + monster.Defense);
            Console.WriteLine("Stamina: " + monster.Stamina);

            return;
        }

        string HealMonster(Monster monster)
        {
            string playerChoice = "";

            while (playerChoice == "")
            {
                Console.Clear();
                Console.WriteLine("Would you like to Heal " + monster + " by 10?");
                Console.WriteLine("1.Yes or 2.No?");

                if (playerChoice == "1" || playerChoice == "yes")
                {
                    monster.Health += 10;
                    PrintStats(monster);
                }
                else if (playerChoice == "2" || playerChoice == "no")
                {
                    PrintStats(monster);
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

        float Attack(Monster attacker, Monster defender)
        {
            float totalDamage = attacker.Damage - defender.Defense;

            return defender.Health - totalDamage;
        }

        void Fight(Monster monster1, Monster monster2)
        {
            PrintStats(monster1);
            Console.ReadKey(true);
            Console.Clear();
            PrintStats(monster2);
            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine(monster1.Name + " Punches " + monster2.Name + "!");
            monster2.Health = Attack(monster1, monster2);
            Console.ReadKey(true);
            Console.Clear();


            PrintStats(monster1);
            Console.ReadKey(true);
            Console.Clear();
            PrintStats(monster2);
            Console.ReadKey(true);
            Console.Clear();


            Console.WriteLine(monster2.Name + " Punches " + monster1.Name + " back!");
            monster1.Health = Attack(monster2, monster1);
            Console.ReadKey(true);
            Console.Clear();


            PrintStats(monster1);
            Console.ReadKey(true);
            Console.Clear();
            PrintStats(monster2);
        }

        public void Run()
        {
            Monster JoePable;
            JoePable.Name = "JoePable";
            JoePable.Health = 100f;
            JoePable.Damage = 3f;
            JoePable.Defense = 1f;
            JoePable.Stamina = 3f;

            Monster JohnCena;
            JohnCena.Name = "JOHN.....cena";
            JohnCena.Health = 200f;
            JohnCena.Damage = 5f;
            JohnCena.Defense = 2f;
            JohnCena.Stamina = 5f;

            Monster Payton;
            Payton.Name = "Payton";
            Payton.Health = 300f;
            Payton.Damage = 8f;
            Payton.Defense = 4f;
            Payton.Stamina = 10f;

            Monster Lodis;
            Lodis.Name = "Lodis";
            Lodis.Health =400f;
            Lodis.Damage =10f;
            Lodis.Defense =8f;
            Lodis.Stamina =20f;

            Fight(JoePable, JohnCena);

            Console.ReadKey(true);
            Console.Clear();

            Fight(JoePable, JohnCena);

            Console.ReadKey(true);
            Console.Clear();

            Fight(JoePable, JohnCena);

            Console.ReadKey(true);
            Console.Clear();

        }
    }
}
