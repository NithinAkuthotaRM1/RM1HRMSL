namespace Leave.Controllers.Models
{
    public class Holiday
    {
        public int HolidayId { get; set; }
        public DateTime Date { get; set; }
        public string HolidayName { get; set; }
        public string Type { get; set; } // National / Festival
        public string ApplicableLocation { get; set; } // hyd, chennai, banglore
    }
}
