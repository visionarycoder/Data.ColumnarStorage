using System.Collections;

namespace Archivum.Tabular;

public class ColumnCollection(params Column[] columns) : IEnumerable<Column>
{

    private readonly List<Column> columns = columns.ToList() ?? [];

    public int Count => columns.Count;

    public Column this[int index] => columns[index];

    public Column this[string columnName] => columns.FirstOrDefault(c => c.ColumnName == columnName) ?? throw new KeyNotFoundException($"Column '{columnName}' not found.");

    public void Add(Column column)
    {
        if (columns.Any(c => c.ColumnName == column.ColumnName))
        {
            throw new InvalidOperationException($"Column '{column.ColumnName}' already exists.");
        }
        columns.Add(column);
    }

    public void AddRange(IEnumerable<Column> columnsToAdd)
    {
        foreach (var column in columnsToAdd)
        {
            Add(column);
        }
    }

    public bool Remove(string columnName)
    {
        var column = columns.FirstOrDefault(c => c.ColumnName == columnName);
        return column != null && columns.Remove(column);
    }

    public bool Contains(string columnName)
    {
        return columns.Any(c => c.ColumnName == columnName);
    }

    public void Clear()
    {
        columns.Clear();
    }

    public int IndexOf(Column column)
    {
        return columns.IndexOf(column);
    }

    public ColumnCollection Clone()
    {
        var columnCollection = new ColumnCollection();
        columnCollection.AddRange(columns.ToArray());
        return columnCollection;
    }

    public IEnumerator<Column> GetEnumerator()
    {
        return columns.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}
