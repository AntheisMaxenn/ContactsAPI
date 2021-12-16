using System.Text.Json.Serialization;

namespace ContactsAPI.Models
{
    public class Contact
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Address")]
        public string Address { get; set; }


        [JsonPropertyName("Telephone")]
        public string Telephone { get; set; }
    }
}
