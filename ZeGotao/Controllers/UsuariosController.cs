using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZeGotao.Core.Data;
using ZeGotao.Models;
using ZeGotao.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

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
        // LOGIN (GET)
        // ============================================================
        [HttpGet]
        public IActionResult Entrar()
        {
            return View("Entrar");
        }

        // ============================================================
        // LOGIN (POST)
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

            // ====== AUTENTICAÇÃO COOKIE (NÃO USA MAIS SESSION) ======
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Nome),
                new Claim(ClaimTypes.NameIdentifier, user.IdUsuario.ToString()),
                new Claim("Email", user.Email)
            };

            var identity = new ClaimsIdentity(claims, "Cookies");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                "Cookies",
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,   // mantém login ao fechar navegador
                    ExpiresUtc = DateTime.UtcNow.AddHours(12)
                });

            // ============================================================
            return RedirectToAction("PosLogin");
        }

        // ============================================================
        // PÓS LOGIN
        // ============================================================
        [HttpGet]
        public async Task<IActionResult> PosLogin()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
                return RedirectToAction("Entrar");

            var user = await _context.Usuario.FindAsync(int.Parse(userId));

            if (user == null)
                return RedirectToAction("Entrar");

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

            TempData["CadastroOk"] = true;
            return RedirectToAction("Create");
        }

        // ============================================================
        // LISTAR
        // ============================================================
        public async Task<IActionResult> Index()
        {
            var usuarios = await _context.Usuario
                .Include(u => u.TipoUsuario)
                .ToListAsync();

            return View(usuarios);
        }

        // ============================================================
        // EDITAR - GET
        // ============================================================
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var user = await _context.Usuario.FindAsync(id);

            if (user == null)
                return NotFound();

            ViewBag.TipoUsuarioId = new SelectList(
                await _context.TipoUsuario.ToListAsync(),
                "IdTipoUsuario",
                "DescricaoTipoUsuario",
                user.TipoUsuarioId
            );

            return View(user);
        }

        // ============================================================
        // EDITAR - POST
        // ============================================================
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

            TempData["UsuarioEditado"] = "true";
            return RedirectToAction(nameof(Index));
        }


        // ============================================================
        // CARTEIRINHA — USA USUÁRIO LOGADO
        // ============================================================
        [HttpGet]
        public IActionResult Carteirinha()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
                return RedirectToAction("Entrar");

            var usuario = _context.Usuario
                .FirstOrDefault(u => u.IdUsuario == int.Parse(userId));

            if (usuario == null)
                return RedirectToAction("Entrar");

            var vacinacoes = _context.Vacinacao
                .Include(v => v.Vacina)
                .Include(v => v.Unidade)
                .Where(v => v.IdUsuario == usuario.IdUsuario)
                .ToList();

            var itens = vacinacoes.Select(v => new CarteirinhaItemViewModel
            {
                NomeVacina = v.Vacina?.NomeVacina,
                Tomou = true,
                DataTomou = v.DataTomou,
                NomeUnidade = v.Unidade?.NomeUnidade,
                EnderecoUnidade = v.Unidade?.Endereco
            }).ToList();

            return View("Carteirinha", new CarteirinhaViewModel
            {
                IdUsuario = usuario.IdUsuario,
                NomeUsuario = usuario.Nome,
                Itens = itens
            });
        }


        // ============================================================
        // LOGOUT REAL (COOKIE + SESSION)
        // ============================================================
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            HttpContext.Session.Clear();

            return RedirectToAction("Entrar");
        }
    }
}
