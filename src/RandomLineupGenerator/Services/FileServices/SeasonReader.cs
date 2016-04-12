using System.IO;
using Newtonsoft.Json;
using RandomLineupGenerator.Model;

namespace RandomLineupGenerator.Services.FileServices
{
    public class SeasonReader : ISeasonReader
    {
        public Lineup[] ReadSeason()
        {
            var json = File.ReadAllText(Program.LineupsFile);
            var lineups = JsonConvert.DeserializeObject<Lineup[]>(json);
            return lineups;
        }
    }
}