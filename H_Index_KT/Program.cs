namespace H_Index_KT;

class Program
{
    private static void Main()
    {
        Console.WriteLine("Введите длину масива");
        var lenght = int.Parse(Console.ReadLine());
        var inputArray = new int[lenght];
        
        for (var i = 0; i < lenght; i++)
        {
            Console.WriteLine($"Введите элемент номер {i + 1}");
            inputArray[i] = int.Parse(Console.ReadLine());
        }
        
        inputArray = SortArray(inputArray);
        Console.WriteLine(string.Join(",", inputArray));
        Console.WriteLine("H index = " + GetHIndex(inputArray));
    }

    private static int[] SortArray(int[] array)
    {
        var count = new int[array.Length];

        foreach (var t in array)
            count[t - 1]++;

        var writeIndex = array.Length - 1;
        
        for (var index = 0; index < count.Length; index++)
        {
            var c = count[index];
            
            if (c <= 0)
                continue;
            
            for (var i = 0; i < c; i++)
            {
                array[writeIndex] = index + 1;
                writeIndex--;
            }
        }
        
        return array;
    }

    private static int GetHIndex(int[] array)
    {
        var h = 0;
        
        for (var i = 0; i < array.Length; i++)
        {
            if (array[i] >= h + 1)
                h++;
            else
                break;
        }

        return h;
    }
}