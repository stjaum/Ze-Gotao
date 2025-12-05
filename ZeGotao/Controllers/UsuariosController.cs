using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZeGotao.Core.Data;
using ZeGotao.Models;
using ZeGotao.ViewModels;

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

            return RedirectToAction("PosLogin");
        }

        // ============================================================
        // POS LOGIN
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

            ViewBag.TipoUsuarioId = new SelectList(
                await _context.TipoUsuario.ToListAsync(),
                "IdTipoUsuario",
                "DescricaoTipoUsuario",
                user.TipoUsuarioId
            );

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();

                TempData["UsuarioEditado"] = "true";

                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }


        // ============================================================
        // CARTEIRINHA — USA USUÁRIO LOGADO
        // ============================================================
        [HttpGet]
        public IActionResult Carteirinha()
        {
            var idUsuario = HttpContext.Session.GetInt32("IdUsuario");

            if (idUsuario == null)
                return RedirectToAction("Entrar");

            var usuario = _context.Usuario
                .FirstOrDefault(u => u.IdUsuario == idUsuario.Value);

            if (usuario == null)
                return RedirectToAction("Entrar");

            var vacinacoes = _context.Vacinacao
                .Include(v => v.Vacina)
                .Include(v => v.Unidade)
                .Where(v => v.IdUsuario == idUsuario.Value)
                .ToList();

            var itens = vacinacoes.Select(v => new CarteirinhaItemViewModel
            {
                NomeVacina = v.Vacina?.NomeVacina,
                Tomou = true,
                DataTomou = v.DataTomou,
                NomeUnidade = v.Unidade?.NomeUnidade,
                EnderecoUnidade = v.Unidade?.Endereco
            }).ToList();

            var model = new CarteirinhaViewModel
            {
                IdUsuario = usuario.IdUsuario,
                NomeUsuario = usuario.Nome,
                Itens = itens
            };

            return View("Carteirinha", model);
        }

        // ============================================================
        // ATUALIZAR CARTEIRINHA — GET
        // ============================================================
        [HttpGet]
        public IActionResult AtualizarCarteirinha()
        {
            var idUsuario = HttpContext.Session.GetInt32("IdUsuario");

            if (idUsuario == null)
                return RedirectToAction("Entrar");

            var model = new AtualizarCarteirinhaViewModel
            {
                IdUsuario = idUsuario.Value,

                Vacinas = _context.Vacinas
                    .Select(v => new SelectListItem
                    {
                        Value = v.IdVacina.ToString(),
                        Text = v.NomeVacina
                    }).ToList(),

                Unidades = _context.Unidade
                    .Select(u => new SelectListItem
                    {
                        Value = u.IdUnidade.ToString(),
                        Text = u.NomeUnidade
                    }).ToList()
            };

            return View("AtualizarCarteirinha", model);
        }

        // ============================================================
        // ATUALIZAR CARTEIRINHA — POST
        // ============================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AtualizarCarteirinha(AtualizarCarteirinhaViewModel model)
        {
            if (!ModelState.IsValid)
                return View("AtualizarCarteirinha", model);

            var novo = new Vacinacao
            {
                IdUsuario = model.IdUsuario,
                IdVacina = model.IdVacina,
                IdUnidade = model.IdUnidade,
                DataTomou = model.DataTomou
            };

            _context.Vacinacao.Add(novo);
            _context.SaveChanges();

            return RedirectToAction("Carteirinha");
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
