namespace Archival.Tabular;

public class Column
{
    public string ColumnName { get; set; } = string.Empty;
    public Type DataType { get; set; } = typeof(object);
    public bool ReadOnly { get; set; } = false;
    public bool Unique { get; set; } = false;
    public bool AllowDbNull { get; set; } = true;
    public int MaxLength { get; set; } = -1; // -1 indicates no limit
    public string DefaultValue { get; set; } = string.Empty;

    public Column() { }

    public Column(string columnName, Type dataType)
    {
        ColumnName = columnName;
        DataType = dataType;
    }

    public Column(string columnName, Type dataType, bool readOnly, bool unique, bool allowDbNull, int maxLength, string defaultValue)
    {
        ColumnName = columnName;
        DataType = dataType;
        ReadOnly = readOnly;
        Unique = unique;
        AllowDbNull = allowDbNull;
        MaxLength = maxLength;
        DefaultValue = defaultValue;
    }

    public override string ToString()
    {
        return $"{ColumnName} ({DataType.Name})";
    }
}
