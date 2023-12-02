using AdventOfCode.DayOne;

namespace AdventOfCodeTests.DayOneTests;

[TestFixture]
public class CalibrationLineProcessorTests
{
    [TestCase("9cbncbxclbvkmfzdnldc", 99)]
    [TestCase("treb7uchet", 77)]
    public void GetValueFromLineWithOnlyOneDigitReturnsDigitTwiceAsInteger(string line, int expected)
    {
        // Act
        var actual = CalibrationLineProcessor.GetValueFromLine(line);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("1abc2", 12)]
    [TestCase("pqr3stu8vwx", 38)]
    [TestCase("a1b2c3d4e5f", 15)]
    public void GetValueFromLineWithMultipleDigitsReturnsFirstAndLastDigitsAsInt(string line, int expected)
    {
        // Act
        var actual = CalibrationLineProcessor.GetValueFromLine(line);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("NoDigitsHere")]
    [TestCase("lskdhfkjsdhgkjf")]
    [TestCase("No digits here")]
    public void GetValueWhenThereAreNoDigitsReturnsZero(string line)
    {
        // Act
        var actual = CalibrationLineProcessor.GetValueFromLine(line);

        // Assert
        Assert.That(actual, Is.Zero);
    }
}
