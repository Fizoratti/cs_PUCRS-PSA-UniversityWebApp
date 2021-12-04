using System.Collections.Generic;
using System.Linq;
using Persistencia.Repositorio;
using Entidades.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Negocio.DAO
{
    public class DAOMatriculasEF : DAOMatriculas
    {
        private readonly SchoolContext _context;

        public DAOMatriculasEF(SchoolContext schoolContext)
        {
            this._context = schoolContext;
        }

        public List<Matricula> buscarMatriculas(string applicationUserMatricula){
            
            var matriculas = _context.Matriculas
                                           .Include(m => m.Turma)
                                            .Where(e => e.ApplicationUser.Matricula == applicationUserMatricula).ToList();

            return matriculas;
        }

        public Matricula buscarMatricula(int id){
            Matricula matricula = _context.Matriculas
                .Include(m => m.Turma)
                .FirstOrDefault(m => m.MatriculaID == id);

            return matricula;
        }

        public void matricularAluno(int turmaID, string applicationUserMatricula)
        {
            //var matricula = await _schoolContext.Matriculas.
            //Include("Turma").FirstOrDefaultAsync(m => m.MatriculaID == turmaID);

            //matricula.ApplicationUser.Matricula = applicationUserMatricula;

            ApplicationUser user = _context.ApplicationUser.Where(x => x.Matricula.Contains(applicationUserMatricula)).Single();

            Matricula matricula = new Matricula
            {
                ApplicationUserID = user.Id,
                TurmaID = turmaID,
            };

            user.Matriculas.Add(matricula);

            _context.Matriculas.Add(matricula);

            _context.SaveChanges();
          
        }

        public async Task Salvar(Matricula matricula)
        {
            await _context.Matriculas.AddAsync(matricula);
            await _context.SaveChangesAsync();
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
