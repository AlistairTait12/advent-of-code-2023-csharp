namespace AdventOfCode.DayOne;

public class RealFileWrapper : IFileWrapper
{
    private readonly string _filePath;

    public RealFileWrapper(string filePath)
    {
        _filePath = filePath;
    }

    public string[] ReadAllLines() => File.ReadAllLines(_filePath);

    public string ReadAllText() => File.ReadAllText(_filePath);
}
