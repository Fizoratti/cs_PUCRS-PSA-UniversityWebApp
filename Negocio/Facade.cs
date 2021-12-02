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
        private DAOMatriculas _matriculas = new DAOMatriculasEF();
        private DaoUsuarios _usuarios = new DaoUsuarios();
        private DAOTurmas _turmas = new DAOTurmasEF();

        public async Task Matricular(int turmaID, string emailDoUsuario)
        {
            var turma = await _turmas.ComId(turmaID);
            var usuario = await _usuarios.ComEmail(emailDoUsuario);

            // buscar todos os horários de curso que esse usuário tem, e verificar se não é o mesmo horário que o curso que ele tá tentando matricular
            if (!usuario.TemHorarioLivre(turma.Horario))
            {
                throw new ArgumentException("Você já contém uma turma com esse horário");
            }

            var matricula = new Matricula()
            {
                Turma = turma,
                ApplicationUser = usuario
            };
            await _matriculas.Salvar(matricula);
        }

        public List<Matricula> Listar(string applicationUserMatricula)
        {
            return _matriculas.buscarMatriculas(applicationUserMatricula);
        }
    }
}
