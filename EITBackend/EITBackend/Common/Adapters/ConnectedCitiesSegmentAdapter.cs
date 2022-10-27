﻿using EITBackend.Common.Adapters.IAdapters;
using EITBackend.Common.Models;

namespace EITBackend.Common.Adapters
{
    public class ConnectedCitiesSegmentAdapter : IConnectedCitiesSegmentAdapter
    {
        private DataContext context;
        public ConnectedCitiesSegmentAdapter(DataContext context)
        {
            this.context = context;
        }
        //TODO: Change string name to int cityId
        public IEnumerable<ConnectedCitiesSegment> GetConnectedCitiesSegment(String cityName)
        {

            City city = context.cities.Where(city => city.Name == cityName).FirstOrDefault();
            List<ConnectedCitiesSegment> connectedCitiesSegments = QueryConnectedCitiesSegment(city);
            return connectedCitiesSegments;
        }

        private List<ConnectedCitiesSegment> QueryConnectedCitiesSegment(City city)
        {
            return context.connectedCitiesSegments.Where(segment => segment.FromCityId == city.CityId).ToList();
        }
    }
}