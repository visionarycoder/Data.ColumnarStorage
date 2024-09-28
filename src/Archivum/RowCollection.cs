namespace Archivum;

public class RowCollection
{
    private readonly Table table;
    private readonly Record[] records;

    public RowCollection(Table table)
    {
        this.table = table;
        records = new Record[table.Columns.Count];
    }

    public Table Table => table;

    public object this[string columnName]
    {
        get
        {
            int columnIndex = table.Columns.IndexOf(table.Columns.First(c => c.Name == columnName));
            return records[columnIndex]?.Value;
        }
        set
        {
            int columnIndex = table.Columns.IndexOf(table.Columns.First(c => c.Name == columnName));
            records[columnIndex] = new Record(value);
            table.Records[table.Rows.IndexOf(this), columnIndex] = records[columnIndex];
        }
    }

    public object this[int columnIndex]
    {
        get => records[columnIndex]?.Value;
        set
        {
            records[columnIndex] = new Record(value);
            table.Records[table.Rows.IndexOf(this), columnIndex] = records[columnIndex];
        }
    }
}
