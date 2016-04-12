using System.Collections.Generic;
using RandomLineupGenerator.Model;
using RandomLineupGenerator.Services;

namespace UnitTests._Stubs.Services
{
    public class StubLineupPopulater : ILineupPopulater
    {
        private readonly List<Lineup> _populatedLineups = new List<Lineup>();

        public Lineup[] PopulatedLineups => _populatedLineups.ToArray();

        public void Populate(Lineup lineup)
        {
            _populatedLineups.Add(lineup);
        }
    }
}