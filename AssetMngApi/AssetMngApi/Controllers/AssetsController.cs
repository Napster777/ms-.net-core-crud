using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AssetMngApi.Models;

namespace AssetMngApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly ModelContext _context;

        public AssetsController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Assets
        [HttpGet]
        public IEnumerable<Assets> Getassets()
        {
            return _context.assets;
        }

        // GET: api/Assets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssets([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assets = await _context.assets.FindAsync(id);

            if (assets == null)
            {
                return NotFound();
            }

            return Ok(assets);
        }

        // PUT: api/Assets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssets([FromRoute] int id, [FromBody] Assets assets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assets.AssetId)
            {
                return BadRequest();
            }

            _context.Entry(assets).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetsExists(id))
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

        // POST: api/Assets
        [HttpPost]
        public async Task<IActionResult> PostAssets([FromBody] Assets assets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.assets.Add(assets);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssets", new { id = assets.AssetId }, assets);
        }

        // DELETE: api/Assets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssets([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assets = await _context.assets.FindAsync(id);
            if (assets == null)
            {
                return NotFound();
            }

            _context.assets.Remove(assets);
            await _context.SaveChangesAsync();

            return Ok(assets);
        }

        private bool AssetsExists(int id)
        {
            return _context.assets.Any(e => e.AssetId == id);
        }
    }
}