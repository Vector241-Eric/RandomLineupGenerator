using RandomLineupGenerator.Services.FileServices;

namespace RandomLineupGenerator.Services
{
    public class SeasonPopulator
    {
        private readonly ISeasonReader _reader;
        private readonly ISeasonWriter _writer;
        private readonly ILineupPopulater _lineupPopulater;

        public SeasonPopulator() : this(new SeasonReader(), new SeasonWriter(), new LineupPopulator())
        {
        }

        public SeasonPopulator(ISeasonReader reader, ISeasonWriter writer, ILineupPopulater lineupPopulater)
        {
            _reader = reader;
            _writer = writer;
            _lineupPopulater = lineupPopulater;
        }

        public void Populate()
        {
            var season = _reader.ReadSeason();
            foreach (var lineup in season)
            {
                if (!lineup.HasBattingOrder)
                {
                    _lineupPopulater.Populate(lineup);
                    _writer.SaveSeason(season);
                }
            }
        }
    }
}