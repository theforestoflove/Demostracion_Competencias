using System;
using System.Collections.Generic;

namespace SistemaGestionHospitalaria.Models;

public partial class HistoriasClinica
{
    public int IdHistoria { get; set; }

    public int IdPaciente { get; set; }

    public string? Diagnostico { get; set; }

    public string? Tratamiento { get; set; }

    public DateOnly? Fecha { get; set; }

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
