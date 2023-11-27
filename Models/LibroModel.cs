using System.ComponentModel.DataAnnotations;

public class Libro
{

    public int LibroId { get; set; }


    public string Titulo { get; set; }

    public int AnioPublicacion { get; set; }


    public string Genero { get; set; }

    public int CopiasDisponibles { get; set; }

    public virtual ICollection<Autor> Autores { get; set; }
    public virtual ICollection<Prestamo> Prestamos { get; set; }
    public virtual ICollection<Categoria> Categorias { get; set; }
}