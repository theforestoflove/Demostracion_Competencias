using System;
using System.Collections.Generic;

namespace SistemaGestionHospitalaria.Models;

public partial class Medico
{
    public int IdMedico { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public int? IdEspecialidad { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Especialidade? IdEspecialidadNavigation { get; set; }

    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();
}
