using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTOS;
using PeliculasAPI.Entidades;

namespace PeliculasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActoresController : ControllerBase
    {
        private readonly ContextDb contextDb;
        private readonly IMapper mapper;

        public ActoresController(ContextDb contextDb, IMapper mapper)
        {
            this.contextDb = contextDb;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> GetAll()
        {
            var actores = await contextDb.Actores.ToListAsync();
            return mapper.Map<List<ActorDTO>>(actores);
        }

        [HttpGet("{id:int}", Name ="ActorId")]
        public async Task<ActionResult<ActorDTO>> GetById(int id)
        {
            if (string.IsNullOrEmpty(id.ToString())) { return NotFound(); }

            var existe = await contextDb.Actores.FirstOrDefaultAsync(x => x.Id == id);
            if (existe == null) {  return NotFound(); }

            return mapper.Map<ActorDTO>(existe);
        }

        [HttpPost]
        public async Task<ActionResult> Post(ActorCreacionDTO actor)
        {
            if(actor == null) { return NotFound(); }

            var Actor = mapper.Map<Actor>(actor);
            contextDb.Actores.Add(Actor);
            await contextDb.SaveChangesAsync();

            var entidad = mapper.Map<ActorDTO>(Actor);
            //esto es para devolver la entidad creada
            return new CreatedAtRouteResult("ActorId", new { id = entidad.Id }, entidad);
        }
    }
}
