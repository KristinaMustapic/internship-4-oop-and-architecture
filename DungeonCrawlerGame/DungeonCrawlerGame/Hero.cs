using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame
{
        abstract class Hero
        {
            private String name;
            private double currentHealthPoints;
            private double maxHealthPoints;
            private int experience;
            private double damage;

            public string Name { get => name; set => name = value; }
            public double MaxHealthPoints { get => maxHealthPoints; set => maxHealthPoints = value; }
            public int Experience { get => experience; set => experience = value; }
            public double Damage { get => damage; set => damage = value; }
            public double CurrentHealthPoints { get => currentHealthPoints; set => currentHealthPoints = value; }


            public abstract double Napad(ref bool ponoviRundu);
            public abstract void LevelUP();
            public virtual void CollectExperience(int exp)
            {
                Experience += exp;
                if (Experience >= 100)
                {
                    Experience -= 100;
                    LevelUP();
                }
            }
            public void ObnoviHealth()
            {
                CurrentHealthPoints *= 1.25;
                if (CurrentHealthPoints > MaxHealthPoints)
                {
                    CurrentHealthPoints = MaxHealthPoints;
                }
            }
            public virtual void Status()
            {
                Console.WriteLine(Name);
                Console.WriteLine(String.Format("HP: {0} / {1}", CurrentHealthPoints, MaxHealthPoints));
                Console.WriteLine(String.Format("Damage: {0}", Damage));
                Console.WriteLine(String.Format("EXP: {0} / 100", Experience));
            }
            public virtual bool HeroDefeated()
            {
                return true;
            }

        }
    }
