using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GestionB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SancionController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public SancionController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Sancion
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.SancionDto.ToListAsync());
        }

        // GET: Sancion/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sancionDto = await _context.SancionDto
                .FirstOrDefaultAsync(m => m.SancionId == id);
            if (sancionDto == null)
            {
                return NotFound();
            }

            return Ok(sancionDto);
        }

        // GET: Sancion/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return Ok();
        }

        // POST: Sancion/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody, Bind("SancionId,Concepto,Monto,PrestamoId,LibroId")] SancionDto sancionDto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sancionDto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(sancionDto);
        }

        // GET: Sancion/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sancionDto = await _context.SancionDto.FindAsync(id);
            if (sancionDto == null)
            {
                return NotFound();
            }
            return Ok(sancionDto);
        }

        // POST: Sancion/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody, Bind("SancionId,Concepto,Monto,PrestamoId,LibroId")] SancionDto sancionDto)
        {
            if (id != sancionDto.SancionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sancionDto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SancionDtoExists(sancionDto.SancionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return Ok(sancionDto);
        }

        // GET: Sancion/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sancionDto = await _context.SancionDto
                .FirstOrDefaultAsync(m => m.SancionId == id);
            if (sancionDto == null)
            {
                return NotFound();
            }

            return Ok(sancionDto);
        }

        // POST: Sancion/Delete/5
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sancionDto = await _context.SancionDto.FindAsync(id);
            if (sancionDto != null)
            {
                _context.SancionDto.Remove(sancionDto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SancionDtoExists(int id)
        {
            return _context.SancionDto.Any(e => e.SancionId == id);
        }
    }
}
