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
            new Archer(), new Warrior(), new Player(), new Friend()
        };

        foreach (var item in enemyPool) item.TakeAim();
        for (int i = 0; i < 20; i++) Write("="); WriteLine();
        foreach (var item in damageLogStorage)
        {
            Write($"Id сущности {item.Id} - ");
            item.TakeDamage(new Random().Next(1, 50));
        }
    }
}

public interface IIdentifiable
{
    public uint Id { get; set; }
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

public abstract class Wall :  IDamagable, IClonable, IIdentifiable
{
    public void TakeDamage(float damage)
    {
        WriteLine($"получен урон в размере {damage}");
    }
    public virtual uint Id { get; set; }
}

public abstract class Actor : ITalkable, IDamagable, IIdentifiable
{ 
    public virtual void AiMove() {}
    public void TakeDamage(float damage)
    {
        WriteLine($"получен урон в размере {damage}");
    }

    public virtual uint Id { get; set; }
}

public class Player : Actor, IControlable
{
    public override uint Id { get; set; } = 1;
    
    public virtual void InputControl() {}
}

public class Friend : Actor, IIAMovable
{
    public override uint Id { get; set; } = 2;
}

public abstract class Enemy : Actor, IHeroTargeting
{
    public abstract void TakeAim();
}

public class Archer : Enemy
{
    public override uint Id { get; set; } = 3;
    
    public override void TakeAim()
    {
        WriteLine("Целюсь с оружия дальнего боя");
    }
}

public class Warrior : Enemy
{
    public override uint Id { get; set; } = 4;
    
    public override void TakeAim()
    {
        WriteLine("Замахиваюсь оружием ближнего боя");
    }
}

public class СoncreteWall : Wall
{
    public override uint Id { get; set; } = 5;
}
