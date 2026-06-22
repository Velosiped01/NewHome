using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NewHome.Domain
{
    internal class User
    {
        public Guid user_id { get; init; }

        public string name {
            get { return name; } 
            set
            {
                if (value != null)
                {
                    name = value;
                }
                else { name = "Jigilli Wiggily"; }

            } }

        public string surname { get; set; }
        
        public int raiting { get; set; } 

        public string user_id_card_number { get; set; }




    }
}
