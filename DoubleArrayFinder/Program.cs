namespace DoubleArrayFinder
{
    class Program
    {
        private static readonly int[,] _matrix =
        {
            { 2, 5, 7, 11, 13 },
            { 4, 6, 9, 17, 20 },
            { 7, 9, 11, 19, 21 },
            { 8, 13, 14, 23, 38 }
        };

        private static void Main()
        {
            var input = int.Parse(Console.ReadLine());

            FindNumberIndex(input, out var found, out var indexX, out var indexY);

            Console.WriteLine(found
                ? $"Число {input} найдено в координатах: ({indexX}, {indexY})"
                : $"Число {input} не найдено в матрице.");
        }

        private static void FindNumberIndex(int number, out bool found, out int indexX, out int indexY)
        {
            var rows = _matrix.GetLength(0);
            var columns = _matrix.GetLength(1);
            int row = 0, col = columns - 1;

            while (row < rows && col >= 0)
            {
                if (_matrix[row, col] == number)
                {
                    found = true;
                    indexX = col;
                    indexY = row;
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