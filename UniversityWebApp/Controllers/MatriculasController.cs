using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entidades.Models;
using Persistencia.Repositorio;

namespace UniversityWebApp.Controllers
{
    public class MatriculasController : Controller
    {
        private readonly SchoolContext _context;

        public MatriculasController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Matriculas
        public async Task<IActionResult> Index()
        {
            var res = NotFound();

            List<Matricula> matriculas = null;

            if (User.Identity.IsAuthenticated)
            {
                ApplicationUser user = _context.ApplicationUser.FirstOrDefault();
                matriculas = await _context.Matriculas.Include(m => m.Turma)
                                .Where(e => e.ApplicationUser.Matricula == user.Matricula).ToListAsync();
            }

            if (matriculas != null)
            {
                return View(matriculas);
            }

            return res;
        }

        // GET: Turmas/Matricular/1
        public async Task<IActionResult> Matricular(int? id)
        {
            //var res = NotFound();

            //List<ItemHistorico> historico = null;

            if (id != null && User.Identity.IsAuthenticated)
            {
                /*
                ApplicationUser user = _context.ApplicationUser.FirstOrDefault();
                historico = await _context.Historico
                                .Where(e => e.ApplicationUser.Matricula == user.Matricula).ToListAsync();*/
            }

            if (true)
            //if (historico != null)
            {
                return View();
                //return View(historico);
            }

            //return res;
        }

        // GET: Matriculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas
                .Include(m => m.Turma)
                .FirstOrDefaultAsync(m => m.MatriculaID == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // GET: Matriculas/Create
        public IActionResult Create()
        {
            ViewData["TurmaID"] = new SelectList(_context.Turma, "TurmaID", "TurmaID");
            return View();
        }

        // POST: Matriculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MatriculaID,TurmaID")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matricula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TurmaID"] = new SelectList(_context.Turma, "TurmaID", "TurmaID", matricula.TurmaID);
            return View(matricula);
        }

        // GET: Matriculas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula == null)
            {
                return NotFound();
            }
            ViewData["TurmaID"] = new SelectList(_context.Turma, "TurmaID", "TurmaID", matricula.TurmaID);
            return View(matricula);
        }

        // POST: Matriculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MatriculaID,TurmaID")] Matricula matricula)
        {
            if (id != matricula.MatriculaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matricula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatriculaExists(matricula.MatriculaID))
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
            ViewData["TurmaID"] = new SelectList(_context.Turma, "TurmaID", "TurmaID", matricula.TurmaID);
            return View(matricula);
        }

        // GET: Matriculas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas
                .Include(m => m.Turma)
                .FirstOrDefaultAsync(m => m.MatriculaID == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matricula = await _context.Matriculas.FindAsync(id);
            _context.Matriculas.Remove(matricula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatriculaExists(int id)
        {
            return _context.Matriculas.Any(e => e.MatriculaID == id);
        }
    }
}
