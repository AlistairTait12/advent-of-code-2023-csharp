using AdventOfCode.DayOne;
using AdventOfCode.DayTwo;
using FakeItEasy;
using FluentAssertions;

namespace AdventOfCodeTests.DayTwoTests;

[TestFixture]
public class GameListCheckerTests
{
    private GameListChecker _checker;
    private IFileWrapper _fileWrapper;

    [SetUp]
    public void SetUp()
    {
        _fileWrapper = A.Fake<IFileWrapper>();
        A.CallTo(() => _fileWrapper.ReadAllLines()).Returns(GetFileContents());
        _checker = new GameListChecker(_fileWrapper, new(12, 13, 14));
    }

    [Test]
    public void GetSumOfPossibleGameIdsReturnsSumOfIdsOfGamesWhichWerePossible()
    {
        // Act
        var actual = _checker.GetSumOfPossibleGameIds();

        // Assert
        actual.Should().Be(8);
    }

    [Test]
    public void GetPowersOfMinimumValueOfEachGameReturnsCorrectAnswer()
    {
        // Act
        var actual = _checker.GetPowersOfMinimumValueOfEachGame();

        // Assert
        actual.Should().Be(2286);
    }

    private static string[] GetFileContents() => new string[]
    {
        "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
        "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
        "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
        "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
        "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
    };
}
