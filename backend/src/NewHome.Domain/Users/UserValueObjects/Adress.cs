using NewHome.Domain.Shared;

namespace NewHome.Domain.Users.UserValueObjects
{
    public record Adress
    {
        public string Country { get; }

        public string City { get; }

        public string Street { get; }

        private Adress() { }

        private Adress(string country, string city, string street)
        {
            Country = country;
            City = city;
            Street = street;
        }

        public Result<Adress> Create(string country, string city, string street)
        {
            if (string.IsNullOrWhiteSpace(country)) return "required your Country";

            if (string.IsNullOrWhiteSpace(city)) return "required your City";

            if (string.IsNullOrWhiteSpace(street)) return "required your Sreet";

            var adress = new Adress(country, city, street);
            return Result<Adress>.Success(adress);
        }

    }


}

