using System;

namespace RPG
{
    public class Hero
    {   
        Random random = new Random();
        public string typeClass;
        public string[] skills;
        public string skillName;
        public bool buf = false;
        public string bufName;
        public int sleepTime = 0;
        public Hero()
        {
            Health = random.Next(100,200);
            Name = Names[random.Next(0,9)];
            Strength = random.Next(10,50);
        }

        public static string[] Names = new string[10]{
            "Kelley",
            "Winifred",
            "Michael",
            "Christina",
            "Lionel",
            "Ami",
            "Jacob",
            "Della",
            "Nicholas",
            "Rose"
        };
        public string Name { get; protected set; }
        public int Strength { get; protected set; }
        public int Health { get; set; }
        
        public virtual void Skill(out string skillName, out int damage)
        {
            skillName = "";
            damage = 0;
        }

        public void Atack(out int damage)
        {
            damage = random.Next(1, Strength);
        }

        public void GetDamage(int damage)
        {
            Health -= damage;
        }
    }
}
