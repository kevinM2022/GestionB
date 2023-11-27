using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PrestamoDto
{
    [Key]
    public int PrestamoId { get; set; }
    public DateTime FechaPrestamo { get; set; } = DateTime.Now;
    public DateTime FechaDevolucionEsperada { get; set; }
    public EstadoPrestamo Estado { get; set; }

    // Propiedades relacionadas con Libro
    [ForeignKey("Libro")]
    public int LibroId { get; set; }
    public string TituloLibro { get; set; }

    // Propiedades relacionadas con Usuario
    [ForeignKey("Usuario")]
    public int UsuarioId { get; set; }
    public string NombreUsuario { get; set; }

    // Propiedades relacionadas con Despachador
    [ForeignKey("Despachador")]
    public int DespachadorId { get; set; }
    public string NombreDespachador { get; set; }

    // Propiedades relacionadas con Sancion
    [ForeignKey("Sancion")]
    public int SancionId { get; set; }
    public string ConceptoSancion { get; set; }
    public decimal MontoSancion { get; set; }
}

