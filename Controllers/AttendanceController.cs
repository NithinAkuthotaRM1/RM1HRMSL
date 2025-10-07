using Leave.Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Leave.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private static List<Attendance> _attendances = new List<Attendance>();

        [HttpGet]
        public IActionResult GetAll() => Ok(_attendances);

        [HttpPost]
        public IActionResult Add(Attendance item)
        {
            _attendances.Add(item);
            return Ok(item);
        }

        [HttpPut("{employeeId}")]
        public IActionResult Update(int employeeId, Attendance updated)
        {
            var item = _attendances.FirstOrDefault(x => x.EmployeeId == employeeId && x.Date == updated.Date);
            if (item == null) return NotFound();
            item.Status = updated.Status;
            item.CheckInTime = updated.CheckInTime;
            item.CheckOutTime = updated.CheckOutTime;
            return Ok(item);
        }

        [HttpDelete("{employeeId}")]
        public IActionResult Delete(int employeeId)
        {
            _attendances.RemoveAll(x => x.EmployeeId == employeeId);
            return Ok();
        }
    }

}
