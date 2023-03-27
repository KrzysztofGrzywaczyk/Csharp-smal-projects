using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duel_Game_Mechanics
{
    internal class Goldminer : Character, IDynamite
    {
        public Goldminer(string name, int hp, Colors color) : base(name, hp, color)
        {
        }

        public override void Attack(Character character)
        {
            int hp = rnd.Next(50, 60);
            character.CurrentHp -= hp;
            Console.WriteLine($"{Name} delivered {hp} damage to {character.Name}.");
        }

        public void Dynamite(Character character)
        {
            int hp = rnd.Next(240, 260);
            character.CurrentHp -= hp;
            Console.WriteLine($"BANG: {Name} delivered {hp} damage to {character.Name} by throwing dynamite.");
            UsedDynamite = true;
        }
        public override void Heal()
        {
            int hp = rnd.Next(20, 50);
            CurrentHp += hp;
            Console.WriteLine($"{Name} healed {hp}.");
        }
    }
}
