using CSharpFunctionalExtensions;
using NewHome.Domain.Users.UserValueObjects;
using NewHome.Domain.Pets;
using NewHome.Domain.UserData.Evaluation.EvaluationVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using NewHome.Domain.Shared;
using NewHome.Domain.UserData.Evaluation;

namespace NewHome.Domain.Users
{
    public sealed class User : Shared.Entity<UserId>
    {
        //ef core
        private User(UserId id) : base(id)
        {
        }

        private User(UserId user_id, string name, string surname, PhoneNumber phonenumber, List<Evaluation> u_evaluations, string picture) : base(user_id)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phonenumber;
            UserEvaluations = u_evaluations;
            PicturePath = picture;
        }


        public string Name { get; private set; }

        public string Surname { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public List<Evaluation> UserEvaluations { get; private set; } = [];

        public Rating Raiting { get; private set; }

        public string PicturePath { get; private set; }

        public ICollection<Pet> UserPets { get; private set; } = [];

        public static Result<User> Create(UserId uid, string name, string surname, PhoneNumber phonenumber, string picture)
        {
            if (string.IsNullOrWhiteSpace(name)) return Result.Failure<User>("Name is required");

            if (string.IsNullOrWhiteSpace(surname)) return Result.Failure<User>("Surname is required");

            if (phonenumber == null) return Result.Failure<User>("Phone number is required");

            var user = new User(uid, name, surname, phonenumber, new List<Evaluation>{ }, picture);

            return Result.Success(user);

        }

        public static double GetRating(User user)
        {
            if (user.UserEvaluations.Count == 0)
                return 0;

            double result;

            result = user.UserEvaluations.Average(x => x.RatingValue);

            return result;
        }   

        public void SetPicture(string path)
        {
            PicturePath = path;
        }
        public void RemovePicture()
        {
            PicturePath = null;
        }
    }


}

