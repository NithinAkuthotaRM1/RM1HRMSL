using Leave.Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Leave.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HolidayCalendarController : ControllerBase
    {
        private static List<Holiday> _holidays = new List<Holiday>();

        [HttpGet]
        public IActionResult GetAll() => Ok(_holidays);

        [HttpPost]
        public IActionResult Add(Holiday item)
        {
            _holidays.Add(item);
            return Ok(item);
        }

        [HttpPut("{holidayId}")]
        public IActionResult Update(int holidayId, Holiday updated)
        {
            var item = _holidays.FirstOrDefault(x => x.HolidayId == holidayId);
            if (item == null) return NotFound();
            item.Date = updated.Date;
            item.HolidayName = updated.HolidayName;
            item.Type = updated.Type;
            item.ApplicableLocation = updated.ApplicableLocation;
            return Ok(item);
        }

        [HttpDelete("{holidayId}")]
        public IActionResult Delete(int holidayId)
        {
            _holidays.RemoveAll(x => x.HolidayId == holidayId);
            return Ok();
        }
    }

}
