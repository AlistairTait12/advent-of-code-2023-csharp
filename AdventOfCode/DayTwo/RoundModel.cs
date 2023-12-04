namespace AdventOfCode.DayTwo;

public class RoundModel
{
    public RoundModel(int red, int green, int blue)
    {
        RedCubes = red;
        GreenCubes = green;
        BlueCubes = blue;
    }

    public int RedCubes { get; set; }
    public int GreenCubes { get; set; }
    public int BlueCubes { get; set; }

    public bool WasPossible(RoundModel gameConfiguration)
    {
        return gameConfiguration.RedCubes >= this.RedCubes
            && gameConfiguration.GreenCubes >= this.GreenCubes
            && gameConfiguration.BlueCubes >= this.BlueCubes;
    }
}
