using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELA_Data_Service.Contracts.V1.Responses.Users
{
    public class UserDataResponse
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public int Points { get; set; }

        public string ImgUrl { get; set; }

        public DateTime RegDate { get; set; }
    }
}
