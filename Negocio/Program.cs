using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Persistencia;
using System;

namespace Negocio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Back
            /*
            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            host.Run();
           

            string[] schwarzenegger = new String[1];
            Persistencia.Program.Main(schwarzenegger);


            Console.WriteLine("Back done!");
             */

            //Front
            Facade facade = new Facade();

            bool isMatriculado = facade.Matricular(1, "15111090");

            Console.WriteLine("Metodo matricular executado");

            if (isMatriculado)
            {
                Console.WriteLine("FUNCIONOU");
            }

            if (!isMatriculado)
            {
                Console.WriteLine("SAD NARUTO");
            }

            Console.WriteLine("Fim.");

        }

    }
}
