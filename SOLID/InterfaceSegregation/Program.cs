using static System.Console;

namespace InterfaceSegregation;

class Program
{
    static void Main(string[] args)
    {
        var enemyPool = new List<Enemy>
        {
            new Archer(), new Warrior()
        };
        
        var damageLogStorage = new List<Actor>
        {
            new Archer(), new Warrior(), new Player(), new NPC()
        };

        foreach (var item in enemyPool) item.TakeAim();
        for (int i = 0; i < 20; i++) Write("="); WriteLine();
        foreach (var item in damageLogStorage) item.TakeDamage(new Random().Next(1, 50));
    }
}

interface IDamagable
{
    void TakeDamage(float damage);
}

interface IClonable
{
    
}

interface ITalkable
{
    
}

interface IControlable
{
    public void InputControl();
}

interface IIAMovable
{
    public void AiMove();
}

interface IHeroTargeting
{
    void TakeAim();
}

public abstract class Wall : IDamagable, IClonable
{
    public void TakeDamage(float damage)
    {
        WriteLine($"получен урон в размере {damage}");
    }
}

public abstract class Actor : ITalkable, IDamagable
{ 
    
    public virtual void AiMove() {}
    public void TakeDamage(float damage)
    {
        WriteLine($"получен урон в размере {damage}");
    }
}

public class Player : Actor, IControlable
{
    public virtual void InputControl()
    {
        
    }
}

public class NPC : Actor, IIAMovable
{
    
}

public abstract class Enemy : Actor, IHeroTargeting
{
    public abstract void TakeAim();
}

public class Archer : Enemy
{
    public override void TakeAim()
    {
        WriteLine("Целюсь с оружия дальнего боя");
    }
}

public class Warrior : Enemy
{
    public override void TakeAim()
    {
        WriteLine("Замахиваюсь оружием ближнего боя");
    }
}

public class СoncreteWall : Wall 
{
    
}