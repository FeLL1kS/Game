using System;

namespace RPG
{
    public class Archer : Hero
    {
        Random random = new Random();

        public Archer()
        : base()
        {
            typeClass = "Лучник";
            skills = new string[]{"Огненные стрелы", "Град стрел", "Мощный выстрел"};
        }

        public override void Skill(out string skillName, out int damage)
        {
            int probability = random.Next(0, 100);
            if(!buf)
            {
                if(probability <= 20)
                {
                    skillName = "Мощный выстрел";
                }
                else if(probability <= 90)
                {
                    skillName = "Огненные стрелы";
                }
                else
                {
                    skillName = "Град стрел";
                }
            }
            else
            {
                if(probability <= 70)
                {
                    skillName = "Мощный выстрел";
                }
                else
                {
                    skillName = "Град стрел";
                }
            }

            switch(skillName)
            {
                case "Мощный выстрел":
                    damage = (int)(Strength * 1.5);
                    break;
                case "Град стрел":
                    damage = (int)(Strength * 2.5);
                    break;
                case "Огненные стрелы":
                    bufName = "Огненные стрелы";
                    buf = true;
                    bufDamage = 5;
                    damage = 0;
                    break;
                default:
                    damage = 0;
                    break;
            }
        }
    }
}
