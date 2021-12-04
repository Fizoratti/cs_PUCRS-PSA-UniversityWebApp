using Entidades.Models;
using Negocio.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class Facade
    {
        private DAODisciplina _disciplinas;
        private DAOTurmas _turmas;
        private DAOUsuarios _usuarios;
        private DAOMatriculas _matriculas;
        private DAOHistorico _historico;


        public Facade(DAODisciplina daoDisciplinas, DAOTurmas daoTurmas, DAOUsuarios daoUsuarios, DAOMatriculas daoMatriculas, DAOHistorico daoHistorico)
        {
            _disciplinas = daoDisciplinas;
            _turmas = daoTurmas;
            _usuarios = daoUsuarios;
            _matriculas = daoMatriculas;
            _historico = daoHistorico;
        }

        public async Task Matricular(int turmaID, string emailDoUsuario)
        {
            var turma = await _turmas.ComId(turmaID);
            var usuario = await _usuarios.ComEmail(emailDoUsuario);

            if (turma.Vagas == 0)
            {
                throw new ArgumentException("Não possui vagas disponíveis.");//Gerar erro de não há vagas
            }

            if (usuario.ContemMatriculaParaTurma(turma))
            {
                throw new ArgumentException("Esse usuário já possui uma matrícula para esta turma");
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
            return await _turmas.ListarTurmas(pesquisa);
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

        public async Task<ApplicationUser> UsuarioComEmail(string email)
        {
            return await _usuarios.ComEmail(email);
        }

        public async Task<IEnumerable<ItemHistorico>> ListarHistorico(string applicationUserMatricula)
        {
            return await _historico.buscarHistorico(applicationUserMatricula);
        }

        public async Task<IEnumerable<Disciplina>> ListarDisciplinas()
        {
            return await _disciplinas.ListarDisciplinas();
        }
    }
}
