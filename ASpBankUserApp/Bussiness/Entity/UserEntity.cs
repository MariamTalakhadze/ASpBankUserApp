using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entity
{
    public class UserEntity
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }

        public string PersonalNumber { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }

        public int GenderID { get; set; }

        public int CountryID { get; set; }

        public int CityID { get; set; }
        public GenderEntity Gender { get; set; }
        public CityEntity City { get; set; }
        public CountryEntity Country { get; set; }
    }
}
