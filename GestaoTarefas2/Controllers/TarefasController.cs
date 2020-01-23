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
    public class TarefasController : Controller
    {
        private readonly GestaoTarefasDbContext _context;

        public TarefasController(GestaoTarefasDbContext context)
        {
            _context = context;
        }

        // GET: Tarefas
        public async Task<IActionResult> Index(string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.DateSortParm_end = sortOrder == "Date_end" ? "date_desc_end" : "Date_end";
            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var tarefa = from t in _context.Tarefa.Include(f => f.Funcionario).Include(tr =>tr.TipoTarefa)
                         select t;
            

                if (!String.IsNullOrEmpty(searchString))
            {
                tarefa = tarefa.Where(t => t.NomeTarefa.Contains(searchString)|| t.Funcionario.Nome.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    tarefa = tarefa.OrderByDescending(t => t.NomeTarefa);
                    break;
                case "Date":
                    tarefa = tarefa.OrderBy(t => t.DataInicio);
                    break;
                case "date_desc":
                    tarefa = tarefa.OrderByDescending(t => t.DataInicio);
                    break;
                case "Date_end":
                    tarefa = tarefa.OrderBy(t => t.DataFim);
                    break;
                case "date_desc_end":
                    tarefa = tarefa.OrderByDescending(t => t.DataFim);
                    break;
                default:
                    tarefa = tarefa.OrderBy(t => t.NomeTarefa);
                    break;

            }

            int pageSize = 3;

            return View(await PaginatedList<Tarefa>.CreateAsync(tarefa.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Tarefas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefa
                .Include(t => t.Funcionario)
                .Include(f => f.TipoTarefa)
                .FirstOrDefaultAsync(m => m.TarefaId == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        // GET: Tarefas/Create
        public IActionResult Create()
        {
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome");
            ViewData["TipoId"] = new SelectList(_context.TipoTarefa, "TipoId", "TipoNome");
            return View();
        }

        // POST: Tarefas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TarefaId,NomeTarefa,NomeOrdena,FuncionarioId,DataInicio,DataFim,TipoId,Descricao,estadoTarefa")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarefa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome", tarefa.FuncionarioId);
            ViewData["TipoId"] = new SelectList(_context.TipoTarefa, "TipoId", "TipoMome", tarefa.TipoId);
            return View(tarefa);
        }

        // GET: Tarefas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefa.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome", tarefa.FuncionarioId);
            ViewData["TipoId"] = new SelectList(_context.TipoTarefa, "TipoId", "TipoNome", tarefa.TipoId);
            return View(tarefa);
        }

        // POST: Tarefas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TarefaId,NomeTarefa,NomeOrdena,FuncionarioId,DataInicio,DataFim,TipoId,Descricao,estadoTarefa")] Tarefa tarefa)
        {
            if (id != tarefa.TarefaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarefa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarefaExists(tarefa.TarefaId))
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
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome", tarefa.FuncionarioId);
            ViewData["TipoId"] = new SelectList(_context.TipoTarefa, "TipoId", "TipoNome", tarefa.TipoId);
            return View(tarefa);
        }

        // GET: Tarefas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefa
                .Include(t => t.Funcionario)
                .FirstOrDefaultAsync(m => m.TarefaId == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarefa = await _context.Tarefa.FindAsync(id);
            _context.Tarefa.Remove(tarefa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarefaExists(int id)
        {
            return _context.Tarefa.Any(e => e.TarefaId == id);
        }
    }
}
