using Leave.Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Leave.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveWorkflowController : ControllerBase
    {
        private static List<LeaveWorkflow> _leaveRequests = new List<LeaveWorkflow>();

        [HttpGet]
        public IActionResult GetAll() => Ok(_leaveRequests);

        [HttpPost]
        public IActionResult Add(LeaveWorkflow item)
        {
            _leaveRequests.Add(item);
            return Ok(item);
        }

        [HttpPut("{leaveId}")]
        public IActionResult Update(int leaveId, LeaveWorkflow updated)
        {
            var item = _leaveRequests.FirstOrDefault(x => x.LeaveId == leaveId);
            if (item == null) return NotFound();
            item.EmployeeId = updated.EmployeeId;
            item.StartDate = updated.StartDate;
            item.EndDate = updated.EndDate;
            item.ManagerApproval = updated.ManagerApproval;
            item.LeadApproval = updated.LeadApproval;
            item.HRApproval = updated.HRApproval;
            return Ok(item);
        }

        [HttpDelete("{leaveId}")]
        public IActionResult Delete(int leaveId)
        {
            _leaveRequests.RemoveAll(x => x.LeaveId == leaveId);
            return Ok();
        }
    }

}
