using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(11)]
        [Display(Name = "Matrícula")]
        public string Matricula { get; set; }

        [MaxLength(40)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        public ICollection<ItemHistorico> Historico { get; set; }
        //public ICollection<Matricula> Matriculas { get; set; }


    }
}
