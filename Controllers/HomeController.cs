using Microsoft.AspNetCore.Mvc;

namespace TP06Elecciones_Gayoso_TorreWalsh.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult VerDetallePartido(int idPartido){
        return View("DetallePartido");
    }
    public IActionResult VerDetalleCandidato(int idCandidato){
        return View("DetalleCandidato");
    }
    public IActionResult AgregarCandidato(int idPartido){
        return View("CandidatoFormulario");
    }
    [HttpPost] public IActionResult GuardarCandidato(Candidato Candidato.can){
        return View("Detallepartido");
    }
    public IActionResult EliminarCandidato(int idCandidato, int idPartido){
        /*eliminar candidato
        Escape en partido candidatos - candidato seleccionado
        */
        return View("DetallePartido");
    }
    public IActionResult Elecciones(){
        return View("EleccionesInfo");
    }
    public IActionResult Creditos(){
        return View();
    }
}
