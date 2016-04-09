using System.Collections.Generic;
using RandomLineupGenerator.Model;

namespace RandomLineupGenerator.Services
{
    public interface ITeamProvider
    {
        IEnumerable<Player> GetTeam();
    }
}