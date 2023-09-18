using CalculadoraEjercicio.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraEjercicio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lector lector = new Lector();   
            lector.Leer();
        }
    }
}
