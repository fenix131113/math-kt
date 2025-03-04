namespace DoubleArrayFinder
{
    class Program
    {
        private static int[,] _matrix;

        private static void Main()
        {
            Console.WriteLine("Напишите число m");
            var m = int.Parse(Console.ReadLine());
            Console.WriteLine("Напишите число n");
            var n = int.Parse(Console.ReadLine());

            _matrix = GenerateSortedMatrix(m, n);

            PrintMatrix(_matrix);

            Console.WriteLine("Напишите число k");
            var input = int.Parse(Console.ReadLine());

            FindNumberIndex(input, out var found, out var indexX, out var indexY);

            Console.WriteLine(found
                ? $"Число {input} найдено в координатах: ({indexX}, {indexY})"
                : $"Число {input} не найдено в матрице.");
        }

        private static int[,] GenerateSortedMatrix(int rows, int cols)
        {
            var matrix = new int[rows, cols];
            var values = new int[rows * cols];

            for (var i = 0; i < values.Length;)
            {
                var rnd = Random.Shared.Next(1, 100);
                
                if (values.Contains(rnd))
                    continue;
                
                values[i] = rnd;
                i++;
            }


            Array.Sort(values);

            var index = 0;
            for (var i = 0; i < rows; i++)
            for (var k = 0; k < cols; k++)
                matrix[i, k] = values[index++];

            return matrix;
        }

        private static void PrintMatrix(int[,]? matrix)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            Console.WriteLine("Сгенерированная матрица:");
            for (var i = 0; i < rows; i++)
            {
                for (var k = 0; k < cols; k++)
                    Console.Write(matrix[i, k] + "\t");

                Console.WriteLine();
            }
        }

        private static void FindNumberIndex(int number, out bool found, out int indexX, out int indexY)
        {
            var rows = _matrix.GetLength(0);
            var columns = _matrix.GetLength(1);
            var row = 0;
            var col = columns - 1;

            while (row < rows && col >= 0)
            {
                if (_matrix[row, col] == number)
                {
                    found = true;
                    indexX = row;
                    indexY = col;
                    return;
                }

                if (_matrix[row, col] > number)
                    col--;
                else
                    row++;
            }

            found = false;
            indexX = -1;
            indexY = -1;
        }
    }
}