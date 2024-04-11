namespace OpenClosedPrinciple;

class Circle : Shape
{
    public Circle(float radius)
    {
        Radius = radius;
    }

    public float Radius  { get; private set; }
    
    public override float CalculateArea()
    {
        return (float)(Radius * Radius * Math.PI); 
    }
}