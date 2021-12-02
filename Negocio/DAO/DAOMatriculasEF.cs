using System.Collections.Generic;
using System.Linq;
using Persistencia.Repositorio;
using Entidades.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

        public void matricularAluno(int turmaID, string applicationUserMatricula)
        {
            //var matricula = await db.Matriculas.
            //Include("Turma").FirstOrDefaultAsync(m => m.MatriculaID == turmaID);

            //matricula.ApplicationUser.Matricula = applicationUserMatricula;

            ApplicationUser user = db.ApplicationUser.Where(x => x.Matricula.Contains(applicationUserMatricula)).Single();

            Matricula matricula = new Matricula
            {
                ApplicationUserID = user.Id,
                TurmaID = turmaID,
            };

            db.Matriculas.Add(matricula);

            db.SaveChanges();
          
        }

        public async Task Salvar(Matricula matricula)
        {
            await db.Matriculas.AddAsync(matricula);
            await db.SaveChangesAsync();
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
