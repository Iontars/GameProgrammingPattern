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
        Console.WriteLine("Дверь открыта");
    }
    public void Deactivate()
    {
        IsActive = false;
        Console.WriteLine("Дверь закрыта");
    }
}

public class RoomLight : ISwitchable
{
    public bool IsActive { get; set; }

    public void Activate()
    {
        IsActive = true;
        Console.WriteLine("Свет включён");
    }

    public void Deactivate()
    {
        IsActive = true;
        Console.WriteLine("Свет выключен");
    }
}

public interface ISwitchable
{
    public bool IsActive { get; }
    public void Activate();
    public void Deactivate();
}

