namespace Leave.Controllers.Models
{
    public class LeaveWorkflow
    {
        public int LeaveId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool ManagerApproval { get; set; }
        public bool LeadApproval { get; set; }
        public bool HRApproval { get; set; }
    }

}
