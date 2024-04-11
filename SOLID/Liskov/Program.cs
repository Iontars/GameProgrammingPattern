using System.Numerics;
using System.Text;

namespace Liskov;

class Program
{
    static void Main(string[] args)
    {
        var garages = new List<Garage>
        {
            new Garage(new Car(100)),
            new Garage(new TinyCar(20)),
        };

        foreach (var item in garages)
        {
            item.CurentVehicle.Report();
            item.CurentVehicle.Move();
        }
    }
}

public abstract class Vehicle
{
    public virtual float FrameHp { get; set; }
    protected virtual float BaseSpeed { get; init; }
    public float CurrentSpeed { get; set; }
    protected abstract string? Message { get; set; } 
    
    protected StringBuilder builder = new ();

    public virtual void Report()
    {
        builder.Append($"{BaseSpeed} {Message}");
        Console.WriteLine(builder.ToString());
    }

    public bool isAbleToMove { get; set; }
 
}

public class Car : Vehicle, IMovableXAxis, IMovableZAxis
{
    public bool isAbleToMove { get; set; }
    public bool isAbleToForwordMove { get; set; }
    public bool isAbleToBackMove { get; set; }

    public bool isAbleToLeftMove { get; set; }
    public bool isAbleToRightMove { get; set; }
    protected override string? Message { get; set; } = "From Car";
    
    public Car(float speed)
    {
        BaseSpeed = speed;
    }

    
    public virtual void Move()
    {
        Console.WriteLine("Выезжаю с гаража громко");
    }
}

public class TinyCar : Car
{
    protected override string? Message { get; set; } = "From TinyCar";
    
    public TinyCar(float speed) : base(speed) {}
    
    
    
    public override void Move()
    {
        Console.WriteLine("Выезжаю с гаража тихо");
    }
}

public class Bus : Vehicle
{
    protected override string? Message { get; set; } = "From Bus";
    
    public Bus(float speed)
    {
        BaseSpeed = speed;
    }
}

public class Garage 
{
    public Car CurentVehicle { get; set; }
    
    public Garage(Car vehicle)
    {
        CurentVehicle = vehicle;
    }
}

public interface IMovable
{
    public bool isAbleToMove { get; set; }

    public void Move();
}

public interface IMovableXAxis : IMovable
{
    public bool isAbleToForwordMove { get; set; }
    public bool isAbleToBackMove { get; set; }
    
}

public interface IMovableZAxis : IMovable
{
    public bool isAbleToLeftMove { get; set; }
    public bool isAbleToRightMove { get; set; }
    

}

public interface IMovableYAxis : IMovable
{
    public bool isAbleToUpMove { get; set; }
    public bool isAbleToDownMove { get; set; }
}

