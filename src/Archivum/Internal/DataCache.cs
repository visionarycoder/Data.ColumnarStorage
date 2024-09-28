using Archivum.Internal;

namespace Archivum;

public static class DataCache
{

    private static readonly HashSet<Data> dataSet = new();

    public static Data GetData(object value)
    {
        var data = new Data { Value = value };
        dataSet.Add(data);
        return data;
    }

}