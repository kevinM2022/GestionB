using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Sancion
{

    public int SancionId { get; set; }


    public string Concepto { get; set; }

    public decimal Monto { get; set; }


    public int PrestamoId { get; set; }
    public virtual Prestamo Prestamo { get; set; }
}