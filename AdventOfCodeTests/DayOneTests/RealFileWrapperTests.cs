using AdventOfCode.DayOne;

namespace AdventOfCodeTests.DayOneTests;

[TestFixture]
public class RealFileWrapperTests
{
    private RealFileWrapper _realFileWrapper;
    private readonly string _testDocPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
        @"..\..\..\DayOneTests\testCalibrationDoc.txt");

    [SetUp]
    public void SetUp()
    {
        _realFileWrapper = new RealFileWrapper(_testDocPath);
    }

    [Test]
    public void ReadAllLinesReturnsFileLinesAsStringArray()
    {
        // Arrange
        var expected = new string[]
        {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet"
        };


        // Act
        var actual = _realFileWrapper.ReadAllLines();

        // Assert
        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void ReadAllTextReturnsFileContentsAsString()
    {
        // Arrange
        var expected = "1abc2\r\npqr3stu8vwx\r\na1b2c3d4e5f\r\ntreb7uchet";

        // Act
        var actual = _realFileWrapper.ReadAllText();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}
