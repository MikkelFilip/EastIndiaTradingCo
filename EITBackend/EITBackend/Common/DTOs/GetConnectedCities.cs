namespace EITBackend.Common.DTOs
{
    public class GetConnectedCities
    {
        public string? Provider { get; set; }

        public IEnumerable<ConnectedCities>? ConnectedCities { get; set; }
    }
}
