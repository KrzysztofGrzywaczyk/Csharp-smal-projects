using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duel_Game_Mechanics
{
    internal class Farmer : Character
    {
        public Farmer(string name, int hp, Colors color) : base(name, hp, color)
        {
        }

        public override void Attack(Character character)
        {
            int hp = rnd.Next(20, 30);
            character.CurrentHp -= hp;
            Console.WriteLine($"{Name} delivered {hp} damage to {character.Name}.");
        }

        public override void Heal()
        {
            int hp = rnd.Next(150, 200);
            CurrentHp += hp;
            Console.WriteLine($"{Name} healed {hp}.");
        }
    }
}
