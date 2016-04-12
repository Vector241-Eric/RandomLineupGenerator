using RandomLineupGenerator.Services.FileServices;

namespace UnitTests._Stubs.Services.File
{
    public class StubRosterReader : IRosterReader
    {
        private string[] _stubData;

        public string[] ReadPlayers()
        {
            return _stubData;
        }

        public StubRosterReader WithStubData(string[] stubData)
        {
            _stubData = stubData;
            return this;
        }
    }
}