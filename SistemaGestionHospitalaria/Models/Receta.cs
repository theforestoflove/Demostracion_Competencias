using System;
using System.Collections.Generic;

namespace SistemaGestionHospitalaria.Models;

public partial class Receta
{
    public int IdReceta { get; set; }

    public int IdPaciente { get; set; }

    public int IdMedico { get; set; }

    public int IdMedicamento { get; set; }

    public string? Dosis { get; set; }

    public DateOnly? Fecha { get; set; }

    public virtual Medicamento IdMedicamentoNavigation { get; set; } = null!;

    public virtual Medico IdMedicoNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
