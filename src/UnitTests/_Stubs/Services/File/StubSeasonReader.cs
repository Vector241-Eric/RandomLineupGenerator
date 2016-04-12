using RandomLineupGenerator.Model;
using RandomLineupGenerator.Services.FileServices;

namespace UnitTests._Stubs.Services.File
{
    public class StubSeasonReader : ISeasonReader
    {
        private Lineup[] _stubData;

        public Lineup[] ReadSeason()
        {
            return _stubData;
        }

        public StubSeasonReader WithData(Lineup[] lineups)
        {
            _stubData = lineups;
            return this;
        }
    }
}