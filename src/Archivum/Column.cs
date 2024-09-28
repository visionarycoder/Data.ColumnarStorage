namespace Archivum;

public class Column
{
    public string Name { get; set; }
    public Type DataType { get; set; }
    public int Index { get; set; }

    public Column(string name, Type type, int index)
    {
        Name = name;
        DataType = type;
        Index = index;
    }
}
