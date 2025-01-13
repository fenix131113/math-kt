namespace Sqrt;

class Program
{
    private static void Main()
    {
        Console.WriteLine("Выберите целое число...");
        Console.WriteLine(Sqrt.Calculate(int.Parse(Console.ReadLine())));
    }
}