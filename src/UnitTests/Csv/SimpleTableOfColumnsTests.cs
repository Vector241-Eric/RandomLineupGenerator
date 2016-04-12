using System.Collections.Generic;
using NUnit.Framework;
using RandomLineupGenerator.Csv;
using Should;

namespace UnitTests.Csv
{
    public class SimpleTableOfColumnsTests
    {
        [TestFixture]
        public class When_adding_cells_to_columns
        {
            private List<List<string>> _rows;

            [SetUp]
            public void ContextSetup()
            {
                var table = new SimpleTableOfColumns();
                table.NewColumn().Add("Header 1").Add("c1 r1").Add("c1 r2").Add("c1 r3");
                table.NewColumn().Add("Header 2").Add("c2 r1").Add("c2 r2").Add("c2 r3");
                table.NewColumn().Add("Header 3").Add("c3 r1").Add("c3 r2").Add("c3 r3");
                table.NewColumn().Add("Header 4").Add("c4 r1").Add("c4 r2").Add("c4 r3");
                table.NewColumn().Add("Header 5").Add("c5 r1").Add("c5 r2").Add("c5 r3");

                _rows = table.Rows;
            }


            [Test]
            public void Should_provide_back_content_as_rows()
            {
                _rows.Count.ShouldEqual(4);

                _rows[0][0].ShouldEqual("Header 1");
                _rows[0][1].ShouldEqual("Header 2");
                _rows[0][2].ShouldEqual("Header 3");
                _rows[0][3].ShouldEqual("Header 4");
                _rows[0][4].ShouldEqual("Header 5");

                _rows[1][0].ShouldEqual("c1 r1");
                _rows[1][1].ShouldEqual("c2 r1");
                _rows[1][2].ShouldEqual("c3 r1");
                _rows[1][3].ShouldEqual("c4 r1");
                _rows[1][4].ShouldEqual("c5 r1");

                _rows[2][0].ShouldEqual("c1 r2");
                _rows[2][1].ShouldEqual("c2 r2");
                _rows[2][2].ShouldEqual("c3 r2");
                _rows[2][3].ShouldEqual("c4 r2");
                _rows[2][4].ShouldEqual("c5 r2");

                _rows[3][0].ShouldEqual("c1 r3");
                _rows[3][1].ShouldEqual("c2 r3");
                _rows[3][2].ShouldEqual("c3 r3");
                _rows[3][3].ShouldEqual("c4 r3");
                _rows[3][4].ShouldEqual("c5 r3");
            }
        }

        [TestFixture]
        public class When_columns_are_uneven
        {
            private List<List<string>> _rows;

            [SetUp]
            public void ContextSetup()
            {
                var table = new SimpleTableOfColumns();
                table.NewColumn().Add("Header 1").Add("c1 r1").Add("c1 r2");
                table.NewColumn().Add("Header 2").Add("c2 r1").Add("c2 r2").Add("c2 r3");

                _rows = table.Rows;
            }


            [Test]
            public void Should_provide_back_content_as_rows_with_empty_values_where_cell_isnt_populated()
            {
                _rows[0][0].ShouldEqual("Header 1");
                _rows[0][1].ShouldEqual("Header 2");

                _rows[1][0].ShouldEqual("c1 r1");
                _rows[1][1].ShouldEqual("c2 r1");

                _rows[2][0].ShouldEqual("c1 r2");
                _rows[2][1].ShouldEqual("c2 r2");

                _rows[3][0].ShouldEqual(string.Empty);
                _rows[3][1].ShouldEqual("c2 r3");
            }
        }
    }
}