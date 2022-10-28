using EITBackend.Common.DTOs;

namespace EITBackend.Common.Services.IServices
{
    public interface IPossibleRouteService
    {
        public List<PossibleRoute> GetPossibleRoutes(QueryPossibleRoute query);
    }
}
