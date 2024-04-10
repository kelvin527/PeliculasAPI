namespace PeliculasAPI.DTOS
{
    public class ActorCreacionDTO
    {
        public string Nombre { get; set; }
        public IFormFile Foto { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}

