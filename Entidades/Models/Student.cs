using System;
using System.Collections.Generic;

namespace Entidades.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public string Email { get; set; }

        public ICollection<Matricula> Enrollments { get; set; }
    }
}