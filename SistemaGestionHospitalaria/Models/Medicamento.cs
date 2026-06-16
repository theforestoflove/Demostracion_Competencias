using System;
using System.Collections.Generic;

namespace SistemaGestionHospitalaria.Models;

public partial class Medicamento
{
    public int IdMedicamento { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();
}
