namespace AdventOfCode.DayOne;

public class CalibrationDocumentProcessor
{
    private readonly List<string> _documentLines;

    public CalibrationDocumentProcessor(string pathToDocument)
    {
        _documentLines = File.ReadAllLines(pathToDocument)
            .ToList();
    }

    public int GetValueFromDocument()
    {
        throw new NotImplementedException();
    }
}
