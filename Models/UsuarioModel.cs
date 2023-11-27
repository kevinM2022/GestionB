using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Usuario
{

    public int UsuarioId { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public string Direccion { get; set; }


    public string CorreoElectronico { get; set; }


    public string NumeroTelefono { get; set; }


    public string Rol { get; set; } // Puede ser "Usuario" o "Despachador"


    public string UsuarioGestion { get; set; } // Nombre de usuario para la gestión bibliotecaria

    public string PasswordGestion { get; set; } // Contraseña para la gestión bibliotecaria

    public virtual ICollection<Prestamo> Prestamos { get; set; }


    public List<Prestamo> PrestamosDespachados { get; set; }

}

