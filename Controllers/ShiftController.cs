using Leave.Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Leave.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShiftController : ControllerBase
    {
        private static readonly List<Shift> _shifts = new();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_shifts);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Shift item)
        {
            if (item == null)
                return BadRequest("Shift data is required");

            // Optional: Simple validation
            if (item.ShiftId <= 0 || item.EmployeeId <= 0 || string.IsNullOrWhiteSpace(item.ShiftType))
                return BadRequest("Invalid shift data");

            _shifts.Add(item);
            return Ok(item);
        }

        [HttpPut("{shiftId}")]
        public IActionResult Update(int shiftId, [FromBody] Shift updated)
        {
            var existing = _shifts.FirstOrDefault(x => x.ShiftId == shiftId);
            if (existing == null)
                return NotFound();

            existing.EmployeeId = updated.EmployeeId;
            existing.ShiftType = updated.ShiftType;
            existing.StartTime = updated.StartTime;
            existing.EndTime = updated.EndTime;

            return Ok(existing);
        }

        [HttpDelete("{shiftId}")]
        public IActionResult Delete(int shiftId)
        {
            var removed = _shifts.RemoveAll(x => x.ShiftId == shiftId);
            if (removed == 0)
                return NotFound();

            return Ok();
        }
    }
}
