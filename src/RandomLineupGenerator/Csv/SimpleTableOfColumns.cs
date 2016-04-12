using System.Collections.Generic;
using System.Linq;

namespace RandomLineupGenerator.Csv
{
    public class SimpleTableOfColumns
    {
        private readonly List<SimpleColumn> _columns = new List<SimpleColumn>();

        public SimpleColumn NewColumn()
        {
            var column = new SimpleColumn();
            _columns.Add(column);
            return column;
        }

        public List<List<string>> Rows => BuildRows();

        private List<List<string>> BuildRows()
        {
            var rowCount = _columns.Select(x => x.Cells.Length).Max();

            var rows = new List<List<string>>();
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                var row = new List<string>();
                rows.Add(row);
                foreach (var column in _columns)
                {
                    var columnCells = column.Cells;
                    if (rowIndex < columnCells.Length)
                        row.Add(columnCells[rowIndex]);
                    else
                        row.Add(string.Empty);
                }
            }

            return rows;
        }
    }

    public class SimpleColumn
    {
        private readonly List<string> _cells = new List<string>();

        /// <summary>
        /// Adds a cell to the bottom of the current column
        /// </summary>
        /// <param name="cell"></param>
        public SimpleColumn Add(string cell)
        {
            _cells.Add(cell);
            return this;
        }

        public string[] Cells => _cells.ToArray();
    }
}