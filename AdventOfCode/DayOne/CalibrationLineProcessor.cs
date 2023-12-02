using System.Text.RegularExpressions;

namespace AdventOfCode.DayOne;

public static class CalibrationLineProcessor
{
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
        // Get all matches
        var digitRegex = new Regex(
            @"\d|one|two|three|four|five|six|seven|eight|nine",
            RegexOptions.IgnoreCase);
        var matches = digitRegex.Matches(line);
        
        // Get all matches where words potentially overlap
        var reversedRegex = new Regex(
            @"\d|one|two|three|four|five|six|seven|eight|nine",
            RegexOptions.RightToLeft);

        var reversedMatches = reversedRegex.Matches(line);

        if (matches.Count is 0)
        {
            return 0;
        }

        // Map MatchCollection to a List<int>
        var converted = GetDigitsFromLine(matches);
        var reversedConverted = GetDigitsFromLine(reversedMatches);

        converted.Add(reversedConverted.First());

        int.TryParse($"{converted.First()}{converted.Last()}", out var result);
        return result;
    }

    private static List<int> GetDigitsFromLine(MatchCollection matches)
    {
        var digits = matches.Select(match =>
        {
            var pattern = new Regex(@"\d");
            int convertedDigit;

            if (!pattern.IsMatch(match.Value))
            {
                convertedDigit = GetNumberFromWord(match.Value);
            }
            else
            {
                int.TryParse(match.Value, out convertedDigit);
            }

            return convertedDigit;
        });

        return digits.ToList();
    }

    private static int GetNumberFromWord(string word) => _numbersAsWords[word.ToLower()];
}
