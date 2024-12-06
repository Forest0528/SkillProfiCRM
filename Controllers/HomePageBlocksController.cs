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
    public class HomePageBlockController : ControllerBase
    {
        private readonly SkillProfiContext _context;

        public HomePageBlockController(SkillProfiContext context)
        {
            _context = context;
        }

        // GET: api/HomePageBlock
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HomePageBlock>>> GetHomePageBlocks()
        {
            return await _context.HomePageBlocks.ToListAsync();
        }

        // GET: api/HomePageBlock/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HomePageBlock>> GetHomePageBlock(int id)
        {
            var homePageBlock = await _context.HomePageBlocks.FindAsync(id);

            if (homePageBlock == null)
            {
                return NotFound();
            }

            return homePageBlock;
        }

        // PUT: api/HomePageBlock/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHomePageBlock(int id, HomePageBlock homePageBlock)
        {
            if (id != homePageBlock.Id)
            {
                return BadRequest();
            }

            _context.Entry(homePageBlock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomePageBlockExists(id))
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

        // POST: api/HomePageBlock
        [HttpPost]
        public async Task<ActionResult<HomePageBlock>> PostHomePageBlock(HomePageBlock homePageBlock)
        {
            _context.HomePageBlocks.Add(homePageBlock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHomePageBlock", new { id = homePageBlock.Id }, homePageBlock);
        }

        // DELETE: api/HomePageBlock/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomePageBlock(int id)
        {
            var homePageBlock = await _context.HomePageBlocks.FindAsync(id);
            if (homePageBlock == null)
            {
                return NotFound();
            }

            _context.HomePageBlocks.Remove(homePageBlock);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HomePageBlockExists(int id)
        {
            return _context.HomePageBlocks.Any(e => e.Id == id);
        }
    }
}
