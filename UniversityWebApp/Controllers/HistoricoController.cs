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
    public class HistoricoController : Controller
    {
        private readonly SchoolContext _context;
        private readonly Facade _negocio;

        public HistoricoController(Facade negocio, SchoolContext context)
        {
            _negocio = negocio;
            _context = context;
        }

        // GET: Historico
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ApplicationUser user = _negocio.UsuarioComEmail(User.Identity.Name).Result;
                var historico = await _negocio.ListarHistorico(user.Matricula);

                if (historico != null)
                {
                    return View(historico);
                }
            }

            return NotFound();
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
