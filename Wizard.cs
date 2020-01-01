using System;

namespace RPG
{
    public class Wizard : Hero
    {
        Random random = new Random();

        public Wizard()
        : base()
        {
            typeClass = "Маг";
            skills = new string[]{"Заворожение", "Метеор", "Столб огня"};
        }

        public override void Atack(out int damage)
        {
            damage = random.Next(1, Strength / 2);
        }

        public override void Skill(out string skillName, out int damage)
        {
            int probability = random.Next(0, 100);
            if(probability <= 40 && sleepTime == 0)
            {
                skillName = "Заворожение";
            }
            else if(probability <= 80)
            {
                skillName = "Столб огня";
            }
            else
            {
                skillName = "Метеор";
            }

            switch(skillName)
            {
                case "Заворожение":
                    sleepTime = 2;
                    damage = 0;
                    break;
                case "Метеор":
                    damage = (int)Math.Floor(Strength * 2.5);
                    break;
                case "Столб огня":
                    damage = (int)Math.Floor(Strength * 1.8);
                    break;
                default:
                    damage = 0;
                    break;
            }
        }
    }
}
