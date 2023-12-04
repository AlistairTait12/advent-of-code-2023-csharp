using AdventOfCode.DayOne;

namespace AdventOfCode.DayTwo;

public class GameListChecker
{
    private readonly GameListBuilder _gameListBuilder;

    public GameListChecker(IFileWrapper fileWrapper, RoundModel gameConfig)
    {
        _gameListBuilder = new GameListBuilder(fileWrapper, gameConfig);
    }

    public int GetSumOfPossibleGameIds()
    {
        var gamesList = _gameListBuilder.Build();
        int sumOfPossibleGameIds = 0;
        foreach (var game in gamesList)
        {
            if (game.WasPossible())
            {
                sumOfPossibleGameIds += game.Id;
            }
        }

        return sumOfPossibleGameIds;
    }

    public int GetPowersOfMinimumValueOfEachGame()
    {
        var gamesList = _gameListBuilder.Build();
        var total = 0;
        foreach (var game in gamesList)
        {
            var minRound = game.GetMinimumCubes();

            var power = minRound.RedCubes * minRound.GreenCubes * minRound.BlueCubes;
            total += power;
        }

        return total;
    }
}
