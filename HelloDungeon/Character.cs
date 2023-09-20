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


        public Character()
        {
            _name = " ";
            _health = 0f;
            _damage = 0f;
            _defense = 0f;
            _defenseBoost = 0f;
            _weapon = new Weapon();
        }
          
        public Character(string name, float health, float damage, float defense, Weapon currentWeapon)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _defense = defense;
            _weapon = currentWeapon;
        }

        public Character CharacterL(Character character)
        {
            Character charactercharacter = character;

            return charactercharacter;
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

        public float GetDefense()
        {
            return _defense;
        }

        public void DefenseBoost()
        {
            _defense += _defenseBoost; 
        }

        public void ResetDefense()
        {
            _defense -= _defenseBoost;
        }

        public virtual void PrintStats()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage);
            Console.WriteLine("Defense: " + _defense);


            return;
        }

        public void TakeDamage(float damage)
        {
            _health = damage - _defense;
        }

    }
}
