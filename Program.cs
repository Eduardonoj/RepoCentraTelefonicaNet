using System;
using System.Collections.Generic;
using CentralTelefonica.Entidades;
using CentralTelefonica.App;
using CentralTelefonica.util;
namespace CentralTelefonica
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime fecha = DateTime. Now;
            Console.WriteLine($"fecha: {fecha}");
            Console.WriteLine($"Día: {fecha.DayOfWeek}");
            Console.WriteLine($"Hora: {fecha.Hour}");
            Console.WriteLine($"Día: {fecha.Minute}");
            MenuPrincipal menu = new MenuPrincipal();
            menu.MostrarMenu();
        }
        
    }
}
