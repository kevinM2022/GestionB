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
    public class UsuarioController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public UsuarioController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Usuario
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.UsuarioDto.ToListAsync());
        }

        // GET: Usuario/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioDto = await _context.UsuarioDto
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuarioDto == null)
            {
                return NotFound();
            }

            return Ok(usuarioDto);
        }

        // GET: Usuario/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return Ok();
        }

        // POST: Usuario/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody, Bind("UsuarioId,Nombre,Apellido,Direccion,CorreoElectronico,NumeroTelefono,Rol,UsuarioGestion,PasswordGestion,PrestamosIds,PrestamosDespachadosIds")] UsuarioDto usuarioDto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioDto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(usuarioDto);
        }

        // GET: Usuario/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioDto = await _context.UsuarioDto.FindAsync(id);
            if (usuarioDto == null)
            {
                return NotFound();
            }
            return Ok(usuarioDto);
        }

        // POST: Usuario/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody, Bind("UsuarioId,Nombre,Apellido,Direccion,CorreoElectronico,NumeroTelefono,Rol,UsuarioGestion,PasswordGestion,PrestamosIds,PrestamosDespachadosIds")] UsuarioDto usuarioDto)
        {
            if (id != usuarioDto.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioDto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioDtoExists(usuarioDto.UsuarioId))
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
            return Ok(usuarioDto);
        }

        // GET: Usuario/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioDto = await _context.UsuarioDto
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuarioDto == null)
            {
                return NotFound();
            }

            return Ok(usuarioDto);
        }

        // POST: Usuario/Delete/5
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioDto = await _context.UsuarioDto.FindAsync(id);
            if (usuarioDto != null)
            {
                _context.UsuarioDto.Remove(usuarioDto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioDtoExists(int id)
        {
            return _context.UsuarioDto.Any(e => e.UsuarioId == id);
        }
    }
}
