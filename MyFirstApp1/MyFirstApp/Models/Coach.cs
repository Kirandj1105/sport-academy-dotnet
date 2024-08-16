using Microsoft.AspNetCore.Identity;

namespace SportsAcademy.Models
{
    public class Coach 
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Country { get; set; }
        public string? Gender { get; set; }
     
        public string? PreviousOrganizationExperience { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? Salary { get; set; }
    }
}
