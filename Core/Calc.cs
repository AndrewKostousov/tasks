using System.Data;

namespace Core
{
    public static class Calc
    {
        public static decimal Evaluate(string expression)
        {
            var table = new DataTable();
            table.Columns.Add("expression", typeof(string), expression);
            var row = table.NewRow();
            table.Rows.Add(row);
            return decimal.Parse((string)row["expression"]);
        }
    }
}