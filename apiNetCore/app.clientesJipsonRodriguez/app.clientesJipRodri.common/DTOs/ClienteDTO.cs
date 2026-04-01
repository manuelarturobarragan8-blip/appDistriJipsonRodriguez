using System.ComponentModel.DataAnnotations;

namespace app.clientesJipRodri.common.DTOs
{
    public class ClienteDTO
    {

        public int Id { get; set; }
        public bool Estado { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "El campo Email es obligatorio")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "El campo CedulaIdentidad es obligatorio")]
        public string? CedulaIdentidad { get; set; }

        [Required(ErrorMessage = "El campo FechaNacimiento es obligatorio")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public string? Telefono { get; set; }

    }
}
