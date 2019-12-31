using System;

namespace RPG
{
    class Wizard : Hero
    {
        Random random = new Random();

        public Wizard()
        : base()
        {
            typeClass = "Маг";
            skills = new string[]{"Заворожение","Метеор"};
        }

        public override void Skill(out string skillName, out int damage)
        {
            int probability = random.Next(0, 100);
            if(probability <= 60 && sleepTime == 0)
            {
                skillName = "Заворожение";
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
                default:
                    damage = 0;
                    break;
            }
        }
    }
}
