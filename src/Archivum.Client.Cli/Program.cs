using Archivum.Tabular;

var table = new Table();

var column = new Column("ID", typeof(int), IsReadOnlyValue.Yes, IsUniqueValue.Yes, AllowDbNullValue.No);
table.AddColumn(column);

column = new Column("Name", typeof(string));
table.AddColumn(column);

column = new Column("DateOfBirth", typeof(DateTime));
table.AddColumn(column);

column = new Column("FavoriteColor", typeof(ConsoleColor));
table.AddColumn(column);

AddRow(table, 1, "John Doe", new DateTime(1980, 1, 1), ConsoleColor.Blue);
AddRow(table, 2, "Jane Doe", new DateTime(1985, 1, 1), ConsoleColor.Green);

foreach (var row in table.Rows)
{
    foreach (var col in table.Columns)
    {
        Console.WriteLine($"{col.ColumnName}: {row[col.ColumnName]}");
    }
}

Console.ReadKey();

return;

static void AddRow(Table table, int id, string name, DateTime dateOfBirth, ConsoleColor color)
{
    var row = table.NewRow();
    row["ID"] = id;
    row["Name"] = name;
    row["DateOfBirth"] = dateOfBirth;
    row["FavoriteColor"] = color;
    table.AddRow(row);
}
