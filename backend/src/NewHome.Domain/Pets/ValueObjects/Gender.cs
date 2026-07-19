using CSharpFunctionalExtensions;
using System.Reflection.Metadata.Ecma335;

namespace NewHome.Domain.Pets.ValueObjects
{
    public record Gender
    {
        public string Value { get; }

        private Gender(string value)
        {
            Value = value;
        }

        public static readonly Gender Male = new(nameof(Male));
        public static readonly Gender Female = new(nameof(Female));

        public static readonly Gender[] _all = [Male, Female];

        public static Result<Gender> Create(string input)
        {
            var gender = _all.FirstOrDefault(x => x.Value.Equals(input, StringComparison.OrdinalIgnoreCase));

            return gender is null ? Result.Failure<Gender>("Gender isn't valid") : Result.Success(gender);

        }

        public override string ToString() => Value;
        
       
    }
}
