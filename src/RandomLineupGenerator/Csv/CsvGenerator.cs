using System.IO;
using CsvHelper;
using RandomLineupGenerator.Services.FileServices;

namespace RandomLineupGenerator.Csv
{
    public class CsvGenerator
    {
        private readonly ISeasonReader _seasonReader;

        public CsvGenerator() : this(new SeasonReader())
        {
        }

        public CsvGenerator(ISeasonReader seasonReader)
        {
            _seasonReader = seasonReader;
        }

        public void WriteCsv()
        {
            var season = _seasonReader.ReadSeason();
            var table = new SimpleTableOfColumns();
            foreach (var lineup in season)
            {
                var column = table.NewColumn();
                column.Add($"{lineup.Date.ToString("M")} - {lineup.Index}");
                foreach (var name in lineup.BattingOrder)
                    column.Add(name);
            }

            using (var textWriter = File.CreateText(Program.CsvFile))
            {
                var csv = new CsvWriter(textWriter);

                foreach (var row in table.Rows)
                {
                    foreach (var cell in row)
                    {
                        csv.WriteField(cell);
                    }
                    csv.NextRecord();
                }
            }
        }
    }
}