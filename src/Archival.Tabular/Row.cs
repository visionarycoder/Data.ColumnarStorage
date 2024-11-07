namespace Archival.Tabular;

public class Row(Table table, ColumnCollection columns)
{

    protected internal Table table = table;
    protected internal Guid instanceId = Guid.NewGuid();
    
    public ColumnCollection Columns { get; } = columns;

    public int RowIndex => table.Rows.IndexOf(this);

    public object this[int columnIndex]
    {
        get => table.Get(RowIndex, columnIndex);
        set => table.Set(RowIndex, columnIndex, value);
    }

    public object this[string columnName]
    {
        get => table.Get(RowIndex, table.GetColumnIndex(columnName));
        set => table.Set(RowIndex, table.GetColumnIndex(columnName), value);
    }

}