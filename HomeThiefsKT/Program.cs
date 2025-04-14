namespace HomeThiefsKT;

class Program
{
    private static int[] _houses = null!;

    static void Main()
    {
        GetData();
        Console.WriteLine("Максимальная выгода = " + GetMaximumProfit());
    }

    private static void GetData()
    {
        Console.WriteLine("Введите длину улицы");
        _houses = new int[int.Parse(Console.ReadLine()!)];

        for (var i = 0; i < _houses.Length; i++)
        {
            Console.WriteLine("Введите сколько денег в доме с индексом: " + i);
            _houses[i] = int.Parse(Console.ReadLine()!);
        }
    }

    private static int GetMaximumProfit()
    {
        var prizes = new int[_houses.Length];

        prizes[0] = _houses[0];
        prizes[1] = _houses[1] > _houses[0] ? _houses[1] : _houses[0];

        for (var i = 2; i < _houses.Length; i++)
        {
            prizes[i] = prizes[i - 1] > _houses[i] + prizes[i - 2]
                ? prizes[i - 1]
                : _houses[i] + prizes[i - 2];
            
        }

        Console.WriteLine(string.Join(", ", prizes));
        return prizes[^1];
    }
}