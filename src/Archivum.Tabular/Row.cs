namespace Archivum.Tabular;

public class Row(Table table, ColumnCollection columns)
{

    protected internal Table Table = table;

    public Guid InstanceId { get; } = Guid.NewGuid();

    public ColumnCollection Columns { get; } = columns;

    public int RowIndex => Table.Rows.IndexOf(this);

    public object this[int columnIndex]
    {
        get => Table.Get(RowIndex, columnIndex);
        set => Table.Set(RowIndex, columnIndex, value);
    }

    public object this[string columnName]
    {
        get => Table.Get(RowIndex, Table.GetColumnIndex(columnName));
        set => Table.Set(RowIndex, Table.GetColumnIndex(columnName), value);
    }

}