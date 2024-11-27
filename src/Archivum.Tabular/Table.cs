using System.Collections.ObjectModel;

namespace Archivum.Tabular;

public class Table(string name, params Column[] columns)
{

    private readonly ColumnCollection columns = new ColumnCollection(columns);
    private readonly RowCollection rows = [];
    private readonly Dictionary<(int rowIndex, int columnIndex), Record> records = new();
    private int nextRowIndex = 0;

    public string Name { get; private set; } = name;

    public ColumnCollection Columns => columns;
    public RowCollection Rows => rows;

    internal ReadOnlyCollection<Record> Records => records.Values.ToList().AsReadOnly();

    public Table()
        : this(string.Empty)
    {
    }

    public void AddName(string name)
    {
        Name = name;
    }

    public void AddColumn(Column column)
    {
        columns.Add(column);
    }

    public Row NewRow()
    {
        return new Row(this, columns.Clone());
    }

    public void AddRow(Row row)
    {

        if (this != row.Table)
        {
            throw new InvalidOperationException("Row belongs to another table.");
        }

        // Set the RowIndex property using reflection
        var indexProperty = typeof(Row).GetProperty("RowIndex", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        if (indexProperty == null)
        {
            throw new InvalidOperationException("RowIndex property not found.");
        }
        indexProperty.SetValue(row, nextRowIndex++);
        rows.Add(row);

    }

    public int GetColumnIndex(string columnName)
    {
        return columns.ToList().FindIndex(c => c.ColumnName == columnName);
    }

    internal object Get(int rowIndex, int columnIndex)
    {
        return records[(rowIndex, columnIndex)].Value ?? throw new ArgumentOutOfRangeException();
    }

    internal void Set(int rowIndex, int columnIndex, object value)
    {
        if (records.ContainsKey((rowIndex, columnIndex)))
        {
            records[(rowIndex, columnIndex)].Value = value;
        }
        else
        {

        }

    }
}
