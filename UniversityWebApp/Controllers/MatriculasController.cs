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
    public class MatriculasController : Controller
    {
        private readonly Facade _facade;
        private readonly SchoolContext _context;

        public MatriculasController(Facade facade, SchoolContext context)
        {
            _facade = facade;
            _context = context;
        }

        // GET: Matriculas
        public async Task<IActionResult> Index()
        {
            var emailDoUsuario = User.Identity.Name;
            var matriculas = await _facade.ListarMatriculas(emailDoUsuario);
            if (matriculas != null)
            {
                return View(matriculas);
            }
            return NotFound();
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
        // GET: Matriculas/GradeHorario
        public async Task<IActionResult> GradeHorario()
        {

            ApplicationUser user = _facade.UsuarioComEmail(User.Identity.Name).Result;
            user.Matriculas = await _facade.ListarMatriculas(user.Email);

            if (user.Matriculas.Count == 0) { return View(); };

            try { ViewData["2LM"] = user.Matriculas.FirstOrDefault(p => p.Turma.Horario.Contains("2LM")).Turma.Disciplina.Nome; } catch (Exception e) { ViewData["2LM"] = "-"; }
            try { ViewData["3LM"] = user.Matriculas.FirstOrDefault(p => p.Turma.Horario.Contains("3LM")).Turma.Disciplina.Nome; } catch (Exception e) { ViewData["3LM"] = "-"; }
            try { ViewData["4LM"] = user.Matriculas.FirstOrDefault(p => p.Turma.Horario.Contains("4LM")).Turma.Disciplina.Nome; } catch (Exception e) { ViewData["4LM"] = "-"; }
            try { ViewData["5LM"] = user.Matriculas.FirstOrDefault(p => p.Turma.Horario.Contains("5LM")).Turma.Disciplina.Nome; } catch (Exception e) { ViewData["5LM"] = "-"; }
            try { ViewData["6LM"] = user.Matriculas.FirstOrDefault(p => p.Turma.Horario.Contains("6LM")).Turma.Disciplina.Nome; } catch (Exception e) { ViewData["6LM"] = "-"; }
            try { ViewData["2NP"] = user.Matriculas.FirstOrDefault(p => p.Turma.Horario.Contains("2NP")).Turma.Disciplina.Nome; } catch (Exception e) { ViewData["2NP"] = "-"; }
            try { ViewData["3NP"] = user.Matriculas.FirstOrDefault(p => p.Turma.Horario.Contains("3NP")).Turma.Disciplina.Nome; } catch (Exception e) { ViewData["3NP"] = "-"; }
            try { ViewData["4NP"] = user.Matriculas.FirstOrDefault(p => p.Turma.Horario.Contains("4NP")).Turma.Disciplina.Nome; } catch (Exception e) { ViewData["4NP"] = "-"; }
            try { ViewData["5NP"] = user.Matriculas.FirstOrDefault(p => p.Turma.Horario.Contains("5NP")).Turma.Disciplina.Nome; } catch (Exception e) { ViewData["5NP"] = "-"; }
            try { ViewData["6NP"] = user.Matriculas.FirstOrDefault(p => p.Turma.Horario.Contains("6NP")).Turma.Disciplina.Nome; } catch (Exception e) { ViewData["6NP"] = "-"; }

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
                return BadRequest();
            }

            var emailDoUsuario = User.Identity.Name;
            await _facade.Desmatricular(id.Value, emailDoUsuario);

            return RedirectToAction("index");
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

        [Route("Matriculas/AlunosMatriculados")]
        public async Task<IActionResult> AlunosMatriulados()
        {
            var disciplinas = await _facade.ListarDisciplinas();
            return View("AlunosMatriculados", disciplinas);

        }
        [Route("Matriculas/ListaAlunos")]
        public async Task<IActionResult> ListaAlunos(string? codcred)
        {
            var alunos = await _facade.ListarAlunos(codcred);
            ViewData["codcred"] = codcred;
            return View("ListaAlunos",alunos);

        }
    }
}
