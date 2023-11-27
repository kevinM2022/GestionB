using System.ComponentModel.DataAnnotations;

public class LibroDto
{
    [Key]
    public int LibroId { get; set; }

    [Required(ErrorMessage = "El campo Título es obligatorio.")]
    public string Titulo { get; set; }


    public int AnioPublicacion { get; set; }


    public string Genero { get; set; }

    public int CopiasDisponibles { get; set; }

    public ICollection<int> AutoresIds { get; set; }

    // agregar propiedades adicionales según tus necesidades

    public ICollection<int> CategoriaIds { get; set; }
}
