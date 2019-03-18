using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocketChange.Models
{
    public class Registration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegistrationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        
        public Credentials Credentials { get; set; }
    }

    public class Credentials
    {
        public int CredentialsId { get; set; }
        public string Salt { get; set; }
        
        public int RegistrationFK { get; set; }
        
        [ForeignKey("ReigstrationFK")]
        public Registration Registration { get; set; }
    }
}