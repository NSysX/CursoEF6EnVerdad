using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peliculas.API.Contextos;
using Peliculas.API.Entities;

namespace Peliculas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly PeliculasDbContext _dbContext;

        public GeneroController(PeliculasDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Genero>> Listar()
        {
            var entities = await this._dbContext.Genero
                                     .OrderBy(x => x.Nombre)
                                     .ToListAsync();
            return entities;
        }

        [HttpGet("Primer")]
        public async Task<Genero> Get()
        {
            return await this._dbContext.Genero.FirstOrDefaultAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var entity = await this._dbContext.Genero.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null) return NotFound();
            return Ok(entity);
        }
        
        [HttpGet("BuscarXLetra")]
        public async Task<ActionResult<Genero>> GetXParam()
        {
            var entity = await this._dbContext.Genero
                         .FirstOrDefaultAsync(x => x.Nombre.StartsWith("A"));
            
            if (entity is null) return NotFound();

            return entity;
        }

        [HttpGet("filtrar")]
        public async Task<ActionResult> GeneroXLetraC(string filtro1, string filtro2)
        {
            return Ok(await this._dbContext.Genero
                                           .Where(x => x.Nombre.StartsWith(filtro1) || x.Nombre.StartsWith(filtro2))
                                           .ToListAsync());
        }
        
        [HttpGet("filtrarContains")]
        public async Task<ActionResult> Filtrar(string nombre)
        {
            return Ok(await this._dbContext.Genero.Where(x => x.Nombre.Contains(nombre))
                                                  .OrderByDescending(r => r.Nombre)
                                                  .ToListAsync());
        }
    }
}
