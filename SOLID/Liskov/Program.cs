using System.Runtime.CompilerServices;
using System.Text;
using static System.Console;

namespace Liskov;

internal class Program
{
    static void Main(string[] args)
    {
        var garages = new List<Garage>
        {
            new Garage(new TinyCar(10, 100 )),
            new Garage(new HugeCar(30, 30)),
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
    protected Vehicle(float frameHp, float baseSpeed)
    {
        FrameHp = frameHp;
        BaseSpeed = baseSpeed;
    }

    public float FrameHp { get; private set; }
    protected float BaseSpeed { get; private set; }
    public float CurrentSpeed { get; set; }
    protected abstract string? Message { get; set; } 
    
    protected StringBuilder builder = new ();

    // можно не помечать как virtual, так как в производных классах в принципе отсутсвуте описание метода Report, производные
    // классы, при вызове в них методов Report, автоматически перезапишут метод базового класса как если бы использовалась конструкция
    // override/virtual
    public void Report()
    {
        Message = "скорость " + GetType().FullName;
        builder.Append($"{BaseSpeed} {Message}");
        WriteLine(builder.ToString());
    }

    public bool isAbleToMove { get; set; }
}

internal abstract class Car : Vehicle, IMovableXAxis, IMovableZAxis
{
    protected override string? Message { get; set; }
    public new bool isAbleToMove { get; set; }
    public bool isAbleToForwardMove { get; set; }
    public bool isAbleToBackMove { get; set; }
    public bool isAbleToLeftMove { get; set; }
    public bool isAbleToRightMove { get; set; }
    
    // Если в производных классах Car методы Move() имеют описание, даже с пустым телом метода, при вызое Move()
    // с производных классов через апкаст, всегда будет вызываться метод из базового класса, поэтому, что бы получить
    // доступ к методам производных классов необходимо использовать конструкцию abstract/override или virtual/override
    public abstract void Move();

    protected Car(float frameHp, float baseSpeed) : base(frameHp, baseSpeed)
    {
        
    }
}

internal class TinyCar : Car
{
    protected override string? Message { get; set; } = "From TinyCar";
    
    public override void Move()
    {
        WriteLine("Выезжаю с гаража тихо");
    }

    public TinyCar(float frameHp, float baseSpeed) : base(frameHp, baseSpeed)
    {
        
    }
}

internal class HugeCar : Car
{
    protected override string? Message { get; set; } = "From TinyCar";
    
    public override void Move()
    {
        WriteLine("Выезжаю с гаража громко");
    }

    public void Jump()
    {
        
    }

    public HugeCar(float frameHp, float baseSpeed) : base(frameHp, baseSpeed)
    {
        
    }
    
}

public abstract class RoboCar : Vehicle, IMovableXAxis, IMovableYAxis, IMovableZAxis
{
    protected override string? Message { get; set; } = "From Bus";
    public bool isAbleToForwardMove { get; set; }
    public bool isAbleToBackMove { get; set; }
    public bool isAbleToUpMove { get; set; }
    public bool isAbleToDownMove { get; set; }
    public bool isAbleToLeftMove { get; set; }
    public bool isAbleToRightMove { get; set; }

    

    public virtual void Move() {}

    protected RoboCar(float frameHp, float baseSpeed) : base(frameHp, baseSpeed)
    {
        
    }
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
    public bool isAbleToForwardMove { get; set; }
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

