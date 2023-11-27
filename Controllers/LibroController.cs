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
    public class LibroController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public LibroController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Libro
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.LibroDto.ToListAsync());
        }

        // GET: Libro/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libroDto = await _context.LibroDto
                .FirstOrDefaultAsync(m => m.LibroId == id);
            if (libroDto == null)
            {
                return NotFound();
            }

            return Ok(libroDto);
        }

        // GET: Libro/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return Ok();
        }

        // POST: Libro/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody, Bind("LibroId,Titulo,AnioPublicacion,Genero,CopiasDisponibles,AutoresIds,CategoriaIds")] LibroDto libroDto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libroDto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(libroDto);
        }

        // GET: Libro/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libroDto = await _context.LibroDto.FindAsync(id);
            if (libroDto == null)
            {
                return NotFound();
            }
            return Ok(libroDto);
        }

        // POST: Libro/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody, Bind("LibroId,Titulo,AnioPublicacion,Genero,CopiasDisponibles,AutoresIds,CategoriaIds")] LibroDto libroDto)
        {
            if (id != libroDto.LibroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libroDto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroDtoExists(libroDto.LibroId))
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
            return Ok(libroDto);
        }

        // GET: Libro/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libroDto = await _context.LibroDto
                .FirstOrDefaultAsync(m => m.LibroId == id);
            if (libroDto == null)
            {
                return NotFound();
            }

            return Ok(libroDto);
        }

        // POST: Libro/Delete/5
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libroDto = await _context.LibroDto.FindAsync(id);
            if (libroDto != null)
            {
                _context.LibroDto.Remove(libroDto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroDtoExists(int id)
        {
            return _context.LibroDto.Any(e => e.LibroId == id);
        }
    }
}
