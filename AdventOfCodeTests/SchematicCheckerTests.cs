using AdventOfCode.DayOne;
using AdventOfCode.DayThree;
using System.Diagnostics.CodeAnalysis;

namespace AdventOfCodeTests;

[ExcludeFromCodeCoverage]
[TestFixture]
public class SchematicCheckerTests
{
    private SchematicChecker _checker;
    private IFileWrapper _fileWrapper;

    [SetUp]
    public void SetUp()
    {
        _fileWrapper = A.Fake<IFileWrapper>();
        A.CallTo(() => _fileWrapper.ReadAllLines()).Returns(GetFileContents());
        _checker = new SchematicChecker(_fileWrapper);
    }

    [Test]
    public void GetSumOfPartNumbersGetsTheCorrectSumForTheSchematic()
    {
        // Act
        var actual = _checker.GetSumOfPartNumbers();

        // Assert
        actual.Should().Be(4361);
    }

    private string[] GetFileContents() => new string[]
    {
        "467..114..",
        "...*......",
        "..35..633.",
        "......#...",
        "617*......",
        ".....+.58.",
        "..592.....",
        "......755.",
        "...$.*....",
        ".664.598.."
    };
}
