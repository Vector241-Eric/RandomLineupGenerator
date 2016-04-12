using RandomLineupGenerator.Model;

namespace RandomLineupGenerator.Services.FileServices
{
    public interface ISeasonReader
    {
        Lineup[] ReadSeason();
    }
}