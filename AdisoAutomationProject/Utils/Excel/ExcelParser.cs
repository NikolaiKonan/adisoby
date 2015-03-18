using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils.Excel
{
    public class ExcelParser
    {
        private int _rowsCount;
        private int _collumtsCount;
        private XLWorkbook _workbook;


        public ExcelParser(string path)
        {
            _workbook = new XLWorkbook(path);
            _rowsCount = _workbook.Worksheets.First().RowsUsed().Count();
            _collumtsCount = _workbook.Worksheets.First().RowsUsed().First().CellsUsed().Count();
        }

        public IEnumerable<IEnumerable<string>> Values
        {
            get
            {
                var values = new List<List<string>>();
                for (int i = 1; i < _rowsCount; i++)
                {
                    var rows = _workbook.Worksheets.First().RowsUsed().ToList()[i];
                    var cells = new List<string>();
                    for (int j = 0; j < _collumtsCount; j++)
                    {
                        cells.Add(rows.Cell(j+1).Value.ToString());
                    }
                    values.Add(cells);
                }
                values.Reverse();
                return values;
            }
        }

    }
}
