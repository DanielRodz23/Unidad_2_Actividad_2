namespace Unidad_2_Actividad_2.Models.ViewModels
{
	public class RazaDetallesViewModel
	{
		public int Id { get; set; }
		public string Nombre { get; set; } = null!;
		public string Descripcion { get; set; } = null!;
		public string Pais { get; set; } = null!;
		public string OtrosNombres { get; set; } = null!;
		public float PesoMax { get; set; }
		public float PesoMin { get; set; }
		public float AlturaMax { get; set; }
		public float AlturaMin { get; set; }
		public uint EsperanzaVida { get; set; }
		//Estadisticas
		public uint NivelEnergia { get; set; }

		public uint FacilidadEntrenamiento { get; set; }

		public uint EjercicioObligatorio { get; set; }

		public uint AmistadDesconocidos { get; set; }

		public uint AmistadPerros { get; set; }

		public uint NecesidadCepillado { get; set; }
		//CaracteristicasFisicas
		public string Patas { get; set; } = null!;

		public string Cola { get; set; } = null!;

		public string Hocico { get; set; } = null!;

		public string Pelo { get; set; } = null!;

		public string Color { get; set; } = null!;
		//Razas aleatorias
		public IEnumerable<RazaModel> Razas { get; set; } = null!;
	}
}
