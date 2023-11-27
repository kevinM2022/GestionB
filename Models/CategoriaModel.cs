using System.ComponentModel.DataAnnotations;

public class Categoria
{

    public int CategoriaId { get; set; }


    public string NombreCategoria { get; set; }

    public virtual ICollection<Libro> Libros { get; set; }
}