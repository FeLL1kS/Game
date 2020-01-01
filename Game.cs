using System;
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
                Fight();
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
                attacked.GetDamage(damage + 5);
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
                attacked.GetDamage(damage + 5);
            }
            else
            {    
                attacking.Skill(out skillName, out damage);
                logger.Skill(attacking, attacked, skillName, damage);
                attacked.GetDamage(damage);
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

        public void Fight()
        {
            int i = random.Next(0, heroes.Count - 1);
            Hero hero1 = heroes[i];
            heroes.RemoveAt(i);

            i = random.Next(0, heroes.Count);
            Hero hero2 = heroes[i];
            heroes.RemoveAt(i);

            int turn = random.Next(0, 1);
            counter++;
            Console.WriteLine("=========");
            Console.WriteLine($"Бой №{counter}");
            logger.Announcement(hero1, hero2);
            while (true)
            {
                if(turn == 0)
                {
                    if(hero2.sleepTime == 0)
                    {
                        if(random.Next(0,10) > 6)
                        {
                            UseSkill(hero1, hero2);
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
                        break;
                    }

                    turn = 1;
                }
                else
                {
                    if(hero1.sleepTime == 0)
                    {
                        if(random.Next(0,10) > 6)
                        {
                            UseSkill(hero2, hero1);
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
                        break;
                    }

                    turn = 0;
                }
            }
        }
    }
}
