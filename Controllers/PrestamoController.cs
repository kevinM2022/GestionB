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
    public class PrestamoController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public PrestamoController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Prestamo
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.PrestamoDto.ToListAsync());
        }

        // GET: Prestamo/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamoDto = await _context.PrestamoDto
                .FirstOrDefaultAsync(m => m.PrestamoId == id);
            if (prestamoDto == null)
            {
                return NotFound();
            }

            return Ok(prestamoDto);
        }

        // GET: Prestamo/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return Ok();
        }

        // POST: Prestamo/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody, Bind("PrestamoId,FechaPrestamo,FechaDevolucionEsperada,Estado,LibroId,TituloLibro,UsuarioId,NombreUsuario,DespachadorId,NombreDespachador,SancionId,ConceptoSancion,MontoSancion")] PrestamoDto prestamoDto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestamoDto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(prestamoDto);
        }

        // GET: Prestamo/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamoDto = await _context.PrestamoDto.FindAsync(id);
            if (prestamoDto == null)
            {
                return NotFound();
            }
            return Ok(prestamoDto);
        }

        // POST: Prestamo/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody, Bind("PrestamoId,FechaPrestamo,FechaDevolucionEsperada,Estado,LibroId,TituloLibro,UsuarioId,NombreUsuario,DespachadorId,NombreDespachador,SancionId,ConceptoSancion,MontoSancion")] PrestamoDto prestamoDto)
        {
            if (id != prestamoDto.PrestamoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestamoDto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamoDtoExists(prestamoDto.PrestamoId))
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
            return Ok(prestamoDto);
        }

        // GET: Prestamo/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamoDto = await _context.PrestamoDto
                .FirstOrDefaultAsync(m => m.PrestamoId == id);
            if (prestamoDto == null)
            {
                return NotFound();
            }

            return Ok(prestamoDto);
        }

        // POST: Prestamo/Delete/5
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestamoDto = await _context.PrestamoDto.FindAsync(id);
            if (prestamoDto != null)
            {
                _context.PrestamoDto.Remove(prestamoDto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestamoDtoExists(int id)
        {
            return _context.PrestamoDto.Any(e => e.PrestamoId == id);
        }
    }
}
