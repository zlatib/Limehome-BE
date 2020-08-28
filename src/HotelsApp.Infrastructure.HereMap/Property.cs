using HotelsApp.Infrastructure.HereMap.ContactsModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelsApp.Infrastructure.HereMap
{
    internal class Property
    {
        [JsonProperty("placeId")]
        public string PlaceId { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("view")]
        public string ViewUrl { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("contacts")]
        public ContactsModel Contacts { get; set; }
    }

    internal class Location
    {
        [JsonProperty("position")]
        public decimal[] Position { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }

    internal class Address
    {
        [JsonProperty("country")]
        public string Country { get; set; }
        
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("street")]
        public string Street{ get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
    }
}
