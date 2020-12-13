using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame
{
    class Witch : Monster
    {
        private int dumbusChance;

        public int DumbusChance { get => dumbusChance; set => dumbusChance = value; }

        public Witch()
        {
            Random random = new Random();
            Name = "Witch";
            ChanceOfAppearance = 0.1;
            CurrentHealthPoints = MaxHealthPoints = random.Next(200) + 100;
            Damage = random.Next(10);
            Experience = random.Next(50) + 50;
        }

    }
}
