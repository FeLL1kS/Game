﻿using System;
using System.Collections.Generic;

namespace RPG
{
    public class Game
    {
        public List<Hero> heroes = new List<Hero>();
        Logger logger = new Logger();
        Random random = new Random();
        int counter = 0;
        
        public void Start(int numOfHeroes)
        {
            CreateHeroes(numOfHeroes);
            while(heroes.Count > 1)
            {
                int i = random.Next(0, heroes.Count - 1);
                Hero hero1 = heroes[i];
                heroes.RemoveAt(i);

                i = random.Next(0, heroes.Count);
                Hero hero2 = heroes[i];
                heroes.RemoveAt(i);
                
                Fight(hero1, hero2);
            }
            
            Console.WriteLine($"\n=========\nПобедитель в игре - {heroes[0].typeClass} {heroes[0].Name}\n=========");
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

        public void Atack(Hero attacking, Hero attacked)
        {
            int damage;
        
            if(attacking.buf)
            {
                attacking.Atack(out damage);
                logger.Atack(attacking, attacked, damage);
                attacked.GetDamage(damage + attacking.bufDamage);
            }
            else
            {    
                attacking.Atack(out damage);
                logger.Atack(attacking, attacked, damage);
                attacked.GetDamage(damage);
            }
        }

        public void UseSkill(Hero attacking, Hero attacked)
        {
            int damage;
            string skillName;
            
            if(attacking.buf)
            {
                attacking.Skill(out skillName, out damage);
                logger.Skill(attacking, attacked, skillName, damage);
                attacked.GetDamage(damage + attacking.bufDamage);
            }
            else
            {    
                attacking.Skill(out skillName, out damage);
                logger.Skill(attacking, attacked, skillName, damage);
                attacked.GetDamage(damage);
            }
        }

        public bool UseItem(Hero hero)
        {
            int i = (int)Math.Floor(hero.items.Count * random.NextDouble());
            string item = hero.items[i];

            // if(item == "Зелье маны" && hero.Mana <= 50)
            // {
            //     Console.WriteLine($"\n{hero.Name} использовал {item}\n");
            //     Console.ResetColor();
            //     hero.UseItem(item);
            //     hero.items.RemoveAt(i);
            //     return true;
            // }
            
            if(item == "Зелье лечения" && hero.Health <= hero.maxHealth / 2)
            {
                logger.UseItem(hero, item);
                hero.UseItem(item);
                hero.items.RemoveAt(i);
                return true;
            }
            else if(item == "Зелье силы")
            {
                logger.UseItem(hero, item);
                hero.UseItem(item);
                hero.items.RemoveAt(i);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Win(Hero winner, Hero loser)
        {
            winner.sleepTime = 0;
            winner.buf = false;
            heroes.Add(winner);
            logger.Winner(winner);
            logger.Death(loser);
        }

        public void Fight(Hero hero1, Hero hero2)
        {
            int turn = random.Next(0, 1);
            counter++;
            Console.WriteLine("=========");
            Console.WriteLine($"Бой №{counter}");
            logger.Announcement(hero1, hero2);
            while (true)
            {
                int probability;

                if(turn == 0)
                {
                    if(hero2.sleepTime == 0)
                    {
                        probability = random.Next(0,10);

                        if(probability < 2)
                        {
                            UseSkill(hero1, hero2);
                        }
                        else if(probability < 6 && hero1.items.Count != 0)
                        {
                            if(!UseItem(hero1))
                            {
                                Atack(hero1, hero2);
                            }
                        }
                        else
                        {
                            Atack(hero1, hero2);
                        }
                    }
                    else
                    {
                        logger.Sleep(hero1);
                        hero2.sleepTime--;
                    }

                    if(hero2.Health <= 0)
                    {
                        Win(hero1, hero2);
                        foreach(string item in hero2.items)
                        {
                            hero1.items.Add(item);
                        }
                        break;
                    }

                    turn = 1;
                }
                else
                {
                    if(hero1.sleepTime == 0)
                    {
                        probability = random.Next(0,10);

                        if(random.Next(0,10) > 6)
                        {
                            UseSkill(hero2, hero1);
                        }
                        else if(probability < 6 && hero2.items.Count != 0)
                        {
                            if(!UseItem(hero2))
                            {
                                Atack(hero2, hero1);
                            }
                        }
                        else
                        {
                            Atack(hero2, hero1);
                        }
                    }
                    else
                    {
                        logger.Sleep(hero2);
                        hero1.sleepTime--;
                    }

                    if(hero1.Health <= 0)
                    {
                        Win(hero2, hero1);
                        foreach(string item in hero1.items)
                        {
                            hero2.items.Add(item);
                        }
                        break;
                    }

                    turn = 0;
                }
            }
        }
    }
}
