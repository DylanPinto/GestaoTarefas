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
    public class FuncionariosController : Controller
    {
        private readonly GestaoTarefasDbContext _context;

        public FuncionariosController(GestaoTarefasDbContext context)
        {
            _context = context;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber
            )
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
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

            var funcionario = from f in _context.Funcionario.Include(d => d.Departamento).Include(c => c.Cargo)
                              select f;

            if (!String.IsNullOrEmpty(searchString))
            {
                funcionario = funcionario.Where(d => d.Nome.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    funcionario = funcionario.OrderByDescending(f => f.Nome);
                    break;
                default:
                    funcionario = funcionario.OrderBy(f => f.Nome);
                    break;

            }

            int pageSize = 3;
            return View(await PaginatedList<Funcionario>.CreateAsync(funcionario.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .Include(d => d.Departamento)
                .Include(c => c.Cargo)
                
                .FirstOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento, "DepartamentoId", "Nome");
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "NomeCargo");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuncionarioId,Nome,SobreNome,Sexo,NTelemovel,Email,DepartamentoId,CargoId")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();

                ViewBag.Mensagem = "Funcionario adicionado com sucesso";
                return View("Success");

            }
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento, "DepartamentoId", "Nome", funcionario.DepartamentoId);
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CardoId", "NomeCargo",funcionario.CargoId);
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento, "DepartamentoId", "Nome");
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "NomeCargo");
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuncionarioId,Nome,SobreNome,Sexo,NTelemovel,Email,DepartamentoId,CargoId")] Funcionario funcionario)
        {
            if (id != funcionario.FuncionarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionariosExists(funcionario.FuncionarioId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Mensagem = "Informação do funcionario atualizada com sucesso";
                return View("Success");
            }
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento, "DepartamentoId", "Nome", funcionario.DepartamentoId);
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CardoId", "NomeCargo", funcionario.CargoId);
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .FirstOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario == null) {
                return NotFound();
            }

            try
            {

                _context.Funcionario.Remove(funcionario);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return View("ErrorDeleting");
            }

            ViewBag.Mensagem = "Funcionario eliminado com sucesso!";
            return View("Success");
        }

        private bool FuncionariosExists(int id)
        {
            return _context.Funcionario.Any(e => e.FuncionarioId == id);
        }
    }
}
