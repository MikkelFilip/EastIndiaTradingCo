using EITBackend.Common.Models;

namespace EITBackend.Common.Adapters.IAdapters
{
    public interface IConnectedCitiesSegmentAdapter
    {
        IEnumerable<ConnectedCitiesSegment> GetConnectedCitiesSegment(string name);
    }
}
