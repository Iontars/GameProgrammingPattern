namespace OpenClosedPrinciple;

class Rectangle: Shape
{
    public Rectangle(float width, float heidht)
    {
        Width = width;
        Heidht = heidht;
    }

    public float Width { get; private set; }
    public float Heidht { get; private set; }
    
    public override float CalculateArea()
    {
        return Width * Heidht;
    }
}