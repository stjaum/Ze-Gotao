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
    public class DependenteUsuariosController : Controller
    {
        private readonly ZeGotaoContext _context;

        public DependenteUsuariosController(ZeGotaoContext context)
        {
            _context = context;
        }

        // GET: DependenteUsuarios
        public async Task<IActionResult> Index()
        {
            var zeGotaoContext = _context.DependenteUsuario.Include(d => d.Usuario);
            return View(await zeGotaoContext.ToListAsync());
        }

        // GET: DependenteUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependenteUsuario = await _context.DependenteUsuario
                .Include(d => d.Usuario)
                .FirstOrDefaultAsync(m => m.IdDependenteUsuario == id);
            if (dependenteUsuario == null)
            {
                return NotFound();
            }

            return View(dependenteUsuario);
        }

        // GET: DependenteUsuarios/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Cpf");
            return View();
        }

        // POST: DependenteUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDependenteUsuario,IdUsuario,Nome,Cpf,DataNascimento")] DependenteUsuario dependenteUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dependenteUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Cpf", dependenteUsuario.IdUsuario);
            return View(dependenteUsuario);
        }

        // GET: DependenteUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependenteUsuario = await _context.DependenteUsuario.FindAsync(id);
            if (dependenteUsuario == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Cpf", dependenteUsuario.IdUsuario);
            return View(dependenteUsuario);
        }

        // POST: DependenteUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDependenteUsuario,IdUsuario,Nome,Cpf,DataNascimento")] DependenteUsuario dependenteUsuario)
        {
            if (id != dependenteUsuario.IdDependenteUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dependenteUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DependenteUsuarioExists(dependenteUsuario.IdDependenteUsuario))
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
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Cpf", dependenteUsuario.IdUsuario);
            return View(dependenteUsuario);
        }

        // GET: DependenteUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependenteUsuario = await _context.DependenteUsuario
                .Include(d => d.Usuario)
                .FirstOrDefaultAsync(m => m.IdDependenteUsuario == id);
            if (dependenteUsuario == null)
            {
                return NotFound();
            }

            return View(dependenteUsuario);
        }

        // POST: DependenteUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dependenteUsuario = await _context.DependenteUsuario.FindAsync(id);
            if (dependenteUsuario != null)
            {
                _context.DependenteUsuario.Remove(dependenteUsuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DependenteUsuarioExists(int id)
        {
            return _context.DependenteUsuario.Any(e => e.IdDependenteUsuario == id);
        }
    }
}
