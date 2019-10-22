using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookTracker.Models;
using BookTracker.Models.Contexts;

namespace BookTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly SeriesContext _context;

        public SeriesController(SeriesContext context)
        {
            _context = context;
        }

        // GET: api/Series
        [HttpGet]
        public IEnumerable<Series> GetSeriesItems()
        {
            return _context.SeriesItems;
        }

        // GET: api/Series/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeries([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var series = await _context.SeriesItems.FindAsync(id);

            if (series == null)
            {
                return NotFound();
            }

            return Ok(series);
        }

        // PUT: api/Series/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeries([FromRoute] int id, [FromBody] Series series)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != series.SeriesID)
            {
                return BadRequest();
            }

            _context.Entry(series).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeriesExists(id))
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

        // POST: api/Series
        [HttpPost]
        public async Task<IActionResult> PostSeries([FromBody] Series series)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SeriesItems.Add(series);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeries", new { id = series.SeriesID }, series);
        }

        // DELETE: api/Series/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeries([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var series = await _context.SeriesItems.FindAsync(id);
            if (series == null)
            {
                return NotFound();
            }

            _context.SeriesItems.Remove(series);
            await _context.SaveChangesAsync();

            return Ok(series);
        }

        private bool SeriesExists(int id)
        {
            return _context.SeriesItems.Any(e => e.SeriesID == id);
        }
    }
}