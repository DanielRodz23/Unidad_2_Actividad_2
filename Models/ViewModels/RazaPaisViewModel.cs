namespace Unidad_2_Actividad_2.Models.ViewModels
{
	public class RazaPaisViewModel
	{
		public string Nombre { get; set; } = null!;
		public IEnumerable<RazaModel> Razas { get; set; } = null!;
	}
}
