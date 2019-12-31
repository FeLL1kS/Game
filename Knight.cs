using System;

namespace RPG
{
    class Knight : Hero
    {
        Random random = new Random();

        public Knight()
        : base()
        {
            typeClass = "Рыцарь";
            skills = new string[]{"Удар возмездия", "Удар с размаху", "Раскол земли"};
        }

        public override void Skill(out string skillName, out int damage)
        {
            int probability = random.Next(0, 100);
            if(probability <= 20)
            {
                skillName = "Удар возмездия";
            }
            else if(probability <= 90)
            {
                skillName = "Удар с размаху";
            }
            else
            {
                skillName = "Раскол земли";
            }

            switch(skillName)
            {
                case "Удар возмездия":
                    damage = (int)Math.Floor(Strength * 1.5);
                    break;
                case "Удар с размаху":
                    damage = (int)Math.Floor(Strength * 1.3);
                    break;
                case "Раскол земли":
                    sleepTime = 3;
                    damage = (int)Math.Floor(Strength * 2.5);
                    break;
                default:
                    damage = 0;
                    break;
            }
        }
    }
}
