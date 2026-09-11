using NewHome.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NewHome.Domain.Pets.ValueObjects
{
    public record Species
    {
        public string Value { get;}
        private Species(string value)
        { 
            Value = value;
        }
    
        public static readonly Species Dog = new(nameof(Dog));
        public static readonly Species Cat = new(nameof(Cat));
        public static readonly Species Rodent = new(nameof(Rodent));
        public static readonly Species Bird = new(nameof(Bird));
        public static readonly Species Reptile = new(nameof(Reptile));
        public static readonly Species Fish = new(nameof(Fish));
        public static readonly Species Other = new(nameof(Other));

        public static readonly Species[] _all = [Dog, Cat, Rodent, Bird, Reptile, Fish, Other];

        public static Result<Species> Create(string input)
        {
            var species = _all.FirstOrDefault(x => x.Value.Equals(input, StringComparison.OrdinalIgnoreCase));

            return species is null ? "Invalid species " : Result<Species>.Success(species);
        }
        public override string ToString() => Value;

        public static Species CreateFromDB(string input) => new(input);
    }
}
