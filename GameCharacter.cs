namespace Bossfight;

public class GameCharacter
{
    
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Stamina { get; set; }
    public bool IsHero { get; }


    public GameCharacter(int health, int strength, int stamina, bool isHero) // Constructor
    {
        Health = health;
        Strength = strength;
        Stamina = stamina;
        IsHero = isHero;
    }


    public void Fight(GameCharacter attacker, GameCharacter target)
    {
        if (!attacker.IsHero)
        {
            attacker.Strength = Program.RandomBossStrength();
        }

        target.Health -= attacker.Strength;

        if (target.Health < 0)
        {
            target.Health = 0;
        }

        if (attacker.IsHero)
        {
            attacker.Stamina -= 10;
            Console.WriteLine("Hero lost 10 stamina.\n");
            Console.WriteLine($"Boss got hit with {attacker.Strength} damage.");
            Console.WriteLine($"Boss now has {target.Health} health left.\n");
        }
        else if(target.IsHero)
        {
            attacker.Stamina -= 10;
            Console.WriteLine("Boss lost 10 stamina.\n");
            Console.WriteLine($"Hero got hit with {attacker.Strength} damage.");
            Console.WriteLine($"Hero now has {target.Health} health left.\n");
        }
    }

    public void Recharge()
    {
        switch (IsHero)
        {
            case true:
                Stamina = 40;
                Console.WriteLine("Hero recharged and got 40 stamina back.\n");
                break;
            case false:
                Stamina = 10;
                Console.WriteLine("Boss recharged and got 10 stamina back.");
                break;
        }
    }
}