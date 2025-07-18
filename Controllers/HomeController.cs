using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06.Models;

namespace TP06.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

     public IActionResult Index()
    {
        ViewBag.iniciarPrograma="Bienvenidos";
        return View("Index");
    }

    public IActionResult Login(string email, string contraseña){
        int id=BD.Login(email,contraseña);

        if(id!=-1){
            ViewBag.UsuarioLogueado=BD.GetUsuario(id);
             id = BD.Login(email,contraseña);
             string idUser = id.ToString();
             ViewBag.Usuario = BD.GetUsuario(id);
             HttpContext.Session.SetString("IDUsuario",idUser);

        }
        else{
            ViewBag.Error="ERROR";
        }

        return View("PaginaPrincipal");

    }
   
    public IActionResult DatoUsuario()
    {
        string idUsuario= HttpContext.Session.GetString("IDUsuario");
        int idUser=int.Parse(idUsuario);
        Usuario usuario =BD.GetUsuario(idUser);
        ViewBag.InfoUsuario=usuario;
        return View("DatoUsuario");
    }
    public IActionResult DatoFamiliar()
    {
        string idUsuario= HttpContext.Session.GetString("IDUsuario");
        int idUser=int.Parse(idUsuario);
        List<DatoFamiliar>lDatoFamilia=BD.GetDatoFamiliar(idUser);
        ViewBag.InfoFamilia=lDatoFamilia;
        return View("DatoFamiliar");
    }

    public IActionResult DatoInteres()
    {
        string idUsuario= HttpContext.Session.GetString("IDUsuario");
        int idUser=int.Parse(idUsuario);
        List<DatoInteres>lDatoInteres=BD.GetDatoInteres(idUser);
        ViewBag.InfoInteres=lDatoInteres;
        return View("DatoInteres");
    }
    


}
