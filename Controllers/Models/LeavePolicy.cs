namespace Leave.Controllers.Models
{
    public class LeavePolicy
    {
        public int PolicyId { get; set; }
        public string LeaveType { get; set; } // Sick, Casual, Earned, etc.
        public bool CarryForwardAllowed { get; set; }
        public string EligibilityCriteria { get; set; }
    }

}
