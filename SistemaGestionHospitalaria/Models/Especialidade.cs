using System;
using System.Collections.Generic;

namespace SistemaGestionHospitalaria.Models;

public partial class Especialidade
{
    public int IdEspecialidad { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();
}
