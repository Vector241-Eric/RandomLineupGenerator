using System.Linq;
using NUnit.Framework;
using RandomLineupGenerator.Model;
using RandomLineupGenerator.Services;
using Should;
using UnitTests._Stubs.Services;

namespace UnitTests.Services
{
    public class LineupGeneratorTests
    {
        public class When_lineup_history_is_empty
        {
            private Player[] _result;

            [SetUp]
            public void Setup()
            {
                var team = new[] {new Player {Name = "one"}, new Player {Name = "two"}, new Player {Name = "three"},};
                var stubTeamProvider = new StubTeamProvider().WithStubData(team);

                var service = new LineupGenerator(new AlwaysSelectFirstMember(), stubTeamProvider);
                _result = service.GetLineup();
            }

            [Test]
            public void Should_generate_a_lineup_that_includes_all_team_members()
            {
                _result.Length.ShouldEqual(3);
                _result.Any(x => x.Name == "one").ShouldBeTrue();
                _result.Any(x => x.Name == "two").ShouldBeTrue();
                _result.Any(x => x.Name == "three").ShouldBeTrue();
            }
        }

        public class When_lineup_history_has_clear_first_with_least_occurances
        {
            private Player[] _result;

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
                var stubTeamProvider = new StubTeamProvider().WithStubData(team);

                var service = new LineupGenerator(new AlwaysSelectFirstMember(), stubTeamProvider);
                _result = service.GetLineup();
            }

            [Test]
            public void Should_generate_a_lineup_that_includes_all_team_members()
            {
                _result.Length.ShouldEqual(5);
                _result.Any(x => x.Name == "one").ShouldBeTrue();
                _result.Any(x => x.Name == "two").ShouldBeTrue();
                _result.Any(x => x.Name == "three").ShouldBeTrue();
                _result.Any(x => x.Name == "four").ShouldBeTrue();
                _result.Any(x => x.Name == "five").ShouldBeTrue();
            }

            [Test]
            public void Should_generate_a_lineup_with_least_first_at_the_beginning()
            {
                _result.First().Name.ShouldEqual("three");
            }
        }

        public class When_lineup_history_has_clear_first_and_last_with_least_occurances
        {
            private Player[] _result;

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
                var stubTeamProvider = new StubTeamProvider().WithStubData(team);

                var service = new LineupGenerator(new AlwaysSelectFirstMember(), stubTeamProvider);
                _result = service.GetLineup();
            }


            [Test]
            public void Should_generate_a_lineup_that_includes_all_team_members()
            {
                _result.Length.ShouldEqual(5);
                _result.Any(x => x.Name == "one").ShouldBeTrue();
                _result.Any(x => x.Name == "two").ShouldBeTrue();
                _result.Any(x => x.Name == "three").ShouldBeTrue();
                _result.Any(x => x.Name == "four").ShouldBeTrue();
                _result.Any(x => x.Name == "five").ShouldBeTrue();
            }

            [Test]
            public void Should_generate_a_lineup_with_least_first_at_the_beginning()
            {
                _result.Last().Name.ShouldEqual("four");
            }
        }
    }
}