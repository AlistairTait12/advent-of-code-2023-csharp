namespace AdventOfCode.DayTwo;

public class GameModel
{
    public int Id { get; set; }
    public RoundModel GameConfig { get; set; }
    public List<RoundModel> Rounds { get; set; }

    public bool WasPossible() => Rounds.All(round => round.WasPossible(GameConfig));
}
