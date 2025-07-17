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

    public IActionResult Login(string email, string contraseña){
        int id=BD.Login(email,contraseña);

        if(id!=-1){
            ViewBag.UsuarioLogueado=BD.GetUsuario(id);
             id = BD.Login(email,contraseña);
             string idUser = id.ToString();
             HttpContext.Session.SetString("IDUsuario",idUser);
        }
        else{
            ViewBag.Error="ERROR";
        }

        return View("Index");

    }
    public IActionResult Index()
    {
        string idUsuario= HttpContext.Session.GetString("IDUsuario");
        int idUser=int.Parse(idUsuario);
        ViewBag.InfoUsuario=BD.GetUsuario(idUser);
        return View();
    }

    


}
