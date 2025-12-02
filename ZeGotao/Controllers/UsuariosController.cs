using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZeGotao.Core.Data;
using ZeGotao.Models;

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
        // LOGIN
        // ============================================================
        [HttpGet]
        public IActionResult Entrar()
        {
            return View("Entrar");
        }

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

            HttpContext.Session.SetInt32("IdUsuario", user.IdUsuario);
            HttpContext.Session.SetString("NomeUsuario", user.Nome);
            HttpContext.Session.SetString("EmailUsuario", user.Email);
            HttpContext.Session.SetInt32("TipoUsuarioId", user.TipoUsuarioId);

            return RedirectToAction("PosLogin");
        }

        // ============================================================
        // PÓS LOGIN
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
        // CADASTRAR
        // ============================================================
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (!ModelState.IsValid)
                return View("Create", usuario);

            _context.Add(usuario);
            await _context.SaveChangesAsync();

            // 🔥 Esta linha ativa o modal
            TempData["CadastroOk"] = true;

            // 🔥 Mantém o usuário na tela de Create para abrir o modal
            return RedirectToAction("Create");
        }

        // ============================================================
        // LISTAR
        // ============================================================
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuario.ToListAsync());
        }

        // ============================================================
        // EDITAR
        // ============================================================
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var user = await _context.Usuario.FindAsync(id);

            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
                return NotFound();

            if (!ModelState.IsValid)
                return View(usuario);

            _context.Update(usuario);
            await _context.SaveChangesAsync();

            HttpContext.Session.SetString("NomeUsuario", usuario.Nome);
            HttpContext.Session.SetString("EmailUsuario", usuario.Email);

            TempData["MsgSucesso"] = "Dados atualizados com sucesso!";
            return RedirectToAction("PosLogin");
        }

        // ============================================================
        // LOGOUT
        // ============================================================
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Entrar");
        }
    }
}
