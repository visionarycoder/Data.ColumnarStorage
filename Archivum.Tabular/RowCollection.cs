using System.Collections;

namespace Archivum.Tabular;

public class RowCollection : IEnumerable<Row>
{

    private readonly List<Row> rows = [];

    public int Count => rows.Count;

    public Row this[int index] => rows[index];

    public void Add(Row row)
    {
        if (rows.Any(r => r.instanceId == row.instanceId))
        {
            throw new InvalidOperationException("Row already exists.");
        }
        rows.Add(row);
    }

    public int IndexOf(Row row)
    {
        return rows.IndexOf(row);
    }

    public IEnumerator<Row> GetEnumerator()
    {
        return rows.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}
