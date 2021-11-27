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
            var res = NotFound();

            List<ItemHistorico> historico = null;

            if (User.Identity.IsAuthenticated)
            {
                ApplicationUser user = _context.ApplicationUser.FirstOrDefault();
                historico = await _context.Historico
                                .Where(e => e.ApplicationUser.Matricula == user.Matricula).ToListAsync();
            }

            if (historico != null)
            {
                return View(historico);
            }

            return res;
        }

        // GET: Historico/Details/5
        public async Task<IActionResult> Details(int? id)
        { 

            if (id == null)
            {
                return NotFound();
            }

            var historico = await _context.Historico
                .FirstOrDefaultAsync();
            if (historico == null)
            {
                return NotFound();
            }

            return View(historico);
        }

        // GET: Historico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historico = await _context.Historico.FindAsync(id);
            if (historico == null)
            {
                return NotFound();
            }
            ViewData["DisciplinaID"] = new SelectList(_context.Disciplinas, "DisciplinaID", "DisciplinaID", historico.DisciplinaID);
            return View(historico);
        }

    }
}
