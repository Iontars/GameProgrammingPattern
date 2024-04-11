namespace OpenClosedPrinciple;

class Program
{
    public Shape shape = new Circle(4);
    public Shape shape2 = new Rectangle(4,5);
    public AreaCalculator areaCalculator = new ();
    static void Main(string[] args)
    {
        Program program = new ();
        Console.WriteLine(program.areaCalculator.GetArea(program.shape));
        Console.WriteLine(program.areaCalculator.GetArea(program.shape2));
    }
}