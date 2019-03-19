using System;
using System.Data;

namespace PocketChange.Models
{
    public class UserCredentials
    {
        public UserCredentials(DataRow dr)
        {
            UserId = dr.Field<Guid>("UserId");
            Salt = dr.Field<string>("Salt");
        }
        
        public Guid UserId { get; }
        public string Salt { get; }
    }
}