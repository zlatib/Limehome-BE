namespace HotelsApp.Infrastructure.HereMap.QueryModels
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class ApiItemsQueryModel
    {
        [JsonPropertyName("items")]
        public List<PropertyQueryModel> Items { get; set; }
    }
}