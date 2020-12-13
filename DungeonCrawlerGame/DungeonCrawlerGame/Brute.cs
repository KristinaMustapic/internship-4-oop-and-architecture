using System;
using System.Collections.Generic;
using System.Text;

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

    }
}
