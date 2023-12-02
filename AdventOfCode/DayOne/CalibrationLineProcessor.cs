using System.Text.RegularExpressions;

namespace AdventOfCode.DayOne;

public static class CalibrationLineProcessor
{
    private static readonly string _digitsPattern = @"\d|one|two|three|four|five|six|seven|eight|nine";

    private static readonly Dictionary<string, int> _numbersAsWords = new()
    {
        ["one"] = 1,
        ["two"] = 2,
        ["three"] = 3,
        ["four"] = 4,
        ["five"] = 5,
        ["six"] = 6,
        ["seven"] = 7,
        ["eight"] = 8,
        ["nine"] = 9
    };

    public static int GetValueFromLine(string line)
    {
        var matches = new Regex(_digitsPattern, RegexOptions.IgnoreCase)
            .Matches(line);

        if (matches.Count is 0)
        {
            return 0;
        }

        var reversedMatches = new Regex(_digitsPattern, RegexOptions.IgnoreCase | RegexOptions.RightToLeft)
            .Matches(line);

        var digitsAsInts = GetDigitsFromLine(matches);
        var reversedConverted = GetDigitsFromLine(reversedMatches);

        digitsAsInts.Add(reversedConverted.First());

        int.TryParse($"{digitsAsInts.First()}{digitsAsInts.Last()}", out var result);
        return result;
    }

    private static List<int> GetDigitsFromLine(MatchCollection matches)
    {
        return matches.Select(match =>
        {
            int convertedDigit;
            if (!int.TryParse(match.Value, out convertedDigit))
            {
                convertedDigit = GetNumberFromWord(match.Value);
            }

            return convertedDigit;
        }).ToList();
    }

    private static int GetNumberFromWord(string word) => _numbersAsWords[word.ToLower()];
}
