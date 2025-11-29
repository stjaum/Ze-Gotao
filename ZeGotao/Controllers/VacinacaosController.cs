using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZeGotao.Core.Data;

namespace ZeGotao.Controllers
{
    public class VacinacaosController : Controller
    {
        private readonly ZeGotaoContext _context;

        public VacinacaosController(ZeGotaoContext context)
        {
            _context = context;
        }
        // GET: Vacinacaos
        public async Task<IActionResult> Index()
        {
            var zeGotaoContext = _context.Vacinacao.Include(v => v.Unidade).Include(v => v.Usuario).Include(v => v.Vacina);
            return View(await zeGotaoContext.ToListAsync());
        }

        // GET: Vacinacaos/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //        return NotFound();

        //    var vacinacao = await _context.Vacinacao
        //        .Include(v => v.Unidade)
        //        .Include(v => v.Usuario)
        //        .Include(v => v.Vacina)
        //        .FirstOrDefaultAsync(m => m.IdVacinacao == id);

        //    if (vacinacao == null)
        //        return NotFound();

        //    return View(Details); // <- AQUI ESTÁ A CORREÇÃO
        //}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var vacinacao = await _context.Vacinacao
                .Include(v => v.Unidade)
                .Include(v => v.Usuario)
                .Include(v => v.Vacina)
                .FirstOrDefaultAsync(m => m.IdVacinacao == id);

            if (vacinacao == null)
                return NotFound();

            return View(vacinacao);
        }

        // GET: Vacinacaos/Create
        public IActionResult Create()
        {
            ViewData["IdUnidade"] = new SelectList(_context.Unidade, "IdUnidade", "Endereco");
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Cpf");
            ViewData["IdVacina"] = new SelectList(_context.Vacinas, "IdVacina", "DescricaoVacina");
            return View();
        }

        // POST: Vacinacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVacinacao,IdUsuario,IdVacina,IdUnidade,Status")] Vacinacao vacinacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacinacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUnidade"] = new SelectList(_context.Unidade, "IdUnidade", "Endereco", vacinacao.IdUnidade);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Cpf", vacinacao.IdUsuario);
            ViewData["IdVacina"] = new SelectList(_context.Vacinas, "IdVacina", "DescricaoVacina", vacinacao.IdVacina);
            return View(vacinacao);
        }

        // GET: Vacinacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacinacao = await _context.Vacinacao.FindAsync(id);
            if (vacinacao == null)
            {
                return NotFound();
            }
            ViewData["IdUnidade"] = new SelectList(_context.Unidade, "IdUnidade", "Endereco", vacinacao.IdUnidade);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Cpf", vacinacao.IdUsuario);
            ViewData["IdVacina"] = new SelectList(_context.Vacinas, "IdVacina", "DescricaoVacina", vacinacao.IdVacina);
            return View(vacinacao);
        }

        // POST: Vacinacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVacinacao,IdUsuario,IdVacina,IdUnidade,Status")] Vacinacao vacinacao)
        {
            if (id != vacinacao.IdVacinacao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacinacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacinacaoExists(vacinacao.IdVacinacao))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUnidade"] = new SelectList(_context.Unidade, "IdUnidade", "Endereco", vacinacao.IdUnidade);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Cpf", vacinacao.IdUsuario);
            ViewData["IdVacina"] = new SelectList(_context.Vacinas, "IdVacina", "DescricaoVacina", vacinacao.IdVacina);
            return View(vacinacao);
        }

        // GET: Vacinacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacinacao = await _context.Vacinacao
                .Include(v => v.Unidade)
                .Include(v => v.Usuario)
                .Include(v => v.Vacina)
                .FirstOrDefaultAsync(m => m.IdVacinacao == id);
            if (vacinacao == null)
            {
                return NotFound();
            }

            return View(vacinacao);
        }

        // POST: Vacinacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacinacao = await _context.Vacinacao.FindAsync(id);
            if (vacinacao != null)
            {
                _context.Vacinacao.Remove(vacinacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacinacaoExists(int id)
        {
            return _context.Vacinacao.Any(e => e.IdVacinacao == id);
        }
    }
}
