using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHome.Domain.Shared
{
    public abstract class Entities<TId> where TId : notnull
    {
        public TId Id { get; protected set; }

        protected Entities(TId id)
        {
            Id = id;
        }
    }
}
