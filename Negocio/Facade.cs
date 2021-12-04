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
            var usuario = await _usuarios.ComEmail(emailDoUsuario);
                                            
            if (turma.Vagas == 0) {
                throw new ArgumentException("Não possui vagas disponíveis.");//Gerar erro de não há vagas
            }

            if (usuario.ContemMatriculaParaTurma(turma))
            {
                throw new ArgumentException("Esse usuário já possue uma matricula para esta turma");
            }

            if (usuario.VerificaSeConflitaHorario(turma))
            {
                throw new ArgumentException("Esse usuário tem conflito na grade de horários");
            }

            var matricula = new Matricula()
            {
                Turma = turma,                
                ApplicationUser = usuario
            };
            await _matriculas.Salvar(matricula);
            
        }

        public async Task<IEnumerable<Turma>> ListarTurmas(string pesquisa)
        {
            var turmas = await _turmas.ListarTurmas(pesquisa);
            return turmas;
        }

        public async Task<ICollection<Matricula>> ListarMatriculas(string emailDoUsuario)
        {
            var usuario = await _usuarios.ComEmail(emailDoUsuario);
            return usuario.Matriculas;
        }

        public async Task Desmatricular(int matriculaId, string emailDoUsuario) 
        {
            var usuario = await _usuarios.ComEmail(emailDoUsuario);
            var matricula = usuario.Matriculas.SingleOrDefault(p => p.MatriculaID == matriculaId);
            usuario.Matriculas.Remove(matricula);
            await _usuarios.Atualiza(usuario);
        }


        public List<Matricula> Listar(string applicationUserMatricula)
        {
            return _matriculas.buscarMatriculas(applicationUserMatricula);
        }
    }
}
