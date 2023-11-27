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
    public class EstadoPrestamoController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public EstadoPrestamoController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: EstadoPrestamo
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.EstadoPrestamoDto.ToListAsync());
        }

        // GET: EstadoPrestamo/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoPrestamoDto = await _context.EstadoPrestamoDto
                .FirstOrDefaultAsync(m => m.Estado == id);
            if (estadoPrestamoDto == null)
            {
                return NotFound();
            }

            return Ok(estadoPrestamoDto);
        }

        // GET: EstadoPrestamo/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return Ok();
        }

        // POST: EstadoPrestamo/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody, Bind("Estado")] EstadoPrestamoDto estadoPrestamoDto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoPrestamoDto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(estadoPrestamoDto);
        }

        // GET: EstadoPrestamo/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoPrestamoDto = await _context.EstadoPrestamoDto.FindAsync(id);
            if (estadoPrestamoDto == null)
            {
                return NotFound();
            }
            return Ok(estadoPrestamoDto);
        }

        // POST: EstadoPrestamo/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [FromBody, Bind("Estado")] EstadoPrestamoDto estadoPrestamoDto)
        {
            if (id != estadoPrestamoDto.Estado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoPrestamoDto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoPrestamoDtoExists(estadoPrestamoDto.Estado))
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
            return Ok(estadoPrestamoDto);
        }

        // GET: EstadoPrestamo/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoPrestamoDto = await _context.EstadoPrestamoDto
                .FirstOrDefaultAsync(m => m.Estado == id);
            if (estadoPrestamoDto == null)
            {
                return NotFound();
            }

            return Ok(estadoPrestamoDto);
        }

        // POST: EstadoPrestamo/Delete/5
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var estadoPrestamoDto = await _context.EstadoPrestamoDto.FindAsync(id);
            if (estadoPrestamoDto != null)
            {
                _context.EstadoPrestamoDto.Remove(estadoPrestamoDto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoPrestamoDtoExists(string id)
        {
            return _context.EstadoPrestamoDto.Any(e => e.Estado == id);
        }
    }
}
