using System.Text.Json.Serialization;

namespace Data.DataEntities
{
    public class UserDataEntity
    {
        [JsonPropertyName("address")]
        public Address AddressProperty { get; set; } = new Address();
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
        [JsonPropertyName ("username")]
        public string Username { get; set; } = string.Empty;
        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        public Name NameProperty { get; set; } = new Name();
        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;
        [JsonPropertyName("__v")]
        public int V { get; set; }

        public class Address
        {
            [JsonPropertyName("geolocation")]
            public Geolocation GeolocationProperty { get; set; } = new Geolocation();
            [JsonPropertyName("city")]
            public string City { get; set; } = string.Empty;
            [JsonPropertyName("street")]
            public string Street { get; set; } = string.Empty;
            [JsonPropertyName("number")]
            public int Number { get; set; }
            [JsonPropertyName("zipcode")]
            public string ZipCode { get; set; } = string.Empty;

            public class Geolocation
            {
                [JsonPropertyName("lat")]
                public string Lat { get; set; } = string.Empty;
                [JsonPropertyName("long")]
                public string Long { get; set; } = string.Empty;
            }
        }

        public class Name
        {
            [JsonPropertyName("firstname")]
            public string FirstName { get; set; } = string.Empty;
            [JsonPropertyName("lastname")]
            public string LastName { get; set; } = string.Empty;
        }

    }
}
