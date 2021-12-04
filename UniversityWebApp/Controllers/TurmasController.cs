using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entidades.Models;
using Persistencia.Repositorio;
using Negocio;

namespace UniversityWebApp.Controllers
{
    public class TurmasController : Controller
    {
        private readonly SchoolContext _context;
        private readonly Facade _facade;

        public TurmasController(SchoolContext context, Facade facade)
        {
            _context = context;
            _facade = facade;
        }

        // GET: Turmas
        public async Task<IActionResult> Index(string searchString)
        {
            var turmas = await _facade.ListarTurmas(searchString);
            return View(turmas);
        }
        
        // Aqui fica coisas de HTML, como pegar o User.Identity e retornar uma action (como uma view ou um redirect
        public async Task<IActionResult> Matricular(int id)
        {
            try
            {
                var emailDoUsuario = User.Identity.Name;
                await _facade.Matricular(id, emailDoUsuario);
                return RedirectToAction("Index", "Matriculas");
            }
            catch(ArgumentException excecao)
            {
                return RedirectToAction("Index", "Error", new { Error = excecao.Message });
            }
        }

        // GET: Turmas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turma
                .Include(t => t.Disciplina)
                .FirstOrDefaultAsync(m => m.TurmaID == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // GET: Turmas/Create
        public IActionResult Create()
        {
            //ViewData["DisciplinaID"] = new SelectList(_context.Disciplinas, "DisciplinaID", "DisciplinaID");
            return View();
        }

        // POST: Turmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TurmaID,DisciplinaID,Horario,Numero,Vagas")] Turma turma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["DisciplinaID"] = new SelectList(_context.Disciplinas, "DisciplinaID", "DisciplinaID", turma.DisciplinaID);
            return View(turma);
        }

        // GET: Turmas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turma.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }
            ViewData["DisciplinaID"] = new SelectList(_context.Disciplinas, "DisciplinaID", "DisciplinaID", turma.DisciplinaID);
            return View(turma);
        }

        // POST: Turmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TurmaID,DisciplinaID,Horario,Numero,Vagas")] Turma turma)
        {
            if (id != turma.TurmaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Turma.Update(turma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmaExists(turma.TurmaID))
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
            //ViewData["DisciplinaID"] = new SelectList(_context.Disciplinas, "DisciplinaID", "DisciplinaID", turma.DisciplinaID);
            return View(turma);
        }

        // GET: Turmas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turma
                .Include(t => t.Disciplina)
                .FirstOrDefaultAsync(m => m.TurmaID == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turma = await _context.Turma.FindAsync(id);
            _context.Turma.Remove(turma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmaExists(int id)
        {
            return _context.Turma.Any(e => e.TurmaID == id);
        }
    }
}
