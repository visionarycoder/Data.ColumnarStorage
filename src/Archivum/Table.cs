namespace Archivum;

public class Table
{
    private readonly List<RowCollection> rows = new();
    private readonly List<Record> records = new();

    public ColumnCollection Columns { get; } = new ColumnCollection();
    public IReadOnlyList<RowCollection> Rows => rows.AsReadOnly();
    public Record[,] Records { get; private set; }

    public Table()
    {
        Records = new Record[0, 0];
    }

    public RowCollection NewRow()
    {
        return new RowCollection(this);
    }

    public void AddRow(RowCollection row)
    {
        if (row.Table != this)
        {
            throw new InvalidOperationException("Row does not belong to this table.");
        }
        rows.Add(row);
        ResizeRecordsArray();
    }

    public void AddColumn()
    {
        Columns.AddColumn();
        ResizeRecordsArray();
    }

    public void AddColumn(string name)
    {
        Columns.AddColumn(name);
        ResizeRecordsArray();
    }

    public void AddColumn(string name, Type type)
    {
        Columns.AddColumn(name, type);
        ResizeRecordsArray();
    }

    private void ResizeRecordsArray()
    {
        var newRecords = new Record[rows.Count, Columns.Count];
        for (int i = 0; i < rows.Count; i++)
        {
            for (int j = 0; j < Columns.Count; j++)
            {
                if (i < Records.GetLength(0) && j < Records.GetLength(1))
                {
                    newRecords[i, j] = Records[i, j];
                }
            }
        }
        Records = newRecords;
    }
}
