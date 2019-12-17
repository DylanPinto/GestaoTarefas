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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Funcionarios.ToListAsync());
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await _context.Funcionarios
                .FirstOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionarios == null)
            {
                return NotFound();
            }

            return View(funcionarios);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "Nome");
            ViewData["CargoId"] = new SelectList(_context.Cargos, "CargoId", "NomeCargo");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuncionarioId,Nome,SobreNome,Sexo,NTelemovel,Email,DepartamentoId,CargoId")] Funcionarios funcionarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionarios);
                await _context.SaveChangesAsync();

                ViewBag.Mensagem = "Funcionario adicionado com sucesso";
                return View("Success");

            }
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "Nome", funcionarios.DepartamentoId);
            ViewData["CargoId"] = new SelectList(_context.Cargos, "CardoId", "NomeCargo",funcionarios.CargoId);
            return View(funcionarios);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await _context.Funcionarios.FindAsync(id);
            if (funcionarios == null)
            {
                return NotFound();
            }
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "Nome", funcionarios.DepartamentoId);
            ViewData["CargoId"] = new SelectList(_context.Cargos, "CardoId", "NomeCargo", funcionarios.CargoId);
            return View(funcionarios);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuncionarioId,Nome,SobreNome,Sexo,NTelemovel,Email,DepartamentoId,CargoId")] Funcionarios funcionarios)
        {
            if (id != funcionarios.FuncionarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionariosExists(funcionarios.FuncionarioId))
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
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "Nome", funcionarios.DepartamentoId);
            ViewData["CargoId"] = new SelectList(_context.Cargos, "CardoId", "NomeCargo", funcionarios.CargoId);
            return View(funcionarios);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await _context.Funcionarios
                .FirstOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionarios == null)
            {
                return NotFound();
            }

            return View(funcionarios);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionarios = await _context.Funcionarios.FindAsync(id);
            if (funcionarios == null) {
                return NotFound();
            }

            try
            {

                _context.Funcionarios.Remove(funcionarios);
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
            return _context.Funcionarios.Any(e => e.FuncionarioId == id);
        }
    }
}
