namespace Graph_KT
{
    class Program
    {
        private static readonly (int, int)[] _moves =
        [
            (1, 2), (2, 1), (2, -1), (1, -2),
            (-1, -2), (-2, -1), (-2, 1), (-1, 2)
        ];

        private static void Main()
        {
            Console.WriteLine("Введите x точки A:");
            var ax = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите y точки A:");
            var ay = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите x точки B:");
            var bx = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите y точки B:");
            var by = int.Parse(Console.ReadLine());

            var result = FindMinMoves(ax, ay, bx, by);
            Console.WriteLine($"Кратчайший путь состоит из {result} ходов");
        }

        private static int FindMinMoves(int ax, int ay, int bx, int by)
        {
            if (ax == bx && ay == by)
                return 0;

            Queue<(int x, int y, int layer)> queue = new();
            HashSet<(int, int)> visited = [];

            queue.Enqueue((ax, ay, 0));
            visited.Add((ax, ay));

            while (queue.Count > 0)
            {
                var (x, y, layer) = queue.Dequeue();

                foreach (var move in _moves)
                {
                    var nx = x + move.Item1;
                    var ny = y + move.Item2;


                    if (nx == bx && ny == by)
                        return layer + 1;

                    if (nx is < 0 or >= 100 || ny is < 0 or >= 100 || visited.Contains((nx, ny)))
                        continue;
                    
                    queue.Enqueue((nx, ny, layer + 1));
                    visited.Add((nx, ny));
                }
            }

            return -1;
        }
    }
}