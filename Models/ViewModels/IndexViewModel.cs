namespace Unidad_2_Actividad_2.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<RazaModel> ListaRazas { get; set; }=new List<RazaModel>();
        public IEnumerable<string> LetraNombres { get; set; } = new List<string>();
    }
    public class RazaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
