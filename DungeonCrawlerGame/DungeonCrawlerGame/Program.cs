using System;
using System.Collections.Generic;

namespace DungeonCrawlerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gotovaIgra = false, herojZiv = true, cudovisteZivo = true, ponoviRundu = false;
            Random random = new Random();
            int opcijaHeroja, odabirNapadaHeroja, odabirNapadaCudovista;
            Hero heroj;
            Monster cudoviste;
            List<Monster> cudovista = new List<Monster>();

            while (gotovaIgra == false)
            {
                Console.WriteLine("Odaberi broj uz tip heroja kojeg zelis:\n1 - Warrior\n2 - Mage\n3 - Ranger");
                opcijaHeroja = Convert.ToInt32(Console.ReadLine());
                heroj = FunctionsForMain.OdaberiHeroja(opcijaHeroja);
                cudovista = FunctionsForMain.GenerirajCudovista(10);

                for (int i = 0; i < cudovista.Count && herojZiv == true; i++)
                {
                    cudoviste = cudovista[i];
                    while (herojZiv == true && cudovisteZivo == true)
                    {

                        heroj.Status();
                        Console.WriteLine();
                        cudoviste.Status();

                        Console.WriteLine("Odaberi vrstu napada:\n1 - Direktan napada\n2 - Napad s boka\n3 - Protunapad");
                        odabirNapadaHeroja = Convert.ToInt32(Console.ReadLine());
                        odabirNapadaCudovista = random.Next(3) + 1;

                        if (odabirNapadaHeroja == 1 && odabirNapadaCudovista == 2 || odabirNapadaHeroja == 2 && odabirNapadaCudovista == 3 || odabirNapadaHeroja == 3 && odabirNapadaCudovista == 1)
                        {
                            cudoviste.CurrentHealthPoints -= heroj.Napad(ref ponoviRundu);
                            if (cudoviste.CurrentHealthPoints <= 0)
                            {
                                cudovisteZivo = false;
                            }
                        }
                        if (odabirNapadaHeroja == 2 && odabirNapadaCudovista == 1 || odabirNapadaHeroja == 3 && odabirNapadaCudovista == 2 || odabirNapadaHeroja == 1 && odabirNapadaCudovista == 3)
                        {
                            heroj.CurrentHealthPoints -= cudoviste.Napad(ref heroj, ref cudovista);
                            if (heroj.CurrentHealthPoints <= 0)
                            {
                                herojZiv = heroj.HeroDefeated();
                            }
                        }
                    }

                    if (cudovisteZivo == false)
                    {
                        heroj.ObnoviHealth();
                        heroj.CollectExperience(cudoviste.MonsterDefeated(ref cudovista));
                    }

                    Console.WriteLine("Zelis li potrositi pola experienca da obnovis sve zivotne bodove ? Odgovori sa da ili ne");
                    if (Console.ReadLine().Trim().ToLower().Equals("da"))
                    {
                        heroj.Experience = (int)(heroj.Experience * 0.5);
                        heroj.CurrentHealthPoints = heroj.MaxHealthPoints;
                    }
                }

                if (herojZiv == true)
                {
                    Console.WriteLine("POBJEDA");
                }
                else
                {
                    Console.WriteLine("GAME OVER");
                    Console.WriteLine("Zelis li pokusati ponovo ? Odgovir sa da ili ne");
                    if (Console.ReadLine().Trim().ToLower().Equals("ne"))
                    {
                        gotovaIgra = true;
                    }
                }

            }

        }
    }
}
