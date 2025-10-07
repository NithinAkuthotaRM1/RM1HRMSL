namespace Leave.Controllers.Models
{
    public class Shift
    {
        public int ShiftId { get; set; }
        public int EmployeeId { get; set; }
        public string ShiftType { get; set; }  // day, night, flexible

        // Use TimeSpan for start and end time
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
