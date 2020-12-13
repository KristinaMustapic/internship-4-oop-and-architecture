using System;
using System.Collections.Generic;

namespace DungeonCrawlerGame
{
    class Brute : Monster
    {
        private int criticalChance;

        public int CriticalChance { get => criticalChance; set => criticalChance = value; }

        public Brute()
        {
            Random random = new Random();
            Name = "Brute";
            ChanceOfAppearance = 0.3;
            CurrentHealthPoints = MaxHealthPoints = random.Next(500) + 100;
            Damage = random.Next(15);
            Experience = random.Next(50) + 30;
            CriticalChance = random.Next(100);
        }

        public override double Napad(ref Hero heroj, ref List<Monster> cudovista)
        {
            Random random = new Random();
            int randomBroj = random.Next(100);
            if (randomBroj >= 0 && randomBroj <= CriticalChance)
            {
                return heroj.CurrentHealthPoints * random.NextDouble();
            }
            else
            {
                return Damage;
            }
        }
    }
}
