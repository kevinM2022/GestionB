using System.ComponentModel.DataAnnotations;

public class CategoriaDto
{
    [Key]
    public int CategoriaId { get; set; }

    public string NombreCategoria { get; set; }
}
