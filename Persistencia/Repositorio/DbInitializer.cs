using Entidades.Models;
using System;
using System.Linq;

namespace Persistencia.Repositorio
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            var user = context.ApplicationUser.FirstOrDefault();


            //// Look for any students.
            //if (context.Students.Any())
            //{
            //    return;   // DB has been seeded
            //}

            //var students = new Student[]
            //{
            //new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
            //new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
            //new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
            //new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
            //new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
            //new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
            //new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
            //new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            //};
            //foreach (Student s in students)
            //{
            //    context.Students.Add(s);
            //}
            //context.SaveChanges();

            var disciplinas = new Disciplina[]
            {
            new Disciplina{DisciplinaID=1, Codcred="4637B-04", Nome="Programação de Software Aplicado"},
            new Disciplina{DisciplinaID=2, Codcred="4647D-02", Nome="Microeconomics"},
            new Disciplina{DisciplinaID=3, Codcred="4657B-04", Nome="Macroeconomics"},
            new Disciplina{DisciplinaID=1045, Codcred="4667A-02", Nome="Calculus"},
            new Disciplina{DisciplinaID=3141, Codcred="4677R-06", Nome="Trigonometry"},
            new Disciplina{DisciplinaID=2021, Codcred="4687B-04", Nome="Composition"},
            new Disciplina{DisciplinaID=2042, Codcred="4697V-04", Nome="Literature"}
            };
            foreach (Disciplina d in disciplinas)
            {
                context.Disciplinas.Add(d);
            }
            context.SaveChanges();

            //var enrollments = new Matricula[]
            //{
            //new Matricula{StudentID=1,CourseID=1050,Nota=Grade.A},
            //new Matricula{StudentID=1,CourseID=4022,Nota=Grade.C},
            //new Matricula{StudentID=1,CourseID=4041,Nota=Grade.B},
            //new Matricula{StudentID=2,CourseID=1045,Nota=Grade.B},
            //new Matricula{StudentID=2,CourseID=3141,Nota=Grade.F},
            //new Matricula{StudentID=2,CourseID=2021,Nota=Grade.F},
            //new Matricula{StudentID=3,CourseID=1050},
            //new Matricula{StudentID=4,CourseID=1050},
            //new Matricula{StudentID=4,CourseID=4022,Nota=Grade.F},
            //new Matricula{StudentID=5,CourseID=4041,Nota=Grade.C},
            //new Matricula{StudentID=6,CourseID=1045},
            //new Matricula{StudentID=7,CourseID=3141,Nota=Grade.A},
            //};
            //foreach (Matricula e in enrollments)
            //{
            //    context.Enrollments.Add(e);
            //}
            //context.SaveChanges();

            var historico = new ItemHistorico[]
            {
            new ItemHistorico{ItemHistoricoID=1, DisciplinaID=1, Nota=7, AnoSemestre="2021-1"},
            new ItemHistorico{ItemHistoricoID=2, DisciplinaID=2, Nota=8, AnoSemestre="2021-1"},
            new ItemHistorico{ItemHistoricoID=3, DisciplinaID=3, Nota=8.5, AnoSemestre="2021-1"}
            };
            foreach (ItemHistorico h in historico)
            {
                context.Historico.Add(h);
            }
            context.SaveChanges();
        }
    }
}