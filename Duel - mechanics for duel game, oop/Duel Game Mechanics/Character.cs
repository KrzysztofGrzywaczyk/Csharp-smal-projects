using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duel_Game_Mechanics
{
    internal abstract class Character
    {
        public string Name { get; }
        public int Hp { get; }

        private int currentHp;

        public int CurrentHp
        {
            get { return currentHp; }
            set
            {
                if (value > Hp) 
                {
                    value = Hp;
                }
                if (value < 0) 
                {
                    value = 0;
                }
                currentHp = value;
            }
        }

        public bool UsedDynamite { get; set; }
        public Colors Color { get; set; }

        protected Random rnd = new Random();

        public Character(string name, int hp, Colors color)
        {
            Name = name;
            Hp = hp;
            CurrentHp = Hp;
            Color = color;
            
        }

        public abstract void Attack (Character character);

        public abstract void Heal();

        public override string ToString()
        {
            return $"{Name} - {CurrentHp}/{Hp} ♥";
        }


    }
    enum Colors { cyan, gray, green, yellow}
}
