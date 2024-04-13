namespace OpenClosedPrinciple;
using static Console;

class Program
{
    public Shape shape = new Circle(4);
    public Shape shape2 = new Rectangle(4,5);
    public AreaCalculator areaCalculator = new ();
    static void Main(string[] args)
    {
        Program program = new ();
        WriteLine(program.areaCalculator.GetArea(program.shape));
        WriteLine(program.areaCalculator.GetArea(program.shape2));
    }
}

public abstract class Shape
{
    public abstract float CalculateArea();
}

class Rectangle: Shape
{
    public float Width { get; private set; }
    public float Heidht { get; private set; }
    
    public Rectangle(float width, float heidht)
    {
        Width = width;
        Heidht = heidht;
    }

    
    public override float CalculateArea()
    {
        return Width * Heidht;
    }
}

class Circle : Shape
{
    public float Radius  { get; private set; }
    
    public Circle(float radius)
    {
        Radius = radius;
    }
    
    public override float CalculateArea()
    {
        return (float)(Radius * Radius * Math.PI); 
    }
}

class AreaCalculator
{
    public float GetArea(Shape shape)
    {
        return shape.CalculateArea();
    }
}