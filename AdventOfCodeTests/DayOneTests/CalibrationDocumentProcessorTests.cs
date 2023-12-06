using AdventOfCode.DayOne;

namespace AdventOfCodeTests.DayOneTests;

[TestFixture]
public class CalibrationDocumentProcessorTests
{
    private CalibrationDocumentProcessor _processor;
    private IFileWrapper _fileWrapper;

    [Test]
    public void GetValueFromDocumentReturnsSumOfCalibrationValuesInDocument()
    {
        // Arrange
        _fileWrapper = A.Fake<IFileWrapper>();
        A.CallTo(() => _fileWrapper.ReadAllLines()).Returns(new[]
        {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet"
        });
        _processor = new CalibrationDocumentProcessor(_fileWrapper);

        // Act
        var actual = _processor.GetValueFromDocument();

        // Assert
        Assert.That(actual, Is.EqualTo(142));
    }

    [Test]
    public void GetValueFromDocumentContainingWordsReturnsSumOfCalibrationValuesInDocument()
    {
        // Arrange
        _fileWrapper = A.Fake<IFileWrapper>();
        A.CallTo(() => _fileWrapper.ReadAllLines()).Returns(new[]
        {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen"
        });
        _processor = new CalibrationDocumentProcessor(_fileWrapper);

        // Act
        var actual = _processor.GetValueFromDocument();

        // Assert
        Assert.That(actual, Is.EqualTo(281));
    }
}
