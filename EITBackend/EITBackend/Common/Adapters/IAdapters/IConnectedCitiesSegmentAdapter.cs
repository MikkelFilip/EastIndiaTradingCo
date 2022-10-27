using EITBackend.Common.Models;

namespace EITBackend.Common.Adapters.IAdapters
{
    public interface IConnectedCitiesSegmentAdapter
    {
        List<ConnectedCitiesSegment> GetAll();

        IEnumerable<ConnectedCitiesSegment> GetConnectedCitiesSegment(string name);
    }
}
