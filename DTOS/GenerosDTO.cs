using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTOS
{
    public class GenerosDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Nombre { get; set; }
    }
}
