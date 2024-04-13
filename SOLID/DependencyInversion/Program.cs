using Console = System.Console;

namespace DependencyInversion;

class Program
{
    static void Main(string[] args)
    {
        Switch @switch = new Switch();
        Door door = new Door();

        for (int i = 0; i < 5; i++)
        {
            @switch.Toggle(door);
        }
    }
}

public class Switch 
{
    private ISwitchable? client;
    public void Toggle(ISwitchable obj)
    {
        client = obj;
        
        if (obj.IsActive)
        {
            client.Deactivate();
        }
        else
        {
            client.Activate();
        }
    }
}
public class Door : ISwitchable
{
    public bool IsActive { get; set; }

    public void Activate()
    {
        IsActive = true;
        Console.WriteLine("The door is open.");
    }
    public void Deactivate()
    {
        IsActive = false;
        Console.WriteLine("The door is closed.");
    }
}

public interface ISwitchable
{
    public bool IsActive { get; }
    public void Activate();
    public void Deactivate();
}