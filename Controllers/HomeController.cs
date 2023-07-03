﻿using Microsoft.AspNetCore.Mvc;

namespace TP06Elecciones_Gayoso_TorreWalsh.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.detallePartido = BD.ListarPartidos();
        return View();
    }
    public IActionResult VerDetallePartido(int idPartido){
        ViewBag.detallePartido = BD.VerInfoPartido(idPartido);
        ViewBag.detalleCandidato = BD.ListarCandidatos(idPartido);
        return View("DetallePartido");
    }
    public IActionResult VerDetalleCandidato(int idCandidato){
        ViewBag.detalleCandidato = BD.VerInfoCandidato(idCandidato);
        return View("DetalleCandidato");
    }
    public IActionResult AgregarCandidato(int idPartido){
        ViewBag.ListaIdPartidos = idPartido;
        return View("CandidatoFormulario");
    }
    [HttpPost] public IActionResult GuardarCandidato(Candidato candidato){
        BD.AgregarCandidato(candidato);
        return RedirectToAction("DetallePartido", new { idPartido = candidato.IdPartido});
    }
    public IActionResult EliminarCandidato(int idCandidato, int idPartido){
        /*eliminar candidato
        Escape en partido candidatos - candidato seleccionado
        */
        BD.EliminarCandidato(idCandidato);
        return RedirectToAction("DetallePartido", new { idPartido = idPartido});
    }
    public IActionResult Elecciones(){
        return View("EleccionesInfo");
    }
    public IActionResult Creditos(){
        return View();
    }
}