using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PocketChange.API.Models
{
    public class User
    {
        public User() { }

        public User(DataRow dr)
        {
            UserId = dr.Field<Guid>("UserId");
            FirstName = dr.Field<string>("FirstName");
            LastName = dr.Field<string>("LastName");
            EmailAddress = dr.Field<string>("EmailAddress");
        }

        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}
