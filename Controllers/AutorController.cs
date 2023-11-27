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
    public class AutorController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public AutorController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: AutorDtoes
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.AutorDto.ToListAsync());
        }

        // GET: AutorDtoes/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorDto = await _context.AutorDto
                .FirstOrDefaultAsync(m => m.AutorId == id);
            if (autorDto == null)
            {
                return NotFound();
            }

            return Ok(autorDto);
        }

        // GET: AutorDtoes/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return Ok();
        }

        // POST: AutorDtoes/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody, Bind("AutorId,Nombre,Apellido,Nacionalidad")] AutorDto autorDto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autorDto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(autorDto);
        }

        // GET: AutorDtoes/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorDto = await _context.AutorDto.FindAsync(id);
            if (autorDto == null)
            {
                return NotFound();
            }
            return Ok(autorDto);
        }

        // POST: AutorDtoes/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody, Bind("AutorId,Nombre,Apellido,Nacionalidad")] AutorDto autorDto)
        {
            if (id != autorDto.AutorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autorDto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorDtoExists(autorDto.AutorId))
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
            return Ok(autorDto);
        }

        // GET: AutorDtoes/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorDto = await _context.AutorDto
                .FirstOrDefaultAsync(m => m.AutorId == id);
            if (autorDto == null)
            {
                return NotFound();
            }

            return Ok(autorDto);
        }

        // POST: AutorDtoes/Delete/5
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autorDto = await _context.AutorDto.FindAsync(id);
            if (autorDto != null)
            {
                _context.AutorDto.Remove(autorDto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutorDtoExists(int id)
        {
            return _context.AutorDto.Any(e => e.AutorId == id);
        }
    }
}
