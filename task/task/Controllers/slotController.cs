using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using task.DAL;

[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    private readonly EventDbContext _context;

    public EventController(EventDbContext context)
    {
        _context = context;
    }

    [HttpGet("getSlots")]
    public IActionResult GetSlots()
    {
        var freeSlots = _context.EventSlots.Where(slot => !slot.IsBooked).ToList();
        return Ok(freeSlots);
    }

    [HttpPost("bookSlot/{slotId}")]
    public async Task<IActionResult> BookSlot(int slotId)
    {
        var slot = await _context.EventSlots.FindAsync(slotId);

        if (slot == null)
        {
            return NotFound("Slot not found");
        }

        if (slot.IsBooked)
        {
            return BadRequest("Slot already booked");
        }

        slot.IsBooked = true;
        await _context.SaveChangesAsync();

        return Ok("Slot booked successfully");
    }
}
