using System.Collections.Generic;
using System.Linq;
using RandomLineupGenerator.Model;

namespace RandomLineupGenerator.Services
{
    public class LineupGenerator
    {
        private readonly IRandomMemberSelector _randomMemberSelector;
        private readonly ITeamProvider _teamProvider;

        public LineupGenerator(IRandomMemberSelector randomMemberSelector, ITeamProvider teamProvider)
        {
            _randomMemberSelector = randomMemberSelector;
            _teamProvider = teamProvider;
        }

        public Player[] GetLineup()
        {
            var team = _teamProvider.GetTeam().ToList();
            var lineup = new List<Player>();

            //Get the first
            var lowestFirst = team.Select(x => x.FirstCount).Min();
            var firsts = team.Where(x => x.FirstCount == lowestFirst).ToList();
            var first = _randomMemberSelector.GetFrom(firsts);
            lineup.Add(first);
            team.Remove(first);
            
            //Get the last
            var lowestLast = team.Select(x => x.LastCount).Min();
            var lasts = team.Where(x => x.LastCount == lowestLast).ToList();
            var last = _randomMemberSelector.GetFrom(lasts);
            team.Remove(last);
            
            while (team.Any())
            {
                lineup.Add(_randomMemberSelector.GetFrom(team));
            }
            lineup.Add(last);

            return lineup.ToArray();
        }
    }
}