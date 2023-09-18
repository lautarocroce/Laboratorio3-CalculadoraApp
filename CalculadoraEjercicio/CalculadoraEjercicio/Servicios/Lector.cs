using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CalculadoraEjercicio.Servicios
{
    internal class Lector
    {
        public void Leer()
        {
            Corroborador corroborador = new Corroborador();
            Boolean seguir = true;
            while (seguir)
            {
                Console.WriteLine("Ingrese la ecuación a resolver: ");
                String ecuacion = Console.ReadLine();
                String caracteresNoValidos = corroborador.CorroborarContenido(ecuacion);
                if (!(caracteresNoValidos == null))
                {
                    Console.WriteLine($"Los siguientes caracteres ingresados no son válidos: {caracteresNoValidos}");
                }
                Console.WriteLine($"¿Desea resolver otra ecuación?");
                Console.WriteLine($"Cualquier tecla para continuar.");
                Console.WriteLine($"S - Salir.");
                String opcion = Console.ReadLine();
                if (opcion == "S" || opcion == "s")
                {
                    seguir = false;
                    Console.WriteLine($"Adios.");
                }
            }
        }
    }
}
