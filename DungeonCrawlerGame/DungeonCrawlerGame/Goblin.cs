using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame
{
    class Goblin : Monster
    {

        public Goblin()
        {
            Random random = new Random();
            Name = "Goblin";
            ChanceOfAppearance = 0.6;
            CurrentHealthPoints = MaxHealthPoints = random.Next(100);
            Damage = random.Next(5);
            Experience = random.Next(30);
        }
    }


    }
