using System;
using System.Collections.Generic;

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


        public override int MonsterDefeated(ref List<Monster> cudovista)
        {
            double randomBroj;
            Random random = new Random();
            double goblinProbability = new Goblin().ChanceOfAppearance;
            double bruteProbability = new Brute().ChanceOfAppearance;

            for (int i = 0; i < 2; i++)
            {
                randomBroj = random.NextDouble();
                if (randomBroj >= 0 && randomBroj < goblinProbability)
                {
                    cudovista.Add(new Goblin());
                }
                else if (randomBroj >= goblinProbability && randomBroj < (goblinProbability + bruteProbability))
                {
                    cudovista.Add(new Brute());
                }
                else
                {
                    cudovista.Add(new Witch());
                }
            }
            return Experience;
        }

        public override double Napad(ref Hero heroj, ref List<Monster> cudovista)
        {
            Random random = new Random();
            int randomBroj = random.Next(100);
            if (randomBroj >= 0 && randomBroj <= DumbusChance)
            {
                heroj.CurrentHealthPoints = random.NextDouble() * heroj.MaxHealthPoints;

                for (int i = 0; i < cudovista.Count; i++)
                {
                    cudovista[i].CurrentHealthPoints = random.NextDouble() * cudovista[i].MaxHealthPoints;
                }

                return 0;
            }
            else
            {
                return Damage;
            }
        }
    }
}
