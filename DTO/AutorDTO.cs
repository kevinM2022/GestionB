using System.ComponentModel.DataAnnotations;

public class AutorDto
{

    [Key]
    public int AutorId { get; set; }


    [Required]
    public string Nombre { get; set; }


    [Required]
    public string Apellido { get; set; }


    public string Nacionalidad { get; set; }
}
