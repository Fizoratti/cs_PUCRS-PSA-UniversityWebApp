using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Repositorio;
using System;
using Entidades.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Negocio.DAO
{
    class DAOMatriculasEF : DAOMatriculas
    {
        private SchoolContext db = new SchoolContext();

        public List<Matricula> buscarMatriculas(string applicationUserMatricula){
            
            var matriculas = await _context.Matriculas.Include(m => m.Turma)
                                .Where(e => e.ApplicationUser.Matricula == applicationUserMatricula).ToListAsync();

            return matriculas;
        }

        public Matricula buscarMatriculas(int id){
            var matricula = await _context.Matriculas
                .Include(m => m.Turma)
                .FirstOrDefaultAsync(m => m.MatriculaID == id);

            return matriculas;
        }

        public bool matricularAluno(int turmaID, string applicationUserMatricula)
        {
            var matricula = db.Matriculas.
            Include("Turma").FirstOrDefault(m => m.MatriculaID == turmaID);

            matricula.ApplicationUser.Matricula = applicationUserMatricula;

            db.SaveChanges();
            
            return true;
        }

        public bool editarMatriculaAluno(int id){
            return true;
        }
        
        public bool excluirMatriculaAluno(int id){
            return true;
        }
        
        public bool verificaExistenciaMatricula(int id){
            return true;
        }

    }
}
