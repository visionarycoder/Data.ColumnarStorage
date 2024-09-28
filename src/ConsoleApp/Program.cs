using Archivum;

namespace ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        // Create a new table
        Table table = new Table();

        // Add columns to the table
        table.AddColumn("ID", typeof(int));
        table.AddColumn("Name", typeof(string));
        table.AddColumn("Age", typeof(int));

        // Create a new row
        RowCollection row1 = table.NewRow();
        row1["ID"] = 1; // ID
        row1["Name"] = "Alice"; // Name
        row1["Age"] = 30; // Age

        // Add the row to the table
        table.AddRow(row1);

        // Create another row
        RowCollection row2 = table.NewRow();
        row2["ID"] = 2; // ID
        row2["Name"] = "Bob"; // Name
        row2["Age"] = 25; // Age

        // Add the row to the table
        table.AddRow(row2);

        // Display the table data
        DisplayTable(table);
    }

    static void DisplayTable(Table table)
    {
        // Display column headers
        foreach (var column in table.Columns)
        {
            Console.Write(column.Name + "\t");
        }
        Console.WriteLine();

        // Display rows
        foreach (var row in table.Rows)
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                Console.Write(row[i] + "\t");
            }
            Console.WriteLine();
        }
    }
}
