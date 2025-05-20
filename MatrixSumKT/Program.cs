namespace MatrixSumKT;

class Program
{
    private static int[,] _matrix;

    private static void Main()
    {
        FillMatrix();
        CalculateMaxSum();
    }

    private static void FillMatrix()
    {
        Console.WriteLine("Enter x length: ");
        var x = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter y length: ");
        var y = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter max abs:");
        var maxAbs = int.Parse(Console.ReadLine());

        _matrix = new int[x, y];

        for (var i = 0; i < _matrix.GetLength(0); i++)
        {
            Console.WriteLine();

            for (var j = 0; j < _matrix.GetLength(1); j++)
            {
                _matrix[i, j] = Random.Shared.Next(-maxAbs, maxAbs + 1);
                Console.Write("{0}\t", _matrix[i, j]);
            }
        }
    }

    private static void CalculateMaxSum()
    {
        var minusesCount = 0;
        var absSum = 0;
        var minAbs = int.MaxValue;

        for (var i = 0; i < _matrix.GetLength(0); i++)
        for (var j = 0; j < _matrix.GetLength(1); j++)
        {
            if (_matrix[i, j] < 0)
            {
                minusesCount++;
            }

            var abs = Math.Abs(_matrix[i, j]);
            absSum += abs;
            if (abs < minAbs)
                minAbs = abs;
        }

        if (minusesCount % 2 == 0)
            Console.WriteLine("Sum: " + absSum);
        else
            Console.WriteLine("Sum: " + (absSum - minAbs * 2));
    }
}