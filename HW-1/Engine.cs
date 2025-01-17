namespace HW_1;

public class Engine
{
    public string PedalSize { get; }

    public Engine(string pedalSize)
    {
        PedalSize = pedalSize;
    }

    public override string ToString()
    {
        return $"Двигатель с педалью: {PedalSize}";
    }
}