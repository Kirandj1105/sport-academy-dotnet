namespace SportsAcademy.Models
{
    public class Event
    {
        public  Guid Id { get; set; }
        public string? EventName { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
    }
}
