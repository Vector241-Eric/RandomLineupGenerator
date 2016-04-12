using System.IO;
using Newtonsoft.Json;

namespace RandomLineupGenerator.Services.FileServices
{
    public class RosterReader : IRosterReader
    {
        public string[] ReadPlayers()
        {
            var json = File.ReadAllText(Program.TeamFile);
            var roster = JsonConvert.DeserializeObject<string[]>(json);
            return roster;
        }
    }
}