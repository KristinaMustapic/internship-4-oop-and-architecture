using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame
{
    class Ranger : Hero
    {
        private double criticalChance;
        private double stunChance;
        public double CriticalChance { get => criticalChance; set => criticalChance = value; }
        public double StunChance { get => stunChance; set => stunChance = value; }

        public Ranger(String name)
        {
            Name = name;
            Experience = 0;
            CurrentHealthPoints = MaxHealthPoints = 750;
            Damage = 20;
            CriticalChance = StunChance = 0;
        }

        public Ranger(String name, double HP, double damage, int critical, int stun)
        {
            Name = name;
            CurrentHealthPoints = MaxHealthPoints = HP;
            Experience = 0;
            Damage = damage;
            CriticalChance = critical;
            StunChance = stun;
        }

        public override double Napad(ref bool ponoviRundu)
        {
            Random random = new Random();
            double brojRandom = random.NextDouble() * 100;
            if (brojRandom >= 0 && brojRandom <= StunChance)
            {
                ponoviRundu = true;
            }
            else
            {
                ponoviRundu = false;
            }

            brojRandom = random.NextDouble() * 100;
            if (brojRandom >= 0 && brojRandom <= CriticalChance)
            {
                return 2 * Damage;
            }
            else
            {
                return Damage;
            }
        }

        public override void LevelUP()
        {
            MaxHealthPoints += 20;
            Damage += 10;

            CriticalChance += 2;
            StunChance += 1;
        }

        public override void Status()
        {
            base.Status();
            Console.WriteLine(String.Format("CritChance: {0}", CriticalChance));
            Console.WriteLine(String.Format("StunChance: {0}", StunChance));

        }
    }
}
