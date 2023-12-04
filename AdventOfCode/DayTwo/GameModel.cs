namespace AdventOfCode.DayTwo;

public class GameModel
{
    public int Id { get; set; }
    public RoundModel GameConfig { get; set; }
    public List<RoundModel> Rounds { get; set; }

    public bool WasPossible() => Rounds.All(round => round.WasPossible(GameConfig));

    public RoundModel GetMinimumCubes()
    {
        var minimumRed = Rounds.Select(round => round.RedCubes).Max();
        var minimumGreen = Rounds.Select(round => round.GreenCubes).Max();
        var minimumBlue = Rounds.Select(round => round.BlueCubes).Max();

        return new RoundModel(minimumRed, minimumGreen, minimumBlue);
    }
}
