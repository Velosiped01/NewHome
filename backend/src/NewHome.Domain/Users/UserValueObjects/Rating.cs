using NewHome.Domain.Shared;
namespace NewHome.Domain.Users.UserValueObjects
{
    public record Rating
    {
        private Rating(double rating)
        {
            Value = rating;
        }

        public double Value { get; }
     

        public static Result<Rating> Create(double _rating)
        {
            if (_rating <= 0)
                return "Invalid rating";
            var rating = new Rating(_rating);
            return Result<Rating>.Success(rating);
        }
        public static Rating CreateFromDB(double input) => new(input);
    }
}

