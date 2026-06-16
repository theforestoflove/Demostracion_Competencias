using System;
using System.Collections.Generic;

namespace SistemaGestionHospitalaria.Models;

public partial class Consultorio
{
    public int IdConsultorio { get; set; }

    public string Numero { get; set; } = null!;

    public int? Piso { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
