using Microsoft.AspNetCore.Mvc;
using WebApi_Libreria.DTOs;
using WebApi_Libreria.Services;

namespace WebApi_Libreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibrosController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var libros = await _libroService.GetAllLibrosAsync();
            return Ok(libros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var libro = await _libroService.GetLibroByIdAsync(id);
            if (libro == null)
                return NotFound();
            return Ok(libro);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CrearLibroDto crearLibroDto)
        {
            try
            {
                var libro = await _libroService.CreateLibroAsync(crearLibroDto);
                return CreatedAtAction(nameof(GetById), new { id = libro.Id }, libro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ActualizarLibroDto actualizarLibroDto)
        {
            try
            {
                await _libroService.UpdateLibroAsync(id, actualizarLibroDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _libroService.DeleteLibroAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
