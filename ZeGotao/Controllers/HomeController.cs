using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ZeGotao.Data;
using ZeGotao.Models;

public class HomeController : Controller
{
    private readonly ZeGotaoContext _db;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ZeGotaoContext db, ILogger<HomeController> logger)
    {
        _db = db;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Entrar()
    {
        return View(new Usuario());
    }
    public IActionResult Cadastrar()
    {
        return View(new Usuario());
    }

    [HttpPost]
    public async Task<IActionResult> Entrar(Usuario usuario)
    {
        if (!ModelState.IsValid)
            return View(usuario);

        var user = await _db.Usuario
            .FirstOrDefaultAsync(x => x.Email == usuario.Email && x.Senha == usuario.Senha);

        if (user == null)
        {
            ViewData["ErroLogin"] = "E-mail ou senha inválidos!";
            return View(usuario);
        }

        HttpContext.Session.SetInt32("IdUsuario", user.IdUsuario);
        HttpContext.Session.SetString("NomeUsuario", user.Nome);

        return RedirectToAction("PosLogin");
    }



    [HttpPost]
    public async Task<IActionResult> Cadastrar(Usuario usuario)
    {
        if (!ModelState.IsValid)
            return View(usuario);

        bool existe = await _db.Usuario.AnyAsync(x => x.Email == usuario.Email);

        if (existe)
        {
            ViewData["ErroCadastro"] = "E-mail já cadastrado!";
            return View(usuario);
        }

        usuario.Ativo = true;
        usuario.TipoUsuarioId = 1;

        _db.Usuario.Add(usuario);
        await _db.SaveChangesAsync();

        return RedirectToAction("Entrar");
    }

    public IActionResult PosLogin()
    {
        int? id = HttpContext.Session.GetInt32("IdUsuario");

        if (id == null)
            return RedirectToAction("Entrar");

        ViewBag.Nome = HttpContext.Session.GetString("NomeUsuario");

        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Entrar");
    }
}