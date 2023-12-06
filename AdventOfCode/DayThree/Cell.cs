namespace AdventOfCode.DayThree;

public class Cell
{
    public char Value { get; set; }
    public int Line { get; set; }
    public int Char { get; set; }
    public List<List<Cell>> Grid { get; set; }
    public List<Cell> Neighbours { get; set; }
    public bool IsPartDigit =>
        Neighbours.Any(cell => cell.Value == '*'); // any symbol

    public List<Cell> GetNeighbours()
    {
        if (Grid is null)
        {
            throw new InvalidOperationException("Grid not yet assigned to");
        }

        var neighbours = new List<Cell>();
        var maxCellIndex = Grid.First().Count - 1;
        var maxLineIndex = Grid.Count - 1;

        if (Line > 0) // You can add the cell above
        {
            neighbours.Add(Grid[Line - 1][Char]);
            if (Char > 0) // add top left
            {
                neighbours.Add(Grid[Line - 1][Char - 1]);
            }

            if (Char < maxCellIndex) // add top right
            {
                neighbours.Add(Grid[Line - 1][Char + 1]);
            }
        }

        if (Line < maxLineIndex) // You can add the cell below
        {
            neighbours.Add(Grid[Line + 1][Char]);
            if (Char > 0)
            {
                neighbours.Add(Grid[Line + 1][Char - 1]);
            }

            if (Char < maxCellIndex)
            {
                neighbours.Add(Grid[Line + 1][Char + 1]);
            }
        }

        if (Char > 0) // You can add the one to the left
        {
            neighbours.Add(Grid[Line][Char - 1]);
        }

        if (Char < maxCellIndex) // You can add the one to the right
        {
            neighbours.Add(Grid[Line][Char + 1]);
        }

        return neighbours;
    }
}
