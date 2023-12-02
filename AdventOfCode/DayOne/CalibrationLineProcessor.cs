using System.Text.RegularExpressions;

namespace AdventOfCode.DayOne;

public static class CalibrationLineProcessor
{
    public static int GetValueFromLine(string line)
    {
        var digitRegex = new Regex(@"\d");
        var matches = digitRegex.Matches(line);

        if (matches.Count is 0)
        {
            return 0;
        }

        int.TryParse($"{matches.First()}{matches.Last()}", out var result);
        return result;
    }
}
