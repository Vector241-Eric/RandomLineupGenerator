using RandomLineupGenerator.Model;

namespace RandomLineupGenerator.Services.FileServices
{
    public interface ISeasonWriter
    {
        void SaveSeason(Lineup[] season);
    }
}