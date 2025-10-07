using Leave.Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Leave.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeavePolicyController : ControllerBase
    {
        private static List<LeavePolicy> _policies = new List<LeavePolicy>();

        [HttpGet]
        public IActionResult GetAll() => Ok(_policies);

        [HttpPost]
        public IActionResult Add(LeavePolicy item)
        {
            _policies.Add(item);
            return Ok(item);
        }

        [HttpPut("{policyId}")]
        public IActionResult Update(int policyId, LeavePolicy updated)
        {
            var item = _policies.FirstOrDefault(x => x.PolicyId == policyId);
            if (item == null) return NotFound();
            item.LeaveType = updated.LeaveType;
            item.CarryForwardAllowed = updated.CarryForwardAllowed;
            item.EligibilityCriteria = updated.EligibilityCriteria;
            return Ok(item);
        }

        [HttpDelete("{policyId}")]
        public IActionResult Delete(int policyId)
        {
            _policies.RemoveAll(x => x.PolicyId == policyId);
            return Ok();
        }
    }

}
