using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Autor
{

    public int AutorId { get; set; }


    public string Nombre { get; set; }


    public string Apellido { get; set; }


    public string Nacionalidad { get; set; }

    // Relación con la entidad Libro
    public virtual ICollection<Libro> Libros { get; set; }
}