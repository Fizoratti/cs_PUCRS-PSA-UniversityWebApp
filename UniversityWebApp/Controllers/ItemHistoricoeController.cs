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
    public class ItemHistoricoeController : Controller
    {
        private readonly SchoolContext _context;

        public ItemHistoricoeController(SchoolContext context)
        {
            _context = context;
        }

        // GET: ItemHistoricoe
        public async Task<IActionResult> Index()
        {
            var res = NotFound();
            
            List<ItemHistorico> historico = null;

            if (User.Identity.IsAuthenticated)
            {
                ApplicationUser user = _context.ApplicationUser.FirstOrDefault();

                historico = await _context.Historico
                    .Where(e => e.Matricula == Int32.Parse(user.Matricula)).ToListAsync();
            }

            if (historico != null)
            {
                return View(historico);
            }

            return res;
        }

        // GET: ItemHistoricoe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemHistorico = await _context.Historico
                .FirstOrDefaultAsync(m => m.ItemHistoricoID == id);
            if (itemHistorico == null)
            {
                return NotFound();
            }

            return View(itemHistorico);
        }

        // GET: ItemHistoricoe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemHistoricoe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemHistoricoID,Nota,Semestre,Matricula")] ItemHistorico itemHistorico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemHistorico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemHistorico);
        }

        // GET: ItemHistoricoe/Edit/5
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
            return View(itemHistorico);
        }

        // POST: ItemHistoricoe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemHistoricoID,Nota,Semestre,Matricula")] ItemHistorico itemHistorico)
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
            return View(itemHistorico);
        }

        // GET: ItemHistoricoe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemHistorico = await _context.Historico
                .FirstOrDefaultAsync(m => m.ItemHistoricoID == id);
            if (itemHistorico == null)
            {
                return NotFound();
            }

            return View(itemHistorico);
        }

        // POST: ItemHistoricoe/Delete/5
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
