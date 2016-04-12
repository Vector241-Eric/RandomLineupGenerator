using System.IO;
using Newtonsoft.Json;
using RandomLineupGenerator.Model;

namespace RandomLineupGenerator.Services.FileServices
{
    public class SeasonWriter : ISeasonWriter
    {
        public void SaveSeason(Lineup[] season)
        {
            var json = JsonConvert.SerializeObject(season, Formatting.Indented);
            File.WriteAllText(Program.LineupsFile, json);
        }
    }
}