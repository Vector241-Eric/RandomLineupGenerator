using RandomLineupGenerator.Services;

namespace RandomLineupGenerator
{
    public class Program
    {
        public static readonly string TeamFile = @"c:\var\teeball\team.json";
        public static readonly string LineupsFile = @"c:\var\teeball\lineups.json";
        public static readonly string CsvFile = @"c:\var\teeball\lineups.csv";

        static void Main(string[] args)
        {
            new SeasonPopulator().Populate();
        }
    }
}