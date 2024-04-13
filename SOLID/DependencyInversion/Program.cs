using static System.Console;

namespace DependencyInversion;

class Program
{
    static void Main(string[] args)
    {
        Switcher switcher = new Switcher();
        Door door = new Door();
        RoomLight roomLight = new RoomLight();
        
        switcher.Toggle(door);
        switcher.Toggle(roomLight);
        switcher.Toggle(roomLight);
        switcher.Toggle(door);
        WriteLine("Пока");
    }
}

public class Switcher
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
        WriteLine("Дверь открыта");
    }
    public void Deactivate()
    {
        IsActive = false;
        WriteLine("Дверь закрыта");
    }
}

public class RoomLight : ISwitchable
{
    public bool IsActive { get; set; }

    public void Activate()
    {
        IsActive = true;
        WriteLine("Свет включён");
    }

    public void Deactivate()
    {
        IsActive = true;
        WriteLine("Свет выключен");
    }
}

public interface ISwitchable
{
    public bool IsActive { get; }
    public void Activate();
    public void Deactivate();
}

