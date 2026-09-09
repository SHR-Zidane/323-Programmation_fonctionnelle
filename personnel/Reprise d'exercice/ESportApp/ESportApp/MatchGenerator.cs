using DataSeries;

namespace ESportApp;

public static class MatchGenerator
{
    public static DataSerie<DataPoint<Cs2Match>> GenerateCs2Match(string name, int number)
    {
        Random random = new Random(18);
        string[] map = new[] { "Dust", "Mirage", "Inferno", "Nuke" };
        string[] StartSide = new[] { "T", "CT" };
        
        List<DataPoint<Cs2Match>> match = 
            Enumerable.
                Range(1, number).
                Select(i => new DataPoint<Cs2Match>(
                    DateTime.Now.AddDays(-random.Next(0, 365)),
                        new Cs2Match(
                            name,
                            map[random.Next(0, map.Length)],
                            StartSide[random.Next(0, StartSide.Length)],
                            random.Next(0, 10),
                            random.Next(0, 10),
                            random.Next(0, 10),
                            random.Next(0, 5),
                            random.Next(0, 2) == 1)
                    )).ToList();
        return DataSerie<DataPoint<Cs2Match>>.From(match);
    }
}