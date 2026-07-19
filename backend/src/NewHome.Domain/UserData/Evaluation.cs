using CSharpFunctionalExtensions;
using NewHome.Domain.Users.UserValueObjects;
namespace NewHome.Domain.UserData
{
    public class Evaluation
    {
        public UserId User_Id { get; }

        public string Comment { get; }

        public double RatingValue { get; } 
        
        private Evaluation()
        {
        }

        private Evaluation(UserId userId, string comment, double ratingValue)
        {
            User_Id = userId;
            Comment = comment;
            RatingValue = ratingValue;
        }

        public static Result<Evaluation> Create(UserId userId, string comment, double ratingValue)
        {
            if (string.IsNullOrWhiteSpace(comment))
                return Result.Failure<Evaluation>("Necessary comment");
            if (ratingValue <= 0)
                return Result.Failure<Evaluation>("Invalid rating");

            var evaluation = new Evaluation(userId, comment, ratingValue);

            return Result.Success(evaluation);
        }
    }
}
