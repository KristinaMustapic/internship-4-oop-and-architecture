using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame
{
    class Mage : Hero
    {

        private int currentMana;
        private int maxMana;
        private bool vratioIzMrtvih;

        public int MaxMana { get => maxMana; set => maxMana = value; }
        public int CurrentMana { get => currentMana; set => currentMana = value; }
        public bool VratioIzMrtvih { get => vratioIzMrtvih; set => vratioIzMrtvih = value; }


        public Mage(String name)
        {
            Name = name;
            Experience = 0;
            CurrentHealthPoints = MaxHealthPoints = 500;
            Damage = 30;
            CurrentMana = MaxMana = 50;
            VratioIzMrtvih = false;
        }

        public Mage(String name, double HP, double damage, int mana)
        {
            Name = name;
            CurrentHealthPoints = MaxHealthPoints = HP;
            Experience = 0;
            Damage = damage;
            CurrentMana = MaxMana = mana;
            VratioIzMrtvih = false;
        }

        public override bool HeroDefeated()
        {
            if (VratioIzMrtvih == false)
            {
                CurrentHealthPoints = MaxHealthPoints;
                VratioIzMrtvih = true;
                return false;
            }
            else
            {
                return true;
            }
        }

        public override double Napad(ref bool ponoviRundu)
        {
            Console.WriteLine("Upisi opciju napada:\n1 - Obican napad\n2 - Obnovi sve zivotne bodove");
            int opcija = Convert.ToInt32(Console.ReadLine());
            if (opcija == 1)
            {
                currentMana -= 5;
                if (currentMana < 0)
                {
                    CurrentMana = MaxMana;
                    return 0;
                }
                else
                {
                    return Damage;
                }
            }
            else
            {
                currentMana -= 15;
                if (currentMana < 0)
                {
                    CurrentMana = MaxMana;
                }
                else
                {
                    CurrentHealthPoints = MaxHealthPoints;
                }
                return 0;
            }




        }

        public override void LevelUP()
        {
            MaxHealthPoints += 10;
            Damage += 15;

            MaxMana += 10;
        }

        public override void Status()
        {
            base.Status();
            Console.WriteLine(String.Format("MP: {0} / {1}", CurrentMana, MaxMana));

        }

        public override void CollectExperience(int exp)
        {
            base.CollectExperience(exp);

            CurrentMana = MaxMana;
        }
    }
}
