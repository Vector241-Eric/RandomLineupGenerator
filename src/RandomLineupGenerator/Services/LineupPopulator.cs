using System.Linq;
using RandomLineupGenerator.Model;

namespace RandomLineupGenerator.Services
{
    public class LineupPopulator : ILineupPopulater
    {
        private readonly IRandomMemberSelector _randomMemberSelector;
        private readonly ITeamReader _teamReader;

        public LineupPopulator() : this(new RandomMemberSelector(), new TeamReader())
        {
        }

        public LineupPopulator(IRandomMemberSelector randomMemberSelector, ITeamReader teamReader)
        {
            _randomMemberSelector = randomMemberSelector;
            _teamReader = teamReader;
        }

        public void Populate(Lineup lineup)
        {
            var team = _teamReader.GetTeam().ToList();

            //Get the first
            var lowestFirst = team.Select(x => x.FirstCount).Min();
            var firsts = team.Where(x => x.FirstCount == lowestFirst).ToList();
            var first = _randomMemberSelector.GetFrom(firsts);
            lineup.Add(first.Name);
            team.Remove(first);

            //Get the last
            var lowestLast = team.Select(x => x.LastCount).Min();
            var lasts = team.Where(x => x.LastCount == lowestLast).ToList();
            var last = _randomMemberSelector.GetFrom(lasts);
            team.Remove(last);

            while (team.Any())
            {
                lineup.Add(_randomMemberSelector.GetFrom(team).Name);
            }
            lineup.Add(last.Name);
        }
    }
}