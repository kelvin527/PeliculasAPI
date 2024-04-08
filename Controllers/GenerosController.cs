using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTOS;
using PeliculasAPI.Entidades;
using PeliculasAPI.Helperd;

namespace PeliculasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
       private readonly ContextDb contextDb;
        private readonly IMapper mapper;
        public GenerosController(ContextDb contextDb, IMapper mapper)
        {
            this.contextDb = contextDb;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GenerosDTO>>> Get()
        {
            var lista = await contextDb.Generos.ToListAsync();
            return mapper.Map<List<GenerosDTO>>(lista);
        }

        [HttpGet("{id:int}",Name ="GetByIdGenero")]
        public async Task<ActionResult<GenerosDTO>> GeneroById(int id)
        {
            if (string.IsNullOrEmpty(id.ToString())) { return BadRequest("No se permiten valores vacio"); }

            var genero = await contextDb.Generos.FirstOrDefaultAsync(x => x.Id == id);

            if (genero != null)
            {
                return mapper.Map<GenerosDTO>(genero);
            }

            return BadRequest("No se encontro el elemneto");
        }

        [HttpPost(Name ="PostGenero")]
        public async Task<ActionResult> Post([FromBody] GeneroCreacionDTO dTO)
        {
            if (ModelState.IsValid)
            {
                var genero = mapper.Map<Genero>(dTO);
                await contextDb.Generos.AddAsync(genero);
                await contextDb.SaveChangesAsync();
            }

            return BadRequest("no se guarado");
        }
    }
}
