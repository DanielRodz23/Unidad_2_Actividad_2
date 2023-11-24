using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unidad_2_Actividad_2.Models.Entities;
using Unidad_2_Actividad_2.Models.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Unidad_2_Actividad_2.Controllers
{
    public class HomeController : Controller
    {
        PerrosContext context = new PerrosContext();
        [Route("~/")]
		[Route("~/{id}")]
		public IActionResult Index(string id)
        {
            IndexViewModel indexViewModel = new();
            IEnumerable<RazaModel> datos;
            if (id == null)
            {
                datos = context.Razas.Select(x => new RazaModel() { Id = (int)x.Id, Nombre = x.Nombre }).OrderBy(x => x.Nombre);
            }
            else
            {
                id = id.ToLower();
                datos = context.Razas.Where(x => x.Nombre.StartsWith(id.ToUpper())).Select(x => new RazaModel() { Id = (int)x.Id, Nombre = x.Nombre }).OrderBy(x => x.Nombre);
            }

            indexViewModel.LetraNombres= context.Razas.Select(x => x.Nombre.Substring(0, 1)).Distinct().OrderBy(x => x);
            indexViewModel.ListaRazas = datos;
            return View(indexViewModel);
        }
        [Route("~/pais")]
        public IActionResult Pais()
        {
            var lista = context.Paises.Include(x=>x.Razas).OrderBy(x => x.Nombre).Select(x=>new RazaPaisViewModel()
            {
                Nombre=x.Nombre??"",
                Razas=x.Razas
                .Select(y=> 
                new RazaModel 
                { 
                    Id = (int)y.Id, 
                    Nombre=y.Nombre
                })
                
            });
            
            return View(lista);
        }
        [Route("~/raza/{id}")]
        public IActionResult Raza(string id)
        {
            id = id.Replace("-", " ");
            RazaDetallesViewModel vm = new RazaDetallesViewModel();
            var datos = context.Razas
                .Where(x=>x.Nombre == id)
                .Select(x=> new RazaDetallesViewModel()
                {
                    Descripcion=x.Descripcion,
                    Nombre = x.Nombre,
                    Id=(int)x.Id,
                    OtrosNombres=x.OtrosNombres??"",
                    Pais=x.IdPaisNavigation.Nombre??"",
                    PesoMin=x.PesoMin,
                    PesoMax=x.PesoMax,
                    AlturaMin=x.AlturaMin,
                    AlturaMax=x.AlturaMax,
                    EsperanzaVida=x.EsperanzaVida,
                    NivelEnergia=(x.Estadisticasraza??new Estadisticasraza()).NivelEnergia,
                    FacilidadEntrenamiento=(x.Estadisticasraza??new Estadisticasraza()).FacilidadEntrenamiento,
                    EjercicioObligatorio= (x.Estadisticasraza ?? new Estadisticasraza()).EjercicioObligatorio,
                    AmistadDesconocidos= (x.Estadisticasraza ?? new Estadisticasraza()).AmistadDesconocidos,
                    AmistadPerros= (x.Estadisticasraza ?? new Estadisticasraza()).AmistadPerros,
                    NecesidadCepillado= (x.Estadisticasraza ?? new Estadisticasraza()).NecesidadCepillado,
                    Patas=(x.Caracteristicasfisicas?? new Caracteristicasfisicas()).Patas??"",
                    Cola= (x.Caracteristicasfisicas ?? new Caracteristicasfisicas()).Cola??"",
                    Hocico= (x.Caracteristicasfisicas ?? new Caracteristicasfisicas()).Hocico ?? "",
                    Pelo= (x.Caracteristicasfisicas ?? new Caracteristicasfisicas()).Pelo?? "",
                    Color= (x.Caracteristicasfisicas ?? new Caracteristicasfisicas()).Color?? ""
                }).FirstOrDefault();
            if (datos==null)
            {
                return RedirectToAction("Index");
            }
            vm = datos;
            var razasAleatorias = context.Razas
                .OrderBy(x => EF.Functions.Random())
                .Select(x=> new RazaModel()
                {
                    Id=(int)x.Id,
                    Nombre=x.Nombre
                })
                .Take(4);
            vm.Razas = razasAleatorias;
            return View(vm);
        }
    }
}
