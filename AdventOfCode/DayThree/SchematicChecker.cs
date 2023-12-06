using AdventOfCode.DayOne;
using System.Text.RegularExpressions;

namespace AdventOfCode.DayThree;

public class SchematicChecker
{
    private readonly IFileWrapper _fileWrapper;
    private List<List<Cell>> _cellsGrid;

    public SchematicChecker(IFileWrapper fileWrapper)
    {
        _fileWrapper = fileWrapper;
    }

    public int Check()
    {
        InitializeCellGrid();
        var allDigitSets = BuildCandidates();
        var validDigitSets = new List<List<Cell>>();

        allDigitSets.ForEach(collection =>
        {
            if (collection.Any(cell => cell.GetNeighbours().Any(cell => new Regex(@"[^a-zA-Z0-9\.]+")
                .Match(cell.Value.ToString()).Success)))
            {
                validDigitSets.Add(collection);
            }
        });

        var stringsList = validDigitSets.Select(collection =>
            string.Join(string.Empty, collection.Select(cell => cell.Value))).ToList();

        var numbers = new List<int>();

        stringsList.ToList().ForEach(item =>
        {
            int.TryParse(item, out var result);
            numbers.Add(result);
        });

        return numbers.Sum();
    }

    private void InitializeCellGrid()
    {
        // Map a char grid to a cell grid
        var charGrid = GetCharGrid();
        var cellGrid = charGrid.Select(line =>
        {
            var cellLine = new List<Cell>();
            line.ForEach(cha => cellLine.Add(new Cell { Value = cha }));
            return cellLine;
        }).ToList();

        // Assign Grid prop of every cell to its own Grid
        cellGrid.ForEach(line =>
        {
            line.ForEach(cell => cell.Grid = cellGrid);
        });

        // Assign coordinates to each cell
        cellGrid.ForEach(line =>
        {
            line.ForEach(cell =>
            {
                cell.Line = cellGrid.IndexOf(line);
                cell.Char = line.IndexOf(cell);
            });
        });

        // Get list of neighbours of for each cell
        _cellsGrid = cellGrid;
    }

    private List<List<Cell>> BuildCandidates()
    {
        var result = new List<List<Cell>>();
        foreach (var line in _cellsGrid)
        {
            var keepAdding = false;
            var toAdd = new List<Cell>();
            foreach (var cell in line)
            {
                if (new Regex(@"\d").Match(cell.Value.ToString()).Success)
                {
                    toAdd.Add(cell);
                    if (cell.Char == line.Count - 1 // it is the last cell on the line
                        || !new Regex(@"\d").Match(line.ElementAt(cell.Char + 1).Value.ToString()).Success)
                    {
                        result.Add(toAdd);
                        toAdd = new List<Cell>();
                    }
                }
            }
        }
        return result;
    }

    private List<List<char>> GetCharGrid() =>
        _fileWrapper.ReadAllLines().Select(line => line.ToCharArray().ToList()).ToList();
}
