using EITBackend.Common.Models;

namespace EITBackend.Common.Adapters.IAdapters
{
    public interface ICityAdapter
    {
        IEnumerable<City> GetAllCity();

        string GetCityName(int cityId);
    }
}
