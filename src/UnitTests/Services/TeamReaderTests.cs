using System.Linq;
using NUnit.Framework;
using RandomLineupGenerator.Model;
using RandomLineupGenerator.Services;
using Should;
using UnitTests._Stubs.Services.File;

namespace UnitTests.Services
{
    public class TeamReaderTests
    {
        [TestFixture]
        public class When_lineups_have_orders
        {
            private Player[] _result;

            [SetUp]
            public void ContextSetup()
            {
                var season = new[]
                {
                    new Lineup {}.Add("1").Add("2").Add("3").Add("4"),
                    new Lineup {}.Add("1").Add("2").Add("3").Add("4"),
                    new Lineup {}.Add("2").Add("1").Add("4").Add("3"),
                };

                var roster = new[] {"4", "3", "2", "1", "5"};

                var seasonReader = new StubSeasonReader().WithData(season);
                var rosterReader = new StubRosterReader().WithStubData(roster);

                var reader = new TeamReader(rosterReader, seasonReader);
                _result = reader.GetTeam();
            }

            [Test]
            public void Should_include_entire_roster()
            {
                _result.Length.ShouldEqual(5);
                _result.Any(x => x.Name.Equals("1")).ShouldBeTrue();
                _result.Any(x => x.Name.Equals("2")).ShouldBeTrue();
                _result.Any(x => x.Name.Equals("3")).ShouldBeTrue();
                _result.Any(x => x.Name.Equals("4")).ShouldBeTrue();
                _result.Any(x => x.Name.Equals("5")).ShouldBeTrue();
            }


            [Test]
            public void Should_count_number_of_times_each_player_is_first()
            {
                _result.Single(x => x.Name.Equals("1")).FirstCount.ShouldEqual(2);
                _result.Single(x => x.Name.Equals("2")).FirstCount.ShouldEqual(1);
                _result.Single(x => x.Name.Equals("3")).FirstCount.ShouldEqual(0);
                _result.Single(x => x.Name.Equals("4")).FirstCount.ShouldEqual(0);
                _result.Single(x => x.Name.Equals("5")).FirstCount.ShouldEqual(0);
            }

            [Test]
            public void Should_count_number_of_times_each_player_is_last()
            {
                _result.Single(x => x.Name.Equals("1")).LastCount.ShouldEqual(0);
                _result.Single(x => x.Name.Equals("2")).LastCount.ShouldEqual(0);
                _result.Single(x => x.Name.Equals("3")).LastCount.ShouldEqual(1);
                _result.Single(x => x.Name.Equals("4")).LastCount.ShouldEqual(2);
                _result.Single(x => x.Name.Equals("5")).LastCount.ShouldEqual(0);
            }
        }
    }
}