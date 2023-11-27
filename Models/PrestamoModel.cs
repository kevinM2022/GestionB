using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Prestamo
{

    public int PrestamoId { get; set; }


    public DateTime FechaPrestamo { get; set; }


    public DateTime FechaDevolucionEsperada { get; set; }


    public EstadoPrestamo Estado { get; set; }


    public int LibroId { get; set; }
    public virtual Libro Libro { get; set; }

    public virtual Sancion Sancion { get; set; }



    public int UsuarioId { get; set; }
    public virtual Usuario Usuario { get; set; }


    public int DespachadorId { get; set; }
    public Usuario Despachador { get; set; }

}