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

    [Test]
    public void GetMinimumCubesReturnsMinimumNumberOfCubesOfEachColorToPlayGame()
    {
        // Arrange
        // Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
        var expected = new RoundModel(20, 13, 6);

        var gameModel = new GameModel()
        {
            Id = 3,
            Rounds = new List<RoundModel>
            {
                new(20, 8, 6),
                new(4, 13, 5),
                new(1, 5, 0)
            }
        };

        // Act
        var actual = gameModel.GetMinimumCubes();

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    /*
     * Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
     * Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
     * Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
     * Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
     * Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
     */
}
