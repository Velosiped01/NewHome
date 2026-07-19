using CSharpFunctionalExtensions;
using NewHome.Domain.UserData;
using NewHome.Domain.Users.UserValueObjects;
using NewHome.Domain.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using NewHome.Domain.Shared;

namespace NewHome.Domain.Users
{
    public class User : Entities<UserId>
    {
        public string Name { get; private set; }

        public string Surname { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public bool IsVolunteer { get; private set; } = false;

        public List<Evaluation> U_Evaluations { get; private set; } = [];

        public Rating Raiting { get; }

        public List<Picture> Pictures { get; private set; } = [];

        public List<Pet> UserPets { get; private set; } = [];



        public static Result<User> Create(UserId uid, string name, string surname, PhoneNumber phonenumber, bool isvolunteer)
        {
            if (string.IsNullOrWhiteSpace(name)) return Result.Failure<User>("Name is required");

            if (string.IsNullOrWhiteSpace(surname)) return Result.Failure<User>("Surname is required");

            if (phonenumber == null) return Result.Failure<User>("Phone number is required");

            var user = new User(uid, name, surname, phonenumber, isvolunteer, new List<Evaluation>{ }, new List<Picture>{ });

            return Result.Success(user);

        }

        private User(UserId id) : base(id)
        {
        }

        private User(UserId user_id, string name, string surname, PhoneNumber phonenumber, bool isvolunteer, List<Evaluation> u_evaluations, List<Picture> pictures) : base(user_id)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phonenumber;
            IsVolunteer = isvolunteer;
            U_Evaluations = u_evaluations;
            Pictures = pictures;
        }
        public static double GetRating(User user)
        {
            if (user.U_Evaluations.Count == 0)
                return 0;

            double result;

            result = user.U_Evaluations.Average(x => x.RatingValue);

            return result;
        }   
    }


}

