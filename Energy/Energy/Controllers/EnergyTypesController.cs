using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Energy.Models;

namespace Energy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergyTypesController : ControllerBase
    {
        private readonly EnergyContext _context;

        public EnergyTypesController(EnergyContext context)
        {
            _context = context;
        }

        // GET: api/EnergyTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnergySupplied>>> GetEnergyTypes()
        {
            if (_context.EnergyTypes == null)
            {
                return NotFound();
            }
            var energyTypes = await _context.EnergyTypes.ToListAsync();

            List<EnergySupplied> energySupplied = new List<EnergySupplied>();

            foreach(string item in energyTypes.Select(x => x.Name).Distinct())
            {
                var item_energy = energyTypes.Where(x => x.Name == item).OrderByDescending(x => x.CreatedDateTime).FirstOrDefault();
                EnergySupplied energy = new EnergySupplied()
                {
                    label = item,
                    value = (float)item_energy.EnergyConsumed
                };
                energySupplied.Add(energy);
            }
            return energySupplied;
        }

        // GET: api/EnergyTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnergyType>> GetEnergyType(int id)
        {
          if (_context.EnergyTypes == null)
          {
              return NotFound();
          }
            var energyType = await _context.EnergyTypes.FindAsync(id);

            if (energyType == null)
            {
                return NotFound();
            }

            return energyType;
        }

        // PUT: api/EnergyTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnergyType(int id, EnergyType energyType)
        {
            if (id != energyType.Id)
            {
                return BadRequest();
            }

            _context.Entry(energyType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnergyTypeExists(id))
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

        // POST: api/EnergyTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnergyType>> PostEnergyType(EnergyType energyType)
        {
          if (_context.EnergyTypes == null)
          {
              return Problem("Entity set 'EnergyContext.EnergyTypes'  is null.");
          }
            _context.EnergyTypes.Add(energyType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnergyType", new { id = energyType.Id }, energyType);
        }

        // DELETE: api/EnergyTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnergyType(int id)
        {
            if (_context.EnergyTypes == null)
            {
                return NotFound();
            }
            var energyType = await _context.EnergyTypes.FindAsync(id);
            if (energyType == null)
            {
                return NotFound();
            }

            _context.EnergyTypes.Remove(energyType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnergyTypeExists(int id)
        {
            return (_context.EnergyTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

    public class EnergySupplied
    {
        public string label { get; set; }
        public float value { get; set; }    
    }
}
