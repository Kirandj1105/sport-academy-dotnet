using Microsoft.AspNetCore.Identity;

namespace SportsAcademy.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; internal set; }
        public string? Country { get; internal set; }
        public string? Gender { get; internal set; }
        public int? Age { get; internal set; }
        public string? Role { get; internal set; }
        public string? PreviousOrganizationExperience { get; internal set; }
        public DateTime? StartTime { get; internal set; }
        public DateTime? EndTime { get; internal set; }
        public decimal? Salary { get; internal set; }
    }
}
