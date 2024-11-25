using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillProfiCRM.Data;
using SkillProfiCRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillProfiCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly SkillProfiContext _context;

        public RequestController(SkillProfiContext context)
        {
            _context = context;
        }

        // GET: api/Request
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequests()
        {
            return await _context.Requests.ToListAsync();
        }

        // GET: api/Request/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }

        // PUT: api/Request/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest(int id, Request request)
        {
            if (id != request.Id)
            {
                Console.WriteLine($"Bad Request: URL ID ({id}) does not match body ID ({request.Id})");
                return BadRequest(new { error = "ID in URL does not match ID in body" });
            }

            var existingRequest = await _context.Requests.FindAsync(id);
            if (existingRequest == null)
            {
                Console.WriteLine($"Not Found: Request with ID {id} does not exist.");
                return NotFound(new { error = "Request not found" });
            }

            // Обновляем только измененные поля
            existingRequest.FirstName = request.FirstName;
            existingRequest.LastName = request.LastName;
            existingRequest.Email = request.Email;
            existingRequest.Message = request.Message;
            existingRequest.Status = request.Status;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine($"Concurrency exception: {ex.Message}");
                return StatusCode(500, new { error = "Failed to update request", details = ex.Message });
            }

            return NoContent();
        }

        // POST: api/Request
        [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequest", new { id = request.Id }, request);
        }

        // DELETE: api/Request/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }
    }
}
