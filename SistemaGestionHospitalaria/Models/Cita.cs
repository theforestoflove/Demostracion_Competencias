using System;
using System.Collections.Generic;

namespace SistemaGestionHospitalaria.Models;

public partial class Cita
{
    public int IdCita { get; set; }

    public int IdPaciente { get; set; }

    public int IdMedico { get; set; }

    public int IdConsultorio { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public string? Estado { get; set; }

    public virtual Consultorio IdConsultorioNavigation { get; set; } = null!;

    public virtual Medico IdMedicoNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
