using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZeGotao.Data;     // ajuste namespace se diferente
using ZeGotao.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace ZeGotao.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ZeGotaoContext _context;

        public UsuariosController(ZeGotaoContext context)
        {
            _context = context;
        }

        // GET: Usuarios/Entrar
        [HttpGet]
        public IActionResult Entrar()
        {
            return View();
        }

        // POST: Usuarios/EntrarPost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EntrarPost(string email, string senha)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                ViewData["Erro"] = "Preencha email e senha.";
                return View("Entrar");
            }

            // Ajuste para o DbSet/Model do seu projeto: pode ser _context.Usuario ou _context.Usuarios
            var user = await _context.Usuario // OU _context.Usuarios conforme seu AppDbContext
                .FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);

            if (user == null)
            {
                ViewData["Erro"] = "E-mail ou senha inválidos!";
                return View("Entrar");
            }

            // Salva dados na sessão (precisa de app.UseSession())
            HttpContext.Session.SetInt32("IdUsuario", user.IdUsuario); // ajuste propriedade do Id se necessário
            HttpContext.Session.SetString("NomeUsuario", user.Nome);

            return RedirectToAction("PosLogin", "Usuarios");
        }

        // GET: Usuarios/PosLogin
        [HttpGet]
        public async Task<IActionResult> PosLogin()
        {
            var id = HttpContext.Session.GetInt32("IdUsuario");
            if (id == null)
                return RedirectToAction("Entrar");

            // buscar novamente para ter dados atualizados
            var user = await _context.Usuario.FindAsync(id.Value);
            if (user == null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Entrar");
            }

            return View(user);
        }

        // Opcional: Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Entrar");
        }
    }
}