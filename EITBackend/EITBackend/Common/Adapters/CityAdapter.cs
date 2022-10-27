using EITBackend.Common.Adapters.IAdapters;
using EITBackend.Common.Models;

namespace EITBackend.Common.Adapters
{
    public class CityAdapter : ICityAdapter
    {
        private DataContext context;
        public CityAdapter(DataContext context)
        {
            this.context = context;
        }
        public IEnumerable<City> GetAllCity()
        {
            return context.cities.ToList();
        }

        public string GetCityName(int cityId)
        {
            return context.cities.Where(city => city.CityId == cityId).Select(city => city.Name).FirstOrDefault();
        }
    }
}
