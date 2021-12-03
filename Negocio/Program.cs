using Entidades.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Negocio.DAO;
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
            
            //Facade facade = new Facade();
            


            SchoolContext db = new SchoolContext();

            ApplicationUser user = db.ApplicationUser.Where(x => x.Matricula.Contains("15111090")).Single();

            //DAODisciplina _disciplinas = new DAODisciplinaEF();

            //var d = _disciplinas.buscarDiciplinaPorCodCred("4637B-04");

            //var d = _disciplinas.visualizarDisciplinas();

            //Console.WriteLine(d);

            //DAOMatriculas _matriculas = new DAOMatriculasEF();

            //facade.Matricular(5, "15111090");

            Console.WriteLine("Metodo matricular executado");

            //if (isAdded)
            //{
            //    Console.WriteLine("FUNCIONOU");
            //}

            //if (!isAdded)
            //{
            //    Console.WriteLine("SAD NARUTO");
            //}

            ;

            //foreach (Matricula m in facade.Listar("12b0a417-67f2-4eb3-abdc-61c0078e128a"))
            //{
            //    Console.WriteLine(m.ToString());
            //}

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