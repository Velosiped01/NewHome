using CSharpFunctionalExtensions;

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
                return Result.Failure<Rating>("Invalid rating");
            var rating = new Rating(_rating);
            return Result.Success(rating);
        }
        public static Rating CreateFromDB(double input) => new(input);
    }
}

