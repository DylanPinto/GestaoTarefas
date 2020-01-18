using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoTarefas2.Models;

namespace GestaoTarefas2.Controllers
{
    public class TiposTarefasController : Controller
    {
        private readonly GestaoTarefasDbContext _context;

        public TiposTarefasController(GestaoTarefasDbContext context)
        {
            _context = context;
        }

        // GET: TiposTarefas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposTarefas.ToListAsync());
        }

        // GET: TiposTarefas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposTarefas = await _context.TiposTarefas
                .FirstOrDefaultAsync(m => m.TipoId == id);
            if (tiposTarefas == null)
            {
                return NotFound();
            }

            return View(tiposTarefas);
        }

        // GET: TiposTarefas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposTarefas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoId,TipoTarefa")] TiposTarefas tiposTarefas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposTarefas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposTarefas);
        }

        // GET: TiposTarefas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposTarefas = await _context.TiposTarefas.FindAsync(id);
            if (tiposTarefas == null)
            {
                return NotFound();
            }
            return View(tiposTarefas);
        }

        // POST: TiposTarefas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoId,TipoTarefa")] TiposTarefas tiposTarefas)
        {
            if (id != tiposTarefas.TipoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposTarefas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposTarefasExists(tiposTarefas.TipoId))
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
            return View(tiposTarefas);
        }

        // GET: TiposTarefas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposTarefas = await _context.TiposTarefas
                .FirstOrDefaultAsync(m => m.TipoId == id);
            if (tiposTarefas == null)
            {
                return NotFound();
            }

            return View(tiposTarefas);
        }

        // POST: TiposTarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposTarefas = await _context.TiposTarefas.FindAsync(id);
            _context.TiposTarefas.Remove(tiposTarefas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposTarefasExists(int id)
        {
            return _context.TiposTarefas.Any(e => e.TipoId == id);
        }
    }
}
