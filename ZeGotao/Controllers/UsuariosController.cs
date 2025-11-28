using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZeGotao.Data;
using ZeGotao.Models;
using Microsoft.AspNetCore.Http;

namespace ZeGotao.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ZeGotaoContext _context;

        public UsuariosController(ZeGotaoContext context)
        {
            _context = context;
        }

        // ============================================================
        // GET: Tela de Login
        // ============================================================
        [HttpGet]
        public IActionResult Entrar()
        {
            return View("Entrar"); // usa a view correta do seu projeto
        }

        // ============================================================
        // POST: Login
        // ============================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EntrarPost(string email, string senha)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                ViewData["Erro"] = "Preencha email e senha.";
                return View("Entrar");
            }

            var user = await _context.Usuario
                .FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);

            if (user == null)
            {
                ViewData["Erro"] = "E-mail ou senha inválidos!";
                return View("Entrar");
            }

            // SESSÃO (funciona apenas se app.UseSession() estiver configurado)
            HttpContext.Session.SetInt32("IdUsuario", user.IdUsuario);
            HttpContext.Session.SetString("NomeUsuario", user.Nome);

            return RedirectToAction("PosLogin");
        }

        // ============================================================
        // GET: Tela pós Login
        // ============================================================
        [HttpGet]
        public async Task<IActionResult> PosLogin()
        {
            var id = HttpContext.Session.GetInt32("IdUsuario");
            if (id == null)
                return RedirectToAction("Entrar");

            var user = await _context.Usuario.FindAsync(id.Value);
            if (user == null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Entrar");
            }

            return View("PosLogin", user);
        }

        // ============================================================
        // GET: Tela de Cadastro
        // ============================================================
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create"); // mantém o CSS da sua view original
        }

        // ============================================================
        // POST: Cadastro
        // ============================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", usuario);
            }

            _context.Add(usuario);
            await _context.SaveChangesAsync();

            TempData["MsgSucesso"] = "Cadastro realizado com sucesso!";
            return RedirectToAction("Entrar");
        }


        // ============================================================
        // GET: Listar Usuários
        // ============================================================
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuario.ToListAsync());
        }

        // ============================================================
        // Logout
        // ============================================================
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Entrar");
        }
    }
}