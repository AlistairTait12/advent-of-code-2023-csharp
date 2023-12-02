using AdventOfCode.DayOne;

namespace AdventOfCodeTests.DayOneTests;

[TestFixture]
public class CalibrationDocumentProcessorTests
{
    private CalibrationDocumentProcessor _processor;
    private readonly string _testDocPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
        @"..\..\..\DayOneTests\testCalibrationDoc.txt");

    [SetUp]
    public void SetUp()
    {
        _processor = new CalibrationDocumentProcessor(_testDocPath);
    }

    [Test]
    public void GetValueFromDocumentReturnsSumOfCalibrationValuesInDocument()
    {
        // Act
        var actual = _processor.GetValueFromDocument();

        // Assert
        Assert.That(actual, Is.EqualTo(142));
    }
}
