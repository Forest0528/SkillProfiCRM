using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillProfiCRM.Data;
using SkillProfiCRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkillProfiCRM.Models;

namespace SkillProfiCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuButtonController : ControllerBase
    {
        private readonly SkillProfiContext _context;

        public MenuButtonController(SkillProfiContext context)
        {
            _context = context;
        }

        // GET: api/MenuButton
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuButton>>> GetMenuButtons()
        {
            return await _context.MenuButtons.ToListAsync();
        }

        // GET: api/MenuButton/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuButton>> GetMenuButton(int id)
        {
            var menuButton = await _context.MenuButtons.FindAsync(id);

            if (menuButton == null)
            {
                return NotFound();
            }

            return menuButton;
        }

        // PUT: api/MenuButton/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuButton(int id, MenuButton menuButton)
        {
            if (id != menuButton.Id)
            {
                return BadRequest();
            }

            _context.Entry(menuButton).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuButtonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MenuButton
        [HttpPost]
        public async Task<ActionResult<MenuButton>> PostMenuButton(MenuButton menuButton)
        {
            _context.MenuButtons.Add(menuButton);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenuButton", new { id = menuButton.Id }, menuButton);
        }

        // DELETE: api/MenuButton/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuButton(int id)
        {
            var menuButton = await _context.MenuButtons.FindAsync(id);
            if (menuButton == null)
            {
                return NotFound();
            }

            _context.MenuButtons.Remove(menuButton);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuButtonExists(int id)
        {
            return _context.MenuButtons.Any(e => e.Id == id);
        }
    }
}
