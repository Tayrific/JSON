using Newtonsoft.Json;
using System.Data;

namespace SerialiseDataset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataSet dataSet = new DataSet("dataSet");
            dataSet.Namespace = "NetFrameWork";

            DataTable table = new DataTable();

            DataColumn idColumn = new DataColumn("id", typeof(int));
            idColumn.AutoIncrement = true;

            DataColumn itemColumn = new DataColumn("item");
            table.Columns.Add(idColumn);
            table.Columns.Add(itemColumn);
            dataSet.Tables.Add(table);

            for (int i = 0; i < 2; i++)
            {
                DataRow newRow = table.NewRow();
                newRow["item"] = "item " + i;
                table.Rows.Add(newRow);
            }

            dataSet.AcceptChanges();

            Console.WriteLine("Serlialise DataSet");

            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            Console.WriteLine(json);

            Console.WriteLine("-------------------");
            Console.WriteLine("Deserlialise DataSet");

            dataSet = JsonConvert.DeserializeObject<DataSet>(json);

            DataTable dataTable = dataSet.Tables["Table1"];

            Console.WriteLine(dataTable.Rows.Count);
            // 2

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["id"] + " - " + row["item"]);
            }
        }
    }
}
