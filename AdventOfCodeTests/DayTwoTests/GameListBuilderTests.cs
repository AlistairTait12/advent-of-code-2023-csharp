using AdventOfCode.DayOne;
using AdventOfCode.DayTwo;
using FakeItEasy;
using FluentAssertions;

namespace AdventOfCodeTests.DayTwoTests;

[TestFixture]
public class GameListBuilderTests
{
    private IFileWrapper _fileWrapper;
    private GameListBuilder _builder;

    [SetUp]
    public void SetUp()
    {
        _fileWrapper = A.Fake<IFileWrapper>();
        A.CallTo(() => _fileWrapper.ReadAllLines()).Returns(GetFileLines());

        _builder = new GameListBuilder(_fileWrapper, new(12, 13, 14));
    }

    [Test]
    public void BuildReturnsListOfGames()
    {
        // Arrange
        var config = new RoundModel(12, 13, 14);
        var expected = new List<GameModel>
        {
            new()
            {
                Id = 1,
                GameConfig = config,
                Rounds = new()
                {
                    new(4, 0, 3),
                    new(1, 2, 6),
                    new(0, 2, 0)
                }
            },
            new()
            {
                Id = 2,
                GameConfig = config,
                Rounds = new()
                {
                    new(0, 2, 1),
                    new(1, 3, 4),
                    new(0, 1, 1),
                }
            },
            new()
            {
                Id = 3,
                GameConfig = config,
                Rounds = new()
                {
                    new(20, 8, 6),
                    new(4, 13, 5),
                    new(1, 5, 0)
                }
            },
            new()
            {
                Id = 4,
                GameConfig = config,
                Rounds = new()
                {
                    new(3, 1, 6),
                    new(6, 3, 0),
                    new(14, 3, 15)
                }
            },
            new()
            {
                Id = 5,
                GameConfig = config,
                Rounds = new()
                {
                    new(6, 3, 1),
                    new(1, 2, 2)
                }
            }
        };

        // Act
        var actual = _builder.Build();

        // Assert
        // TODO: Why does fluent assertions work but not NUnit Assert.That(actual, Is.EquivalentTo(expected));
        actual.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }

    private string[] GetFileLines() => new string[]
    {
        "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
        "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
        "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
        "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
        "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
    };
}
