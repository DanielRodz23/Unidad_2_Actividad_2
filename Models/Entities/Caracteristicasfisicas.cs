using System;
using System.Collections.Generic;

namespace Unidad_2_Actividad_2.Models.Entities;

public partial class Caracteristicasfisicas
{
    public uint Id { get; set; }

    public string? Patas { get; set; }

    public string? Cola { get; set; }

    public string? Hocico { get; set; }

    public string? Pelo { get; set; }

    public string? Color { get; set; }

    public virtual Razas IdNavigation { get; set; } = null!;
}
