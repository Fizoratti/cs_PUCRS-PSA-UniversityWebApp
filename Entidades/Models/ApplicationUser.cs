using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Entidades.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(11)]
        [Display(Name = "Matrícula")]
        [PersonalData]
        public string Matricula { get; set; }

        [MaxLength(40)]
        [Display(Name = "Nome")]
        [PersonalData]
        public string Nome { get; set; }

        [Display(Name = "Coordenador")]
        [PersonalData]
        public bool Admin { get; set; }

        public virtual ICollection<ItemHistorico> Historico { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
        public ICollection<string> Horarios
        {
            get
            {
                var _horarios = new List<string>();
                foreach (Matricula matricula in Matriculas)
                {
                    if (matricula.Turma.Horario.Length < 3)
                    {
                        _horarios.Add(matricula.Turma.Horario);
                    }
                    else
                    {
                        var primeiroHorario = "";
                        var segundoHorario = "";
                        var teste = matricula.Turma.Horario.ToCharArray();
                        foreach (char letra in teste)
                        {
                            if (primeiroHorario.Length < 3)
                            {
                                primeiroHorario = primeiroHorario + letra;
                            }
                            else
                            {
                                segundoHorario = segundoHorario + letra;
                            }
                        }
                        _horarios.Add(primeiroHorario);
                        _horarios.Add(segundoHorario);
                    }
                }
                return _horarios;
            }
        }


        public ApplicationUser()
        {
            Historico = new Collection<ItemHistorico>();
            Matriculas = new Collection<Matricula>();
        }

        public bool ContemMatriculaParaDisciplina(Turma turma)
        {
            return Matriculas.Any(p => p.Turma.DisciplinaID == turma.DisciplinaID);
        }

        public bool VerificaSeConflitaHorario(Turma turma)
        {
            var primeiroHorario = "";
            var segundoHorario = "";
            if (turma.Horario.Length <= 3)
            {
                primeiroHorario = turma.Horario;
            }
            else
            {
                var teste = turma.Horario.ToCharArray();
                foreach (char letra in teste)
                {
                    if (primeiroHorario.Length < 3)
                    {
                        primeiroHorario = primeiroHorario + letra;
                    }
                    else
                    {
                        segundoHorario = segundoHorario + letra;
                    }
                }
            }
            return Horarios.Contains(primeiroHorario) || Horarios.Contains(segundoHorario);
        }
    }
}
