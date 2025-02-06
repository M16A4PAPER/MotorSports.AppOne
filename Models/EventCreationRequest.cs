namespace MotorSports.AppOne.Models
{
    public class EventCreationRequest
    {
        public string EventName { get; set; } = null!;
        public int VenueId { get; set; }
        public DateTime EventDate { get; set; }
        public int TotalLaps { get; set; }
        public int StatusId { get; set; }
    }
}
