using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Dog.Models
{
    public class DogImageApi
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
