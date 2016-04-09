using System;
using System.Collections.Generic;
using RandomLineupGenerator.Model;
using RandomLineupGenerator.Services;

namespace UnitTests._Stubs.Services
{
    public class StubTeamProvider : ITeamProvider
    {
        private IEnumerable<Player> _stubData;

        public IEnumerable<Player> GetTeam()
        {
            return _stubData;
        }

        public StubTeamProvider WithStubData(IEnumerable<Player> stubData)
        {
            _stubData = stubData;
            return this;
        }
    }
}