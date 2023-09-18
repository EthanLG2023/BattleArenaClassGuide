using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Character
    {
        private string _name;
        private float _health;
        private float _damage;
        private float _defense;
        private float _defenseBoost = 5;
        private Weapon _weapon;

        public Character(string name, float health, float damage, float defense, Weapon currentWeapon)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _defense = defense;
            _weapon = currentWeapon;
        }

        public string GetName()
        {
            return _name;
        }

        public float Health()
        {
            return _health;
        }

        public Weapon GetWeapon()
        {
            return _weapon;
        }

        public float GetDamage()
        {
            return _damage;
        }

        public void DefenseBoost()
        {
            _defense += _defenseBoost; 
        }

        public void ResetDefense()
        {
            _defense -= _defenseBoost;
        }

        public void PrintCharacterStats(Character character)
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage);
            Console.WriteLine("Defense: " + _defense);

            return;
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
    }
}
