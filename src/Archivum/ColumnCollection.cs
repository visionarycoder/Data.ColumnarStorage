namespace Archivum;

public class ColumnCollection : IReadOnlyList<Column>
{
    private readonly List<Column> columns = new();

    public Column this[int index] => columns[index];

    public Column this[string columnName] => columns.First(c => c.Name == columnName);

    public int Count => columns.Count;

    public IEnumerator<Column> GetEnumerator() => columns.GetEnumerator();

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

    internal void AddColumn(string name, Type type)
    {
        columns.Add(new Column(name, type, columns.Count));
    }

    internal void AddColumn(string name)
    {
        columns.Add(new Column(name, typeof(object), columns.Count));
    }

    internal void AddColumn()
    {
        columns.Add(new Column("Column" + columns.Count, typeof(object), columns.Count));
    }
}
