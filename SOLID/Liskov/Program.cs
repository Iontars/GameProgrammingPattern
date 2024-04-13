using System.Text;
using static System.Console;

namespace Liskov;

internal class Program
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

    // можно не помечать как virtual, так как в производных классах в принципе отсутсвуте описание метода Report, производные
    // классы, при вызове в них методов Report, автоматически перезапишут метод базового класса как если бы использовалась конструкция
    // override/virtual
    public void Report()
    {
        builder.Append($"{BaseSpeed} {Message}");
        WriteLine(builder.ToString());
    }

    public bool isAbleToMove { get; set; }
}

internal abstract class Car : Vehicle, IMovableXAxis, IMovableZAxis
{
    protected override string? Message { get; set; } = "From Car";
    public new bool isAbleToMove { get; set; }
    public bool isAbleToForwordMove { get; set; }
    public bool isAbleToBackMove { get; set; }
    public bool isAbleToLeftMove { get; set; }
    public bool isAbleToRightMove { get; set; }

    internal Car(float speed)
    {
        BaseSpeed = speed;
    }
    
    // Если в производных классах Car методы Move() имеют описание, даже с пустым телом метода, при вызое Move()
    // с производных классов через апкаст, всегда будет вызываться метод из базового класса, поэтому, что бы получить
    // доступ к методам производных классов необходимо использовать конструкцию abstract/override или virtual/override
    public abstract void Move();
}

internal class TinyCar : Car
{
    protected override string? Message { get; set; } = "From TinyCar";
    
    internal TinyCar(float speed) : base(speed) {}
    
    public override void Move()
    {
        WriteLine("Выезжаю с гаража тихо");
    }
}

internal class HugeCar : Car
{
    protected override string? Message { get; set; } = "From TinyCar";

    internal HugeCar(float speed) : base(speed) {}
    
    public override void Move()
    {
        WriteLine("Выезжаю с гаража громко");
    }

    public void Jump()
    {
        
    }
}

public abstract class RoboCar : Vehicle, IMovableXAxis, IMovableYAxis, IMovableZAxis
{
    protected override string? Message { get; set; } = "From Bus";
    public bool isAbleToForwordMove { get; set; }
    public bool isAbleToBackMove { get; set; }
    public bool isAbleToUpMove { get; set; }
    public bool isAbleToDownMove { get; set; }
    public bool isAbleToLeftMove { get; set; }
    public bool isAbleToRightMove { get; set; }

    public RoboCar()
    {
        
    }
    
    internal RoboCar(float speed)
    {
        BaseSpeed = speed;
    }

    public virtual void Move() {}
}

internal class Garage 
{
    internal Car CurentVehicle { get; set; }
    
    internal Garage(Car vehicle)
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

