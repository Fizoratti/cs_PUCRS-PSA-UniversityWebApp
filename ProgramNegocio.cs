using Entidades.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Persistencia;
using Persistencia.Repositorio;
using System;
using System.Linq;

namespace Negocio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Back

            /*
            
            Console.WriteLine("Back done!");
             */

            //Front
            /*
            Facade facade = new Facade();
            */


            SchoolContext db = new SchoolContext();

            ApplicationUser user = db.ApplicationUser.Where(x => x.Matricula.Contains("15111090")).Single();

            bool isAdded = Add(5);

            Console.WriteLine("Metodo matricular executado");

            if (isAdded)
            {
                Console.WriteLine("FUNCIONOU");
            }

            if (!isAdded)
            {
                Console.WriteLine("SAD NARUTO");
            }

            Console.WriteLine("Fim.");

        }

        public static bool AddMatricula(int turmaID)
        {
            SchoolContext db = new SchoolContext();

            Matricula matricula = new Matricula
            {
                TurmaID = turmaID,
            };

            db.Matriculas.Add(matricula);
            db.SaveChanges();
            return true;
        }

    }
}