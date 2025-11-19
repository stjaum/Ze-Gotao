using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZeGotao.Data;

namespace ZeGotao.Controllers
{
    public class VacinasController : Controller
    {
        private readonly ZeGotaoContext _context;

        public VacinasController(ZeGotaoContext context)
        {
            _context = context;
        }

        // GET: Vacinas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vacinas.ToListAsync());
        }

        // GET: Vacinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacinas = await _context.Vacinas
                .FirstOrDefaultAsync(m => m.IdVacina == id);
            if (vacinas == null)
            {
                return NotFound();
            }

            return View(vacinas);
        }

        // GET: Vacinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vacinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVacina,NomeVacina,DescricaoVacina,FaixaEtaria")] Vacinas vacinas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacinas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vacinas);
        }

        // GET: Vacinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacinas = await _context.Vacinas.FindAsync(id);
            if (vacinas == null)
            {
                return NotFound();
            }
            return View(vacinas);
        }

        // POST: Vacinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVacina,NomeVacina,DescricaoVacina,FaixaEtaria")] Vacinas vacinas)
        {
            if (id != vacinas.IdVacina)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacinas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacinasExists(vacinas.IdVacina))
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
            return View(vacinas);
        }

        // GET: Vacinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacinas = await _context.Vacinas
                .FirstOrDefaultAsync(m => m.IdVacina == id);
            if (vacinas == null)
            {
                return NotFound();
            }

            return View(vacinas);
        }

        // POST: Vacinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacinas = await _context.Vacinas.FindAsync(id);
            if (vacinas != null)
            {
                _context.Vacinas.Remove(vacinas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacinasExists(int id)
        {
            return _context.Vacinas.Any(e => e.IdVacina == id);
        }
    }
}
