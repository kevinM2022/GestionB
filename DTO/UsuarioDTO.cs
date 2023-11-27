using System.ComponentModel.DataAnnotations;

public class UsuarioDto
{
    [Key]
    public int UsuarioId { get; set; }

    [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
    public string Apellido { get; set; }

    public string Direccion { get; set; }

    [Required(ErrorMessage = "El campo Correo Electrónico es obligatorio.")]
    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
    public string CorreoElectronico { get; set; }

    [Required(ErrorMessage = "El campo Número de Teléfono es obligatorio.")]
    [Phone(ErrorMessage = "El formato del número de teléfono no es válido.")]
    public string NumeroTelefono { get; set; }

    [Required(ErrorMessage = "El campo Rol es obligatorio.")]
    public string Rol { get; set; }

    [Required(ErrorMessage = "El campo Usuario de Gestión es obligatorio.")]
    public string UsuarioGestion { get; set; }

    [Required(ErrorMessage = "El campo Contraseña de Gestión es obligatorio.")]
    public string PasswordGestion { get; set; }

    // Puedes agregar propiedades adicionales según tus necesidades

    
    public List<int> PrestamosIds { get; set; }

    public List<int> PrestamosDespachadosIds { get; set; }
}
