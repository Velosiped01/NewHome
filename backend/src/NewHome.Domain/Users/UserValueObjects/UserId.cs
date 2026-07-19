using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHome.Domain.Users.UserValueObjects
{
    public record UserId
    {

        public Guid Value {  get;}

        public static UserId NewUserId() => new(Guid.NewGuid());

        public static UserId Empty() => new(Guid.Empty);

        private UserId(Guid value)
        {
            Value = value;
        }
    }
}
