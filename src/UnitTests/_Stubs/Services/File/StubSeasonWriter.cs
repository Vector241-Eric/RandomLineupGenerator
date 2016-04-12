using System.Collections.Generic;
using RandomLineupGenerator.Model;
using RandomLineupGenerator.Services.FileServices;

namespace UnitTests._Stubs.Services.File
{
    public class StubSeasonWriter : ISeasonWriter
    {
        public List<Lineup[]> Writes { get; private set; }

        public StubSeasonWriter()
        {
            Writes = new List<Lineup[]>();
        }

        public void SaveSeason(Lineup[] season)
        {
            Writes.Add(season);
        }
    }
}