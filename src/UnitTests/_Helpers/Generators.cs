using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;
using RandomLineupGenerator;
using RandomLineupGenerator.Csv;
using RandomLineupGenerator.Model;
using RandomLineupGenerator.Services;

namespace UnitTests._Helpers
{
    [TestFixture]
    public class Generators
    {
        [Test]
        public void PopulateLineups()
        {
            new SeasonPopulator().Populate();
            new CsvGenerator().WriteCsv();
        }

        [Test, Explicit]
        public void GenerateTeam()
        {
            var team = new List<string>
            {
                "Aiden",
                "Alex",
                "Cade",
                "Collin",
                "Corbet",
                "Ellis",
                "Finn",
                "Jachin",
                "Max",
                "Scout",
                "Wyatt"
            };

            var json = JsonConvert.SerializeObject(team, Formatting.Indented);

            File.WriteAllText(Program.TeamFile, json);
        }

        [Test, Explicit]
        public void GenerateLineup()
        {
            var lineups = new[]
            {
                new Lineup {Date = new DateTime(2016, 04, 02), Index = 1}
                    .Add("Finn")
                    .Add("Max")
                    .Add("Corbet")
                    .Add("Wyatt")
                    .Add("Ellis")
                    .Add("Cade")
                    .Add("Aiden")
                    .Add("Scout")
                    .Add("Collin")
                    .Add("Jachin"),
                new Lineup {Date = new DateTime(2016, 04, 02), Index = 2}
                    .Add("Cade")
                    .Add("Aiden")
                    .Add("Scout")
                    .Add("Collin")
                    .Add("Jachin")
                    .Add("Finn")
                    .Add("Max")
                    .Add("Corbet")
                    .Add("Wyatt")
                    .Add("Ellis"),
                new Lineup {Date = new DateTime(2016, 04, 02), Index = 3}
                    .Add("Scout")
                    .Add("Collin")
                    .Add("Jachin")
                    .Add("Finn")
                    .Add("Max")
                    .Add("Corbet")
                    .Add("Wyatt")
                    .Add("Ellis")
                    .Add("Cade")
                    .Add("Aiden"),
                new Lineup {Date = new DateTime(2016, 04, 09), Index = 1},
                new Lineup {Date = new DateTime(2016, 04, 09), Index = 2},
                new Lineup {Date = new DateTime(2016, 04, 09), Index = 3},
                new Lineup {Date = new DateTime(2016, 04, 16), Index = 1},
                new Lineup {Date = new DateTime(2016, 04, 16), Index = 2},
                new Lineup {Date = new DateTime(2016, 04, 16), Index = 3},
                new Lineup {Date = new DateTime(2016, 04, 23), Index = 1},
                new Lineup {Date = new DateTime(2016, 04, 23), Index = 2},
                new Lineup {Date = new DateTime(2016, 04, 23), Index = 3},
                new Lineup {Date = new DateTime(2016, 04, 30), Index = 1},
                new Lineup {Date = new DateTime(2016, 04, 30), Index = 2},
                new Lineup {Date = new DateTime(2016, 04, 30), Index = 3},
                new Lineup {Date = new DateTime(2016, 05, 07), Index = 1},
                new Lineup {Date = new DateTime(2016, 05, 07), Index = 2},
                new Lineup {Date = new DateTime(2016, 05, 07), Index = 3},
                new Lineup {Date = new DateTime(2016, 05, 14), Index = 1},
                new Lineup {Date = new DateTime(2016, 05, 14), Index = 2},
                new Lineup {Date = new DateTime(2016, 05, 14), Index = 3},
                new Lineup {Date = new DateTime(2016, 05, 21), Index = 1},
                new Lineup {Date = new DateTime(2016, 05, 21), Index = 2},
                new Lineup {Date = new DateTime(2016, 05, 21), Index = 3},
            };

            var json = JsonConvert.SerializeObject(lineups, Formatting.Indented);
            File.WriteAllText(Program.LineupsFile, json);
        }
    }
}