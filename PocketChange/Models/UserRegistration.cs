using System;
using System.Data;

namespace PocketChange.Models
{
    public class UserRegistration
    {
        public UserRegistration(DataRow dr)
        {
            UserId = dr.Field<Guid>("UserId");
            Username = dr.Field<string>("Username");
            PasswordHash = dr.Field<string>("PasswordHash");
        }
        
        public Guid UserId { get; }
        public string Username { get; }
        public string PasswordHash { get; }
    }
}