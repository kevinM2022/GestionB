using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SancionDto
{
    [Key]
    public int SancionId { get; set; }

    [Required(ErrorMessage = "El campo Concepto es obligatorio.")]
    public string Concepto { get; set; }

    [Required(ErrorMessage = "El campo Monto es obligatorio.")]
    public decimal Monto { get; set; }

    // Propiedades relacionadas con Prestamo
    [ForeignKey("Prestamo")]
    [Required(ErrorMessage = "El campo PrestamoId es obligatorio.")]
    public int PrestamoId { get; set; }

    [ForeignKey("Libro")]

    [Required(ErrorMessage = "El campo LibroId es obligatorio.")]
    public int LibroId { get; set; }

    // Otras propiedades que puedan necesitarse
}
