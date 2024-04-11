using System.Numerics;
using System.Text;

namespace Liskov;

class Program
{
    static void Main(string[] args)
    {
        var garages = new List<Garage>
        {
            new Garage(new TinyCar(100)),
            new Garage(new HugeCar(30)),
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
    public float FrameHp { get; set; }
    protected float BaseSpeed { get; init; }
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

public abstract class Car : Vehicle, IMovableXAxis, IMovableZAxis
{
    protected override string? Message { get; set; } = "From Car";
    public new bool isAbleToMove { get; set; }
    public bool isAbleToForwordMove { get; set; }
    public bool isAbleToBackMove { get; set; }
    public bool isAbleToLeftMove { get; set; }
    public bool isAbleToRightMove { get; set; }

    protected Car(float speed)
    {
        BaseSpeed = speed;
    }
    
    public virtual void Move() {}
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

public class HugeCar : Car
{
    protected override string? Message { get; set; } = "From TinyCar";

    public HugeCar(float speed) : base(speed) {}
    
    public override void Move()
    {
        Console.WriteLine("Выезжаю с гаража громко");
    }
}

public class RoboCar : Vehicle, IMovableXAxis, IMovableYAxis, IMovableZAxis
{
    protected override string? Message { get; set; } = "From Bus";
    public bool isAbleToForwordMove { get; set; }
    public bool isAbleToBackMove { get; set; }
    public bool isAbleToUpMove { get; set; }
    public bool isAbleToDownMove { get; set; }
    public bool isAbleToLeftMove { get; set; }
    public bool isAbleToRightMove { get; set; }

    protected RoboCar(float speed)
    {
        BaseSpeed = speed;
    }

    public virtual void Move() {}
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

