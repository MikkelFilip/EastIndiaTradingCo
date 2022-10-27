using EITBackend.Common.Adapters.IAdapters;
using EITBackend.Common.Models;

namespace EITBackend.Common.Adapters
{
    public class ConnectedCitiesSegmentAdapter : IConnectedCitiesSegmentAdapter
    {
        public ConnectedCitiesSegmentAdapter()
        {

        }

        public IEnumerable<ConnectedCitiesSegment> GetConnectedCitiesSegment(int cityId)
        {
            List<ConnectedCitiesSegment> connectedCitiesSegments = new List<ConnectedCitiesSegment>();

            connectedCitiesSegments.Add(new ConnectedCitiesSegment
            {
                ConnectedCitiesSegmentId = 1,
                FromCityId = 1,
                ToCityId = 2,
                Segments = 3,
            });

            return connectedCitiesSegments;
        }
    }
}
