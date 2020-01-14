using System;
using System.Collections.Generic;

namespace RPG
{
    public class Hero
    {   
        public List<string> items = new List<string>();
        Random random = new Random();
        private int health;
        // private int mana = 100;
        public string typeClass;
        public string skillName;
        public string[] skills;
        public bool buf = false;
        public string bufName;
        public int bufDamage;
        public int sleepTime = 0;
        public int maxHealth;
        public static string[] Names = new string[20]{
            "Kelley",
            "Winifred",
            "Michael",
            "Christina",
            "Lionel",
            "Ami",
            "Jacob",
            "Della",
            "Nicholas",
            "Rose",
            "Edward",
            "Caroline",
            "Clyde",
            "Tiffany",
            "Leo",
            "Marion",
            "Stephen",
            "Maryann",
            "Virgil",
            "Betty"
        };
        public static string[] Items = new string[]{
            "Зелье лечения",
            "Зелье маны",
            "Зелье силы"
        };

        public Hero()
        {
            Health = random.Next(100,201);
            maxHealth = Health;
            Name = Names[random.Next(0,21)];
            Strength = random.Next(10,51);
            items.Add(Items[random.Next(0,3)]);
        }

        public string Name { get; protected set; }
        public int Strength { get; protected set; }
        // public int Mana 
        // { 
        //     get
        //     {
        //         return mana;
        //     } 
        //     set
        //     {
        //         if(value > 100)
        //         {
        //             mana = 100;
        //         }
        //         else
        //         {
        //             mana = value;
        //         }
        //     } 
        // }
        public int Health 
        { 
            get
            {
                return health;
            } 
            set
            {
                if(value > maxHealth)
                {
                    health = maxHealth;
                }
                else
                {
                    health = value;
                }
            }
        }
        
        public virtual void Skill(out string skillName, out int damage)
        {
            skillName = "";
            damage = 0;
        }

        public virtual void Atack(out int damage)
        {
            damage = random.Next(1, Strength);
        }

        public void GetDamage(int damage)
        {
            Health -= damage;
        }

        public void UseItem(string item)
        {
            switch(item)
            {
                case "Зелье лечения":
                    Health += 50;
                    break;
                case "Зелье силы":
                    Strength += 20;
                    break;
            }
        }
    }
}
