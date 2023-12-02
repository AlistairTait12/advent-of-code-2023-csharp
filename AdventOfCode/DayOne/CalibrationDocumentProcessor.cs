namespace AdventOfCode.DayOne;

public class CalibrationDocumentProcessor
{
    private readonly List<string> _documentLines;

    public CalibrationDocumentProcessor(IFileWrapper fileWrapper)
    {
        _documentLines = fileWrapper.ReadAllLines()
            .ToList();
    }

    public int GetValueFromDocument() => _documentLines.Aggregate(0, (total, line) =>
        total += CalibrationLineProcessor.GetValueFromLine(line));
}
