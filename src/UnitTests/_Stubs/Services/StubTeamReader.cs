using RandomLineupGenerator.Model;
using RandomLineupGenerator.Services;

namespace UnitTests._Stubs.Services
{
    public class StubTeamReader : ITeamReader
    {
        private Player[] _stubData;

        public Player[] GetTeam()
        {
            return _stubData;
        }

        public StubTeamReader WithStubData(Player[] stubData)
        {
            _stubData = stubData;
            return this;
        }
    }
}