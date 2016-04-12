using RandomLineupGenerator.Model;

namespace RandomLineupGenerator.Services
{
    public interface ILineupPopulater
    {
        void Populate(Lineup lineup);
    }
}