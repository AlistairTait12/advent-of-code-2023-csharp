using AdventOfCode.DayTwo;

namespace AdventOfCodeTests.DayTwoTests;

[TestFixture]
public class GameModelTests
{
    [Test]
    public void GameWasPossibleWhereEveryRoundIsPossibleReturnsTrue()
    {
        // Arrange
        // Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
        var rounds = new List<RoundModel>
        {
            new(4, 0, 3),
            new(1, 2, 6),
            new(0, 2, 0)
        };

        var game = new GameModel
        {
            Id = 1,
            GameConfig = new(12, 13, 14),
            Rounds = rounds
        };

        // Act
        var actual = game.WasPossible();

        // Assert
        Assert.That(actual, Is.True);
    }

    [Test]
    public void GameWasPossibleWhereAnySingleRoundIsNotPossibleReturnsFalse()
    {
        // Arrange
        // Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
        var rounds = new List<RoundModel>
        {
            new(20, 8, 6),
            new(4, 13, 5),
            new(1, 5, 0)
        };

        var game = new GameModel
        {
            Id = 3,
            GameConfig = new(12, 13, 14),
            Rounds = rounds
        };

        // Act
        var actual = game.WasPossible();

        // Assert
        Assert.That(actual, Is.False);
    }
}
