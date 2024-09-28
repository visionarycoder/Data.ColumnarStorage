using Archivum.Internal;

namespace Archivum;

public class Record
{

    private readonly Guid dataId;

    public Record(object value)
    {
        var data = DataCache.GetData(value);
        dataId = data.Id;
    }

    public object Value
    {
        get
        {
            var data = DataCache.GetDataById(dataId);
            return data.Value;
        }
    }
}
