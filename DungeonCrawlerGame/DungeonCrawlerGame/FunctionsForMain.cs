using System;
using System.Collections.Generic;

namespace DungeonCrawlerGame
{
    class FunctionsForMain
    {
        public static List<Monster> GenerirajCudovista(int broj)
        {
            List<Monster> cudovista = new List<Monster>();
            double randomBroj;
            Random random = new Random();
            double goblinProbability = new Goblin().ChanceOfAppearance;
            double bruteProbability = new Brute().ChanceOfAppearance;

            for (int i = 0; i < broj; i++)
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

            return cudovista;
        }


        public static Hero OdaberiHeroja(int opcija)
        {
            string unijetiPodatke, imeHeroja;
            double HP, dmg;

            Console.WriteLine("Zelis li upisati podatke za heroja ? Odgovori sa da ili ne");
            unijetiPodatke = Console.ReadLine();
            Console.WriteLine("Upisi ime heroja: ");
            imeHeroja = Console.ReadLine();


            if (opcija == 1)
            {
                if (unijetiPodatke.Trim().ToLower().Equals("da"))
                {
                    Console.WriteLine("Upisi koliko ima HP: ");
                    HP = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Upisi koliko trosi napad: ");
                    dmg = Convert.ToDouble(Console.ReadLine());

                    return new Warrior(imeHeroja, HP, dmg);
                }
                else
                {
                    return new Warrior(imeHeroja);
                }
            }
            else if (opcija == 2)
            {
                if (unijetiPodatke.Trim().ToLower().Equals("da"))
                {
                    Console.WriteLine("Upisi koliko ima HP: ");
                    HP = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Upisi koliko trosi napad: ");
                    dmg = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Upisi koliko ima mane: ");
                    int mana = Convert.ToInt32(Console.ReadLine());

                    return new Mage(imeHeroja, HP, dmg, mana);
                }
                else
                {
                    return new Mage(imeHeroja);
                }
            }
            else if (opcija == 3)
            {
                if (unijetiPodatke.Trim().ToLower().Equals("da"))
                {
                    Console.WriteLine("Upisi koliko ima HP: ");
                    HP = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Upisi koliko trosi napad: ");
                    dmg = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Upisi koliko ima critical sansu: ");
                    int critSansa = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Upisi koliko ima stun sansu: ");
                    int stunSansa = Convert.ToInt32(Console.ReadLine());

                    return new Ranger(imeHeroja, HP, dmg, critSansa, stunSansa);
                }
                else
                {
                    return new Ranger(imeHeroja);
                }
            }
            else
            {
                throw new Exception("Kriva opcija");
            }
        }
    }
}
