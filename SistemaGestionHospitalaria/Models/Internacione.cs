using System;
using System.Collections.Generic;

namespace SistemaGestionHospitalaria.Models;

public partial class Internacione
{
    public int IdInternacion { get; set; }

    public int IdPaciente { get; set; }

    public int IdHabitacion { get; set; }

    public DateOnly FechaIngreso { get; set; }

    public DateOnly? FechaSalida { get; set; }

    public virtual Habitacione IdHabitacionNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
