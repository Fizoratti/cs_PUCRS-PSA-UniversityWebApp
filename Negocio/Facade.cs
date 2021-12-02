using Entidades.Models;
using Negocio.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Facade
    {
        private DAOTurmas _turmas;
        private DAOUsuarios _usuarios;
        private DAOMatriculas _matriculas;
        

        public Facade(DAOTurmas dAOTurmas, DAOUsuarios daoUsuarios, DAOMatriculas daoMatriculas)
        {
            _turmas = dAOTurmas;
            _usuarios = daoUsuarios;
            _matriculas = daoMatriculas;
        }

        public async Task Matricular(int turmaID, string emailDoUsuario)
        {
            var turma = await _turmas.ComId(turmaID);
            //var usuario = await _usuarios.ComEmail(emailDoUsuario);
            var usuario = await _usuarios.ComEmail(emailDoUsuario);
            // buscar todos os horários de curso que esse usuário tem, e verificar se não é o mesmo horário que o curso que ele tá tentando matricular
            //if (!usuario.TemHorarioLivre(turma.Horario))
            //{
            //    throw new ArgumentException("Você já contém uma turma com esse horário");
            //}
            if (turma.Vagas == 0) {
                throw new ArgumentException("Não possui vagas disponíveis.");//Gerar erro de não há vagas
            }
            
          /*
            if (usuario.Matriculas.Equals(turma.DisciplinaID)) {

                throw new ArgumentException("Você já se matriculou nessa disciplina");//Gerar erro já se matriculou
            }
          */
            turma.Vagas--;

            //verificar requisitos...

            var matricula = new Matricula()
            {
                Turma = turma,                
                ApplicationUser = usuario
            };
            await _matriculas.Salvar(matricula);
            
        }
        public async Task Desmatricular(int turmaID) {

            var turma = await _turmas.ComId(turmaID);
            turma.Vagas++;

        }


        public List<Matricula> Listar(string applicationUserMatricula)
        {
            return _matriculas.buscarMatriculas(applicationUserMatricula);
        }
    }
}
