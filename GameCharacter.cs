namespace Bossfight;

public class GameCharacter
{
    
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Stamina { get; set; }
    public bool IsHero { get; }


    private bool isRecharging;


    public GameCharacter(int health, int strength, int stamina, bool isHero) // Constructor
    {
        Health = health;
        Strength = strength;
        Stamina = stamina;
        IsHero = isHero;
        isRecharging = false;
    }


    public void Fight(GameCharacter target)
    {
        if (Stamina <= 0)
        {
            Recharge();
            return;
        }

        if (!IsHero)
        {
            Strength = Program.RandomBossStrength();
        }

        if (isRecharging)
        {
            Console.WriteLine($"{(IsHero ? "Hero" : "Boss")} can't attack this round.\n");
            isRecharging = false;
            return;
        }

        if (Stamina <= 0)
        {
            Recharge();
            return;
        }

        target.Health -= Strength;


        if (target.Health < 0)
        {
            target.Health = 0;
        }

        if (IsHero)
        {
            Stamina -= 10;
            Console.WriteLine("Hero lost 10 stamina.\n");
            Console.WriteLine($"Boss got hit with {Strength} damage.");
            Console.WriteLine($"Boss now has {target.Health} health left.\n");
        }
        else if(target.IsHero)
        {
            Stamina -= 10;
            Console.WriteLine("Boss lost 10 stamina.\n");
            Console.WriteLine($"Hero got hit with {Strength} damage.");
            Console.WriteLine($"Hero now has {target.Health} health left.\n");
        }   
    }

    public void Recharge()
    {
        if (IsHero)
        {
            Stamina = 40;
            Console.WriteLine("Hero needs to recharge and therefore cant't attack the next round.");
            Console.WriteLine("Hero is recharging.\n");
        }

        else
        {
            Stamina = 10;
            Console.WriteLine("Boss needs to recharge and therefore cant't attack the next round.");
            Console.WriteLine("Boss is recharging.");
        }
        
        isRecharging = true;
    }
}