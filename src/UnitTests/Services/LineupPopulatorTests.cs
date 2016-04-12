using System.Linq;
using NUnit.Framework;
using RandomLineupGenerator.Model;
using RandomLineupGenerator.Services;
using Should;
using UnitTests._Stubs.Services;

namespace UnitTests.Services
{
    public class LineupPopulatorTests
    {
        public class When_lineup_history_is_empty
        {
            private Lineup _lineup = new Lineup();

            [SetUp]
            public void Setup()
            {
                var team = new[] {new Player {Name = "one"}, new Player {Name = "two"}, new Player {Name = "three"},};
                var stubTeamProvider = new StubTeamReader().WithStubData(team);

                var service = new LineupPopulator(new AlwaysSelectFirstMember(), stubTeamProvider);
                service.Populate(_lineup);
            }

            [Test]
            public void Should_generate_a_batting_order_that_includes_all_team_members()
            {
                _lineup.BattingOrder.Count.ShouldEqual(3);
                _lineup.BattingOrder.Any(x => x == "one").ShouldBeTrue();
                _lineup.BattingOrder.Any(x => x == "two").ShouldBeTrue();
                _lineup.BattingOrder.Any(x => x == "three").ShouldBeTrue();
            }
        }

        public class When_lineup_history_has_clear_first_with_least_occurances
        {
            private Lineup _lineup = new Lineup();

            [SetUp]
            public void Setup()
            {
                var team = new[]
                {
                    new Player {Name = "one", FirstCount = 3},
                    new Player {Name = "two", FirstCount = 4},
                    new Player {Name = "three", FirstCount = 1},
                    new Player {Name = "four", FirstCount = 5},
                    new Player {Name = "five", FirstCount = 6},
                };
                var stubTeamProvider = new StubTeamReader().WithStubData(team);

                var service = new LineupPopulator(new AlwaysSelectFirstMember(), stubTeamProvider);
                service.Populate(_lineup);
            }

            [Test]
            public void Should_generate_a_lineup_that_includes_all_team_members()
            {
                _lineup.BattingOrder.Count.ShouldEqual(5);
                _lineup.BattingOrder.Any(x => x == "one").ShouldBeTrue();
                _lineup.BattingOrder.Any(x => x == "two").ShouldBeTrue();
                _lineup.BattingOrder.Any(x => x == "three").ShouldBeTrue();
                _lineup.BattingOrder.Any(x => x == "four").ShouldBeTrue();
                _lineup.BattingOrder.Any(x => x == "five").ShouldBeTrue();
            }

            [Test]
            public void Should_generate_a_lineup_with_least_first_at_the_beginning()
            {
                _lineup.BattingOrder.First().ShouldEqual("three");
            }
        }

        public class When_lineup_history_has_clear_first_and_last_with_least_occurances
        {
            private Lineup _lineup = new Lineup();

            [SetUp]
            public void Setup()
            {
                var team = new[]
                {
                    new Player {Name = "one", FirstCount = 3, LastCount = 2},
                    new Player {Name = "two", FirstCount = 4, LastCount = 3},
                    new Player {Name = "three", FirstCount = 1, LastCount = 4},
                    new Player {Name = "four", FirstCount = 5, LastCount = 1},
                    new Player {Name = "five", FirstCount = 6, LastCount = 5},
                };
                var stubTeamProvider = new StubTeamReader().WithStubData(team);

                var service = new LineupPopulator(new AlwaysSelectFirstMember(), stubTeamProvider);
                service.Populate(_lineup);
            }


            [Test]
            public void Should_generate_a_lineup_that_includes_all_team_members()
            {
                _lineup.BattingOrder.Count.ShouldEqual(5);
                _lineup.BattingOrder.Any(x => x == "one").ShouldBeTrue();
                _lineup.BattingOrder.Any(x => x == "two").ShouldBeTrue();
                _lineup.BattingOrder.Any(x => x == "three").ShouldBeTrue();
                _lineup.BattingOrder.Any(x => x == "four").ShouldBeTrue();
                _lineup.BattingOrder.Any(x => x == "five").ShouldBeTrue();
            }

            [Test]
            public void Should_generate_a_lineup_with_least_first_at_the_beginning()
            {
                _lineup.BattingOrder.Last().ShouldEqual("four");
            }
        }
    }
}