    using CSharpFunctionalExtensions;
    using NewHome.Domain.Shared;
    using NewHome.Domain.Users;
using NewHome.Domain.Users.UserValueObjects;
namespace NewHome.Domain.UserData.Evaluation.EvaluationVO;

    public class Evaluation : Shared.Entity<EvaluationId>
    {
        private Evaluation(EvaluationId id, User user, string comment, double ratingValue, DateTime date) : base(id)
        {
            User = user;
            UserId = user.Id;
            Comment = comment;
            RatingValue = ratingValue;
            Date = date;
        }
        private Evaluation(EvaluationId id) : base(id)
        {
        }

    
        public User User { get; }

        public UserId UserId { get; }

        public string Comment { get; }

        public double RatingValue { get; } 

        public DateTime Date { get; }
    
      
        public static Result<Evaluation> Create(User user, string comment, double ratingValue)
        {
            if (string.IsNullOrWhiteSpace(comment))
                return "Necessary comment";
            if (ratingValue <= 0)
                return "Invalid rating";

            var evaluation = new Evaluation(EvaluationId.NewEvaluationId(), user, comment, ratingValue, DateTime.Now);

            return Result<Evaluation>.Success(evaluation);
        }
    }
