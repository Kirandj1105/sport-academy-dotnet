using Microsoft.AspNetCore.Identity;

namespace SportsAcademy.Models
{
    public class User 
    {
        public Guid Id { get; set; }
        public String? FirstName { get; set; }
        public String? MiddleName { get; set; }

        public String? LastName { get; set; }

        public String? Email { get; set; }

        public String? Gender { get; set; }

        public String? Country { get; set; }
        public String? Password { get; set; }

        public String? ConfirmPassword { get; set; }

        public int? Age { get; set;}


    }
}
