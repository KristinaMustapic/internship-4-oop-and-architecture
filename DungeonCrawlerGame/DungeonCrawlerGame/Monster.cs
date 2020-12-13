using System;
using System.Collections.Generic;

namespace DungeonCrawlerGame
{
    abstract class Monster
    {
        private string name;
        private double currentHealthPoints;
        private double maxHealthPoints;
        private int experience;
        private double damage;
        private double chanceOfAppearance;

        public double MaxHealthPoints { get => maxHealthPoints; set => maxHealthPoints = value; }
        public int Experience { get => experience; set => experience = value; }
        public double Damage { get => damage; set => damage = value; }
        public double CurrentHealthPoints { get => currentHealthPoints; set => currentHealthPoints = value; }
        public double ChanceOfAppearance { get => chanceOfAppearance; set => chanceOfAppearance = value; }
        public string Name { get => name; set => name = value; }

        public abstract double Napad(ref Hero heroj, ref List<Monster> cudovista);
        public virtual int MonsterDefeated(ref List<Monster> cudovista)
        {
            return Experience;
        }

        public void Status()
        {
            Console.WriteLine(Name);
            Console.WriteLine(String.Format("HP: {0} / {1}", CurrentHealthPoints, MaxHealthPoints));
            Console.WriteLine(String.Format("Damage: {0}", Damage));
            Console.WriteLine(String.Format("EXP: {0}", Experience));
        }
    }
}
