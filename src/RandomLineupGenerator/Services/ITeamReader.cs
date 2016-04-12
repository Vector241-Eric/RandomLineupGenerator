using RandomLineupGenerator.Model;

namespace RandomLineupGenerator.Services
{
    public interface ITeamReader
    {
        Player[] GetTeam();
    }
}