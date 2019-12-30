using System;

namespace RPG
{
    class Logger
    {
        public void Atack(Hero hero1, Hero hero2, int damage)
        {
            if(hero1.typeClass == "Рыцарь")
            {
                Console.WriteLine($"{hero1.typeClass} {hero1.Name} ударил мечом {hero2.typeClass} {hero2.Name} и нанёс {damage} урона.");
            } 
            else if(hero1.typeClass == "Лучник")
            {
                Console.WriteLine($"{hero1.typeClass} {hero1.Name} выстрелил в {hero2.typeClass} {hero2.Name} и нанёс {damage} урона.");
            } 
            else
            {
                Console.WriteLine($"{hero1.typeClass} {hero1.Name} ударил посохом {hero2.typeClass} {hero2.Name} и нанёс {damage} урона.");
            }
            
            if(hero1.buf)
            {
                Console.WriteLine($"{hero1.typeClass} {hero1.Name} нанёс дополнительно 5 урона из-за усиления {hero1.bufName}.");
            }
        }

        public void Skill(Hero hero1, Hero hero2, string skillName, int damage)
        {
            if(hero1.sleepTime > 0 && damage == 0)
            {
                Console.WriteLine($"{hero1.typeClass} {hero1.Name} использует умение \"{skillName}\" и оглушает {hero2.typeClass} {hero2.Name} на {hero1.sleepTime} хода.");
            }
            else if(hero1.sleepTime > 0)
            {
                Console.WriteLine($"{hero1.typeClass} {hero1.Name} использовал(-a) умение \"{skillName}\" и нанес(-ла) {hero2.typeClass} {hero2.Name} {damage} урона. {hero2.typeClass} {hero2.Name} оглушен(-а) на {hero1.sleepTime} хода.");
            }
            else
            {
                Console.WriteLine($"{hero1.typeClass} {hero1.Name} использовал(-a) умение \"{skillName}\" и нанес(-ла) {hero2.typeClass} {hero2.Name} {damage} урона.");
            }

            if(hero1.buf)
            {
                Console.WriteLine($"{hero1.typeClass} {hero1.Name} нанёс дополнительно 5 урона из-за усиления {hero1.bufName}.");
            }
        }

        public void Sleep(Hero hero)
        {
            Console.WriteLine($"{hero.typeClass} {hero.Name} оглушён и пропускает ход.");
        }

        public void Winner(Hero hero)
        {
            Console.WriteLine($"{hero.typeClass} {hero.Name} победил!");
        }

        public void Death(Hero hero)
        {
            Console.WriteLine($"{hero.typeClass} {hero.Name} погибает");
        }
    }
}
