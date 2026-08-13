using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHome.Domain.Pets.ValueObjects
{
    public record PetId
    {
        public Guid Value{ get;}

        private PetId(Guid value)
        {
           Value = value;
        }

        public static PetId NewPetId() => new(Guid.NewGuid());

        public static PetId Empty() => new(Guid.Empty);

        public static PetId CreateFromDB(Guid id) => new(id);
    }
}
