using System.ComponentModel.DataAnnotations;

public class EstadoPrestamoDto
{
    [Required]
    [Key]
    public string Estado { get; set; }
}
