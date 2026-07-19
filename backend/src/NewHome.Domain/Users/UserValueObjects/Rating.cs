using CSharpFunctionalExtensions;

namespace NewHome.Domain.Users.UserValueObjects
{
    public record Rating
    {
        public double Value { get; } = 0;

        private Rating(double rating)
        {
            Value = rating;
        }

        public static Result<Rating> Create(double _rating)
        {
            if (_rating <= 0)
                return Result.Failure<Rating>("Invalid rating");
            var rating = new Rating(_rating);
            return Result.Success(rating);
        }
    }
}

