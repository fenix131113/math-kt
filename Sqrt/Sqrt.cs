using System.Globalization;

namespace Sqrt;

public static class Sqrt
{
    public static decimal Calculate(decimal num)
    {
        var result = 0m;

        #region Split Number

        var pairs = new List<string>();

        var numChars = num.ToString(CultureInfo.CurrentCulture).ToCharArray();

        for (var i = 0; i < numChars.Length;)
        {
            if (i == 0 && numChars.Length % 2 != 0)
            {
                pairs.Add(numChars[i].ToString());
                i++;
                continue;
            }

            pairs.Add(numChars[i].ToString() + numChars[i + 1].ToString());
            i += 2;
        }

        #endregion

        var lastResult = 0m;

        for (var i = 0; i < pairs.Count; i++)
        {
            if (i == 0)
            {
                GetNearestMultipliedDownNumber(int.Parse(pairs[0]), out var res, out var mult);
                lastResult = int.Parse(pairs[0]) - res;
                result += mult;
                continue;
            }

            var newUpper = int.Parse(lastResult.ToString() + pairs[i].ToString());
            GetNearestMultiplierLastCharAndResult(result * 2, newUpper, out var res2, out var mult2);
            lastResult = newUpper - res2;
            result = result * 10 + mult2;
        }

        if (result * result != num)
        {
            Console.WriteLine("Сколько нужно цифр после запятой? - Максимум 10");
            var input = int.Parse(Console.ReadLine() ?? "2");

            if (input > 10)
                input = 10;

            for (var i = 0; i < input; i++)
            {
                var newUpper = int.Parse(lastResult.ToString() + "00");
                GetNearestMultiplierLastCharAndResult(int.Parse(result.ToString().Replace(",", "")) * 2, newUpper,
                    out var res2, out var mult2);
                lastResult = newUpper - res2;

                result = i == 0
                    ? decimal.Parse(result.ToString() + "," + mult2.ToString())
                    : decimal.Parse(result.ToString() + mult2.ToString());
            }
        }

        return result;
    }

    private static void GetNearestMultipliedDownNumber(decimal num, out decimal multiplierResult,
        out decimal multiplier)
    {
        var multi = 1;
        var result = decimal.MaxValue;
        var nextResult = decimal.MaxValue;
        while (result > num || nextResult <= num)
        {
            result = multi * multi;

            multi += 1;

            nextResult = multi * multi;
        }

        multiplierResult = result;
        multiplier = multi - 1;
    }

    private static void GetNearestMultiplierLastCharAndResult(decimal currentResult, int findingForNum,
        out decimal multiplierResult, out decimal multiplier)
    {
        var multi = 1;
        var result = decimal.MaxValue;
        var nextResult = decimal.MaxValue;

        while (result > findingForNum || nextResult <= findingForNum)
        {
            var tempResult = int.Parse(currentResult.ToString(CultureInfo.CurrentCulture) + multi.ToString());
            result = tempResult * multi;

            multi += 1;

            nextResult = tempResult * multi;
        }

        multiplierResult = result;
        multiplier = multi - 1;
    }
}