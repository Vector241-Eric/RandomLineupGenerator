using System.Linq;
using RandomLineupGenerator.Model;
using RandomLineupGenerator.Services.FileServices;

namespace RandomLineupGenerator.Services
{
    public class TeamReader : ITeamReader
    {
        private readonly IRosterReader _rosterReader;
        private readonly ISeasonReader _seasonReader;

        public TeamReader() : this(new RosterReader(), new SeasonReader())
        {
        }

        public TeamReader(IRosterReader rosterReader, ISeasonReader seasonReader)
        {
            _rosterReader = rosterReader;
            _seasonReader = seasonReader;
        }

        public Player[] GetTeam()
        {
            var roster = _rosterReader.ReadPlayers();
            var season = _seasonReader.ReadSeason();

            var players = roster.Select(name => new Player {Name = name}).ToArray();
            foreach (var lineup in season)
            {
                if (lineup.HasBattingOrder)
                {
                    var first = players.SingleOrDefault(x => x.Name.Equals(lineup.BattingOrder.First()));
                    var last = players.SingleOrDefault(x => x.Name.Equals(lineup.BattingOrder.Last()));
                    if (first != null)
                        first.FirstCount ++;
                    if (last != null)
                        last.LastCount ++;
                }
            }

            return players;
        }
    }
}