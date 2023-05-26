/*
Dere skal lage en konsoll app som viser en battle mellom en hero og en boss.

Skriv en klasse GameCharacter som har en metode Fight(), en metode Recharge() og følgende properties:

Health, Strength, Stamina

Program.cs filen må initialisere to objekter av denne klassen, en Hero og en Boss med følgende stats:

Hero:                         Boss:
Health: 100                Health: 400
Strength: 20               Strength: 0-30
Stamina: 40                Stamina: 10

Disse to skal i kamp frem til en seirer (motstanderen sin health = 0) konsollen skal logge hvem som angriper, 
hvor mye skade som tas og hvor mye liv motstanderen har igjen etter slaget.

I en fight mister GameCharacterene like mye i Health som mostanderen har i Strength.

Hver gang en character bruker metoden Fight() mister de også 10 stamina.

Om Fight() kalles med 0 i stamina må de bruke metoden Recharge() som restorer Stamina til det de hadde da de startet kampen. 
De rundene gamecharacterene må recharge får de ikke utført noe skade.

Styrken til Bossen varierer med en random verdi mellom 0-30 for hver gang Fight() kalles. 
Om dette blir for avansert, la bossen også få en fast styrke på 20.


Eksempel på Konsollens logg når programmet har kjørt ferdig:

Enemy hit hero with 5 damage, hero now has 30 health left.
Hero hit enemy with 20 damage, enemy has 0 health left.
Hero is the winner!
*/




namespace Bossfight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BattleInfo();
        }


        public static int RandomBossStrength()
        {
            var random = new Random();
            var randomNum = random.Next(0, 31);
            return randomNum;
        }
        
        
        static void BattleInfo()
        {
            var hero = new GameCharacter(health:100, strength:20, stamina:40, isHero:true);
            var boss = new GameCharacter(health:400, strength:RandomBossStrength(), stamina:10, isHero:false);

            Console.WriteLine($"Hero starts with {hero.Health} health.");
            Console.WriteLine($"Boss starts with {boss.Health} health.\n");
            Console.WriteLine("The battle begins!");
            Console.WriteLine();

            while (true)
            {
                // Hero angriper Boss:
                Console.WriteLine("Hero attacks boss...");
                hero.Fight(attacker: hero, target: boss);

                
                if (hero.Stamina <= 0)
                {
                    hero.Recharge();
                }
                
                if (boss.Health <= 0)
                {
                    Console.WriteLine("\nBoss was defeated. Hero is the winner!");
                    break; 
                }


                // Boss angriper Hero:
                Console.WriteLine("Boss attacks hero...");
                boss.Fight(attacker: boss, target: hero);

                if (boss.Stamina <= 0)
                {
                    boss.Recharge();
                }

                if (hero.Health <= 0)
                {
                    Console.WriteLine("\nHero was defeated. Boss is the winner!");
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}