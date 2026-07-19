using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHome.Domain.UserData
{
    public class Picture
    {
        public Guid Id { get; set; }

        public string Path { get; set; } = default!;

    }
}
