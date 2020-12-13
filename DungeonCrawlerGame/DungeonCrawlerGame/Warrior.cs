using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame
{
    class Warrior : Hero
    {

        public Warrior(String name)
        {
            Name = name;
            CurrentHealthPoints = MaxHealthPoints = 1000;
            Experience = 0;
            Damage = 10;
        }

        public Warrior(String name, double HP, double damage)
        {
            Name = name;
            CurrentHealthPoints = MaxHealthPoints = HP;
            Experience = 0;
            Damage = damage;
        }

        public override void LevelUP()
        {
            MaxHealthPoints += 30;
            Damage += 5;
        }


        public override double Napad(ref bool ponoviRundu)
        {
            Console.WriteLine("Upisi opciju napada:\n1 - Obican napad\n2 - Napad iz bijesa");
            int opcija = Convert.ToInt32(Console.ReadLine());
            if (opcija == 1)
            {
                return Damage;
            }
            else
            {
                CurrentHealthPoints = 0.85 * CurrentHealthPoints;
                return 2 * Damage;
            }

        }
    }
}
