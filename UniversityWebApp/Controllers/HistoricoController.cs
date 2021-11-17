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
    public class HistoricoController : Controller
    {
        private readonly SchoolContext _context;

        public HistoricoController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Historico
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Historico.Include(i => i.Disciplina);
            return View(await schoolContext.ToListAsync());
        }

        // GET: Historico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemHistorico = await _context.Historico
                .Include(i => i.Disciplina)
                .FirstOrDefaultAsync(m => m.ItemHistoricoID == id);
            if (itemHistorico == null)
            {
                return NotFound();
            }

            return View(itemHistorico);
        }

        // GET: Historico/Create
        public IActionResult Create()
        {
            ViewData["DisciplinaID"] = new SelectList(_context.Disciplinas, "DisciplinaID", "DisciplinaID");
            return View();
        }

        // POST: Historico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemHistoricoID,DisciplinaID,AnoSemestre,Nota")] ItemHistorico itemHistorico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemHistorico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DisciplinaID"] = new SelectList(_context.Disciplinas, "DisciplinaID", "DisciplinaID", itemHistorico.DisciplinaID);
            return View(itemHistorico);
        }

        // GET: Historico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemHistorico = await _context.Historico.FindAsync(id);
            if (itemHistorico == null)
            {
                return NotFound();
            }
            ViewData["DisciplinaID"] = new SelectList(_context.Disciplinas, "DisciplinaID", "DisciplinaID", itemHistorico.DisciplinaID);
            return View(itemHistorico);
        }

        // POST: Historico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemHistoricoID,DisciplinaID,AnoSemestre,Nota")] ItemHistorico itemHistorico)
        {
            if (id != itemHistorico.ItemHistoricoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemHistorico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemHistoricoExists(itemHistorico.ItemHistoricoID))
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
            ViewData["DisciplinaID"] = new SelectList(_context.Disciplinas, "DisciplinaID", "DisciplinaID", itemHistorico.DisciplinaID);
            return View(itemHistorico);
        }

        // GET: Historico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemHistorico = await _context.Historico
                .Include(i => i.Disciplina)
                .FirstOrDefaultAsync(m => m.ItemHistoricoID == id);
            if (itemHistorico == null)
            {
                return NotFound();
            }

            return View(itemHistorico);
        }

        // POST: Historico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemHistorico = await _context.Historico.FindAsync(id);
            _context.Historico.Remove(itemHistorico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemHistoricoExists(int id)
        {
            return _context.Historico.Any(e => e.ItemHistoricoID == id);
        }
    }
}
