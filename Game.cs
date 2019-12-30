using System;
using System.Collections.Generic;

namespace RPG
{
    class Game
    {
        public List<Hero> heroes = new List<Hero>();
        Logger logger = new Logger();
        Random random = new Random();
        Hero hero1;
        Hero hero2;
        int counter = 0;
        
        public void Start(int numOfHeroes)
        {
            CreateHeroes(numOfHeroes);
            while(heroes.Count > 1)
            {
                Fight();
            }
            
            Console.WriteLine($"Победитель в игре - {heroes[0].typeClass} {heroes[0].Name}");
        }

        public void CreateHeroes(int numOfHeroes)
        {

            while(numOfHeroes > 0)
            {
                switch(random.Next(0,3))
                {
                    case 0: 
                        heroes.Add(new Archer());
                        break;
                    case 1:
                        heroes.Add(new Knight());
                        break;
                    case 2:
                        heroes.Add(new Wizard());
                        break;
                    default:
                        heroes.Add(new Wizard());
                        break;
                }
                numOfHeroes--;
            }
        }

        public void Fight()
        {
            int i = random.Next(0, heroes.Count - 1);
            hero1 = heroes[i];
            heroes.RemoveAt(i);

            i = random.Next(0, heroes.Count);
            hero2 = heroes[i];
            heroes.RemoveAt(i);

            int turn = random.Next(0, 1);
            string skillName;
            int damage;
            counter++;
            Console.WriteLine("=========");
            Console.WriteLine($"Бой №{counter}");

            while (true)
            {
                if(turn == 0)
                {
                    if(hero2.sleepTime == 0)
                    {
                        if(hero1.buf)
                        {
                            if(random.Next(0,10) > 6)
                            {
                                hero1.Skill(out skillName, out damage);
                                hero2.GetDamage(damage + 5);
                                logger.Skill(hero1, hero2, skillName, damage);
                            }
                            else
                            {
                                hero1.Atack(out damage);
                                hero2.GetDamage(damage + 5);
                                logger.Atack(hero1, hero2, damage);
                            }
                        }
                        else
                        {
                            if(random.Next(0,10) > 6)
                            {
                                hero1.Skill(out skillName, out damage);
                                hero2.GetDamage(damage);
                                logger.Skill(hero1, hero2, skillName, damage);
                            }
                            else
                            {
                                hero1.Atack(out damage);
                                hero2.GetDamage(damage);
                                logger.Atack(hero1, hero2, damage);
                            }
                        }
                    }
                    else
                    {
                        logger.Sleep(hero1);
                        hero2.sleepTime--;
                    }

                    if(hero2.Health <= 0)
                    {
                        hero1.sleepTime = 0;
                        hero1.buf = false;
                        heroes.Add(hero1);
                        logger.Winner(hero1);
                        logger.Death(hero2);
                        break;
                    }

                    turn = 1;
                }
                else
                {
                    if(hero1.sleepTime == 0)
                    {
                        if(hero2.buf)
                        {
                            if(random.Next(0,10) > 6)
                            {
                                hero2.Skill(out skillName, out damage);
                                hero1.GetDamage(damage + 5);
                                logger.Skill(hero2, hero1, skillName, damage);
                            }
                            else
                            {
                                hero2.Atack(out damage);
                                hero1.GetDamage(damage + 5);
                                logger.Atack(hero2, hero1, damage);
                            }
                        }
                        else
                        {
                            if(random.Next(0,10) > 6)
                            {
                                hero2.Skill(out skillName, out damage);
                                hero1.GetDamage(damage);
                                logger.Skill(hero2, hero1, skillName, damage);
                            }
                            else
                            {
                                hero2.Atack(out damage);
                                hero1.GetDamage(damage);
                                logger.Atack(hero2, hero1, damage);
                            }
                        }
                    }
                    else
                    {
                        logger.Sleep(hero2);
                        hero1.sleepTime--;
                    }

                    if(hero1.Health <= 0)
                    {
                        hero2.sleepTime = 0;
                        hero2.buf = false;
                        heroes.Add(hero2);
                        logger.Winner(hero2);
                        logger.Death(hero1);
                        break;
                    }

                    turn = 0;
                }
            }
        }
    }
}
