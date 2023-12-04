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
}
