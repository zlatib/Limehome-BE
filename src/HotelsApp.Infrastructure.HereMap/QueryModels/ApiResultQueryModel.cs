﻿namespace HotelsApp.Infrastructure.HereMap.QueryModels
{
    using System.Text.Json.Serialization;

    public class ApiResultQueryModel
    {
        [JsonPropertyName("results")]
        public ApiItemsQueryModel Results { get; set; }
    }
}
