using System;
using System.Collections.Generic;

namespace SistemaGestionHospitalaria.Models;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateOnly? FechaNacimiento { get; set; }

    public string? Sexo { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<HistoriasClinica> HistoriasClinicas { get; set; } = new List<HistoriasClinica>();

    public virtual ICollection<Internacione> Internaciones { get; set; } = new List<Internacione>();

    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();
}
