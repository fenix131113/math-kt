namespace ArrayHashset;

class Program
{
    static void Main()
    {
        var origin = ReadArray();

        Console.WriteLine("Введите число k");
        var k = int.Parse(Console.ReadLine());

        HashSet<int> set = [];

        var found = false;

        foreach (var value in origin)
        {
            var need = k - value;

            if (!set.Contains(need) && set.Add(value))
                continue;

            Console.WriteLine($"[{need}, {value}]");
            found = true;
            break;
        }

        if (!found)
            Console.WriteLine("Нет двух чисел, в сумме дающих число k");
    }

    private static int[] ReadArray()
    {
        Console.WriteLine("Введите длину");
        var size = int.Parse(Console.ReadLine());

        var array = new int[size];

        for (var i = 0; i < size; i++)
        {
            Console.WriteLine("Введите число с индексом: " + i);
            var input = int.Parse(Console.ReadLine());

            if (i > 0 && input < array[i - 1])
                throw new Exception("Числа должны идти от меньшего к большему!");

            array[i] = input;
        }

        return array;
    }
}