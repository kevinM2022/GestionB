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
    public class CategoriaController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public CategoriaController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Categoria
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.CategoriaDto.ToListAsync());
        }

        // GET: Categoria/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaDto = await _context.CategoriaDto
                .FirstOrDefaultAsync(m => m.CategoriaId == id);
            if (categoriaDto == null)
            {
                return NotFound();
            }

            return Ok(categoriaDto);
        }

        // GET: Categoria/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return Ok();
        }

        // POST: Categoria/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody, Bind("CategoriaId,NombreCategoria")] CategoriaDto categoriaDto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaDto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(categoriaDto);
        }

        // GET: Categoria/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaDto = await _context.CategoriaDto.FindAsync(id);
            if (categoriaDto == null)
            {
                return NotFound();
            }
            return Ok(categoriaDto);
        }

        // POST: Categoria/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody, Bind("CategoriaId,NombreCategoria")] CategoriaDto categoriaDto)
        {
            if (id != categoriaDto.CategoriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaDto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaDtoExists(categoriaDto.CategoriaId))
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
            return Ok(categoriaDto);
        }

        // GET: Categoria/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaDto = await _context.CategoriaDto
                .FirstOrDefaultAsync(m => m.CategoriaId == id);
            if (categoriaDto == null)
            {
                return NotFound();
            }

            return Ok(categoriaDto);
        }

        // POST: Categoria/Delete/5
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaDto = await _context.CategoriaDto.FindAsync(id);
            if (categoriaDto != null)
            {
                _context.CategoriaDto.Remove(categoriaDto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaDtoExists(int id)
        {
            return _context.CategoriaDto.Any(e => e.CategoriaId == id);
        }
    }
}
