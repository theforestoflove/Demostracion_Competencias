using System;
using System.Collections.Generic;

namespace SistemaGestionHospitalaria.Models;

public partial class Habitacione
{
    public int IdHabitacion { get; set; }

    public string? Numero { get; set; }

    public string? Tipo { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Internacione> Internaciones { get; set; } = new List<Internacione>();
}
