namespace Leave.Controllers.Models
{
    public class Attendance
    {
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } // "Present" or "Absent"
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
    }

}
