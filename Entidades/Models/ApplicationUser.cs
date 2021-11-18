using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public virtual ICollection<ItemHistorico> Historico { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }


    }
}
