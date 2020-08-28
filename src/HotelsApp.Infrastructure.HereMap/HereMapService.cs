namespace HotelsApp.Infrastructure.HereMap
{
    using HotelsApp.Core.Contracts.Services;
    using HotelsApp.Core.Models;
    using HotelsApp.Infrastructure.HereMap.QueryModels;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class HereMapService : IHereMapService
    {
        private readonly HttpClient httpClient;
        private const string defaultHotelPicture = "https://freedesignfile.com/upload/2019/07/Hotel-cartoon-vector.jpg";

        public HereMapService()
        {
            this.httpClient = HttpClientFactory.Create();
        }

        public async Task<PropertyModel[]> GetProperties(string latitude, string longtitude)
        {
            string url = $"https://places.sit.ls.hereapi.com/places/v1/discover/explore?at={latitude}%2C{longtitude}&cat=hotel&&app_id=Q3fk87P2N4cpAe1iD1GP&app_code=oZI45mGxl_rZMAQxulMNrw";
            var response = await httpClient.GetAsync(url);
            var resultAsString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResultQueryModel>(resultAsString);

            var foundHotels = result.Results.Items
                .Take(4)
                .ToList();

            if (foundHotels.Count == 0)
            {
                throw new Exception("No hotels were found on this location!");
            }

            var hotelsResult = new List<PropertyModel>();

            foreach (var hotel in foundHotels)
            {
                var getHotelInfo = await this.httpClient.GetAsync(hotel.Href);
                var infoAsString = await getHotelInfo.Content.ReadAsStringAsync();
                var hotelInfo = JsonConvert.DeserializeObject<Property>(infoAsString);
                if(hotelInfo != null 
                    && !string.IsNullOrWhiteSpace(hotelInfo.PlaceId) 
                    && hotelInfo.Location != null && hotelInfo.Location.Address != null)
                {
                    //if (hotelInfo.Media.Images?.Items.Count == 0)
                    //{
                    //    hotelInfo.Media.Images.Items.Add(new ImagesHotelModel
                    //    {
                    //        Value = defaultHotelPicture,
                    //    });
                    //}

                    hotelsResult.Add(new PropertyModel
                    {
                        PropertyId = hotelInfo.PlaceId,
                        PropertyName = hotelInfo.Name,
                        AddressInfo = hotelInfo.Location.Address.Street,
                        Country = hotelInfo.Location.Address.Country,
                        City = hotelInfo.Location.Address.City,
                        Phone = hotelInfo.Contacts.Phone[0]?.Value ?? string.Empty
                    });
                }
            }

            return hotelsResult.ToArray();
        }
    }
}