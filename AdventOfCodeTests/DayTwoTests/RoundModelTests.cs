using AdventOfCode.DayTwo;

namespace AdventOfCodeTests.DayTwoTests;

[TestFixture]
public class RoundModelTests
{
    [Test]
    public void RoundWasPossibleWhereConfigurationContainsLessThanOrEqualToOfAnyCubeReturnsTrue()
    {
        // Arrange
        var configuration = new RoundModel(12, 13, 14);
        var round = new RoundModel(blue: 3, red: 4, green: 0);

        // Act
        var actual = round.WasPossible(configuration);

        // Assert
        Assert.That(actual, Is.True);
    }

    [Test]
    public void RoundWasPossibleWhereConfigurationContainsMoreOfOneCubeThanAnyColorReturnsFalse()
    {
        // Arrange
        var configuration = new RoundModel(12, 13, 14);

        // 8 green, 6 blue, 20 red
        var round = new RoundModel(green: 8, blue: 6, red: 20);

        // Act
        var actual = round.WasPossible(configuration);

        // Assert
        Assert.That(actual, Is.False);
    }
}
