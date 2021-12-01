using System.Collections.Generic;
using System.Linq;
using Persistencia.Repositorio;
using Entidades.Models;
using Microsoft.EntityFrameworkCore;

namespace Negocio.DAO
{
    class DAOMatriculasEF : DAOMatriculas
    {
        private SchoolContext db = new SchoolContext();

        public List<Matricula> buscarMatriculas(string applicationUserMatricula){
            
            var matriculas = db.Matriculas.Include(m => m.Turma)
                                .Where(e => e.ApplicationUser.Matricula == applicationUserMatricula).ToList();

            return matriculas;
        }

        public Matricula buscarMatriculas(int id){
            Matricula matricula = db.Matriculas
                .Include(m => m.Turma)
                .FirstOrDefault(m => m.MatriculaID == id);

            return matricula;
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
