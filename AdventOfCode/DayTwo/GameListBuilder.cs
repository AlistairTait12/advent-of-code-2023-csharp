using AdventOfCode.DayOne;
using System.Text.RegularExpressions;

namespace AdventOfCode.DayTwo;

public class GameListBuilder
{
    private readonly IFileWrapper _fileWrapper;
    private readonly RoundModel _overallConfig;

    public GameListBuilder(IFileWrapper fileWrapper, RoundModel overallConfig)
    {
        _fileWrapper = fileWrapper;
        _overallConfig = overallConfig;
    }

    public List<GameModel> Build()
    {
        var gameList = new List<GameModel>();

        foreach(var line in _fileWrapper.ReadAllLines())
        {
            gameList.Add(GetGameModelFromLine(line));
        }

        return gameList;
    }

    private GameModel GetGameModelFromLine(string line)
    {
        var header = line.Split(':').First();
        int id = int.Parse(header.Substring(4));

        var roundsAsStrings = line.Split(':').Last().Split(';');
        var rounds = roundsAsStrings.Select(GetRoundModelFromString);

        return new GameModel
        {
            Id = id,
            GameConfig = _overallConfig,
            Rounds = rounds.ToList()
        };
    }

    private RoundModel GetRoundModelFromString(string roundAsString)
    {
        var cubeInfos = roundAsString.Split(',');
        var red = cubeInfos.FirstOrDefault(cubeInfo => cubeInfo.ToLower().Contains("red"));
        var green = cubeInfos.FirstOrDefault(cubeInfo => cubeInfo.ToLower().Contains("green"));
        var blue = cubeInfos.FirstOrDefault(cubeInfo => cubeInfo.ToLower().Contains("blue"));

        var redVal = red is null 
            ? "0"
            : new Regex(@"\d+").Match(red).Value;
        var greenVal = green is null
            ? "0"
            : new Regex(@"\d+").Match(green).Value;
        var blueVal = blue is null 
            ? "0"
            : new Regex(@"\d+").Match(blue).Value;

        int.TryParse(redVal, out var redCount);
        int.TryParse(greenVal, out var greenCount);
        int.TryParse(blueVal, out var blueCount);

        return new RoundModel(redCount, greenCount, blueCount);
    }
}
