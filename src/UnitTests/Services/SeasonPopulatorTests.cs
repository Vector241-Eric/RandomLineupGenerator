using System.Linq;
using NUnit.Framework;
using RandomLineupGenerator.Model;
using RandomLineupGenerator.Services;
using Should;
using UnitTests._Stubs.Services;
using UnitTests._Stubs.Services.File;

namespace UnitTests.Services
{
    public class SeasonPopulatorTests
    {
        [TestFixture]
        public class When_some_lineups_have_members_and_some_do_not
        {
            private Lineup[][] _savedSeasons;
            private StubLineupPopulater _lineupPopulater;

            [SetUp]
            public void ContextSetup()
            {
                var existingLineups = new[]
                {
                    new Lineup {Index = 1}.Add("Player 1").Add("Player 2"),
                    new Lineup {Index = 2}.Add("Player 1").Add("Player 2").Add("Player 3"),
                    new Lineup {Index = 3},
                    new Lineup {Index = 4},
                };

                var reader = new StubSeasonReader().WithData(existingLineups);
                var writer = new StubSeasonWriter();
                _lineupPopulater = new StubLineupPopulater();

                var seasonPopulator = new SeasonPopulator(reader, writer, _lineupPopulater);
                seasonPopulator.Populate();

                _savedSeasons = writer.Writes.ToArray();
            }

            [Test]
            public void Should_save_each_time_a_lineup_is_updated()
            {
                _savedSeasons.Length.ShouldEqual(2);
            }

            [Test]
            public void Should_populate_the_lineups_missing_an_order()
            {
                _lineupPopulater.PopulatedLineups.Length.ShouldEqual(2);
                _lineupPopulater.PopulatedLineups.Any(x => x.Index.Equals(3)).ShouldBeTrue();
                _lineupPopulater.PopulatedLineups.Any(x => x.Index.Equals(4)).ShouldBeTrue();
            }
        }
    }
}