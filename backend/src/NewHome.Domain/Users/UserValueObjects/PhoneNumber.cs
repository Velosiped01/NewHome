using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;
namespace NewHome.Domain.Users.UserValueObjects
{
    public record PhoneNumber
    {
        private PhoneNumber(string number)
        {
            Value = number;
        }


        private static readonly string phoneRegex = @"^[\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$";
        public string Value { get; }
        
        
        public static Result<PhoneNumber> Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return Result.Failure<PhoneNumber>("Phone number is required");
            if (!Regex.IsMatch(input, phoneRegex))
                return Result.Failure<PhoneNumber>("Invalid phone number");

            var number = new PhoneNumber(input.Trim().Replace(" ", "").Replace("-", ""));

            return Result.Success(number);

        }

        public static PhoneNumber CreateFromDB(string input) => new(input);
    }
}
