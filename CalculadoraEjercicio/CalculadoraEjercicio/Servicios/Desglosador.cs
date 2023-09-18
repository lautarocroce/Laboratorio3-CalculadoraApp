using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraEjercicio.Servicios
{
    internal class Desglosador
    {
        public void Desglosar(String ecuacion)
        {
            Operador operador = new Operador();
            int conteo = ecuacion.Count(c => c == '(');
            String ecuacionAux;
            String ecuacionPorcion;
            String ecuacionPorcionAux;
            
            Console.WriteLine($"Ecuación a resolver: {ecuacion}");
            int paso = 0;

            for (int i = 0; i <= conteo; i++)
            {
                if (ecuacion.Contains('('))
                {
                    ecuacionAux = ecuacion.Substring(0, ecuacion.IndexOf(')'));
                    ecuacionPorcion = ecuacionAux.Substring(ecuacionAux.LastIndexOf('(')+1);
                    ecuacionPorcionAux = ecuacionPorcion;
                }
                else
                {
                    ecuacionAux = ecuacion;
                    ecuacionPorcion = ecuacionAux;
                    ecuacionPorcionAux = ecuacionPorcion;
                }

                if (ecuacionPorcion.Contains('/'))
                {
                    String division = operador.Dividir(ecuacionPorcion);
                    ecuacionPorcion = division;
                    if (ecuacion.Contains('('))
                    {
                        paso++;
                        Console.WriteLine(ecuacion.Replace($"({ecuacionPorcionAux})", $"Paso {paso}: {ecuacionPorcion}"));
                    }
                    else
                    {
                        paso++;
                        Console.WriteLine(ecuacion.Replace($"{ecuacionPorcionAux}", $"Paso {paso}: {ecuacionPorcion}"));
                    }
                }
                if (ecuacionPorcion.Contains('*'))
                {
                    String multiplicacion = operador.Multiplicar(ecuacionPorcion);
                    ecuacionPorcion = multiplicacion;
                    if (ecuacion.Contains('('))
                    {
                        paso++;
                        Console.WriteLine(ecuacion.Replace($"({ecuacionPorcionAux})", $"Paso {paso}: {ecuacionPorcion}"));
                    }
                    else
                    {
                        paso++;
                        Console.WriteLine(ecuacion.Replace($"{ecuacionPorcionAux}", $"Paso {paso}: {ecuacionPorcion}"));
                    }
                }
                if (ecuacionPorcion.Contains('-'))
                {
                    String resta = operador.Restar(ecuacionPorcion);
                    ecuacionPorcion = resta;
                    if (ecuacion.Contains('('))
                    {
                        paso++;
                        Console.WriteLine(ecuacion.Replace($"({ecuacionPorcionAux})", $"Paso {paso}: {ecuacionPorcion}"));
                    }
                    else
                    {
                        paso++;
                        Console.WriteLine(ecuacion.Replace($"{ecuacionPorcionAux}", $"Paso {paso}: {ecuacionPorcion}"));
                    }
                }
                if (ecuacionPorcion.Contains('+'))
                {
                    String suma = operador.Sumar(ecuacionPorcion);
                    ecuacionPorcion = suma;
                    if (ecuacion.Contains('('))
                    {
                        paso++;
                        Console.WriteLine(ecuacion.Replace($"({ecuacionPorcionAux})", $"Paso {paso}: {ecuacionPorcion}"));
                    }
                    else
                    {
                        paso++;
                        Console.WriteLine(ecuacion.Replace($"{ecuacionPorcionAux}", $"Paso {paso}: {ecuacionPorcion}"));
                    }
                }
                if(ecuacion.Contains('('))
                {
                    ecuacion = ecuacion.Replace($"({ecuacionPorcionAux})", ecuacionPorcion);
                }
                else
                {
                    ecuacion = ecuacion.Replace($"{ecuacionPorcionAux}", ecuacionPorcion);
                }
            }
            Console.WriteLine($"Resultado: {ecuacion}");
        }
    }
}
