namespace Archivum.Tabular;

public class Column(string columnName, Type dataType, IsReadOnlyValue isReadOnly, IsUniqueValue isUnique, AllowDbNullValue allowDbNull)
{

    public string ColumnName { get; set; } = columnName;
    public Type DataType { get; set; } = dataType;
    public bool ReadOnly { get; set; } = isReadOnly == IsReadOnlyValue.Yes;
    public bool Unique { get; set; } = isUnique == IsUniqueValue.Yes;
    public bool AllowDbNull { get; set; } = allowDbNull == AllowDbNullValue.Yes;
    public int MaxLength { get; set; } = -1; // -1 indicates no limit
    public string DefaultValue { get; set; } = string.Empty;

    public Column()
        : this(string.Empty)
    {

    }

    public Column(string columnName)
        : this(columnName, typeof(object))
    {
    }

    public Column(string columnName, Type dataType)
        : this(columnName, typeof(object), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes)
    {
        ColumnName = columnName;
        DataType = dataType;
    }

    public override string ToString()
    {
        return $"{ColumnName} ({DataType.Name})";
    }







}

public enum IsReadOnlyValue
{
    No,
    Yes
}

public enum IsUniqueValue
{
    No,
    Yes
}

public enum AllowDbNullValue
{
    No,
    Yes
}