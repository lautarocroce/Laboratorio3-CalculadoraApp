using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraEjercicio.Servicios
{

    internal class Operador
    {
        String numeros = "0123456789,-";
        String signos = "+*/";
        public String Dividir(String ecuacion)
        {
            while (ecuacion.Contains('/'))
            {
                if (ecuacion.Contains('/'))
                {
                    String numero1 = null;
                    String numero2 = null;

                    for (int i = ecuacion.IndexOf('/') - 1; i >= 0; i--)
                    {
                        if (numeros.Contains(ecuacion[i]) || (ecuacion[i - 1] == '-' && !numeros.Contains(ecuacion[i - 2])))
                        {
                            numero1 += ecuacion[i];
                        }
                        if (signos.Contains(ecuacion[i]))
                        {
                            break;
                        }
                        if (numero1.Length > 1)
                        {
                            if (numero1.Substring(1).Contains('-'))
                            {
                                numero1 = numero1.Substring(0, numero1.IndexOf("-"));
                                break;
                            }
                        }
                    }
                    char[] caracteres = numero1.ToCharArray();
                    Array.Reverse(caracteres);
                    numero1 = new string(caracteres);

                    for (int i = ecuacion.IndexOf('/') + 1; i < ecuacion.Length; i++)
                    {
                        if (numeros.Contains(ecuacion[i]))
                        {
                            numero2 += ecuacion[i];
                        }
                        if (signos.Contains(ecuacion[i]))
                        {
                            break;
                        }

                    }
                    double numero2D = double.Parse(numero2);
                    if (numero2D != 0)
                    {
                        double resultado = double.Parse(numero1) / numero2D;
                        ecuacion = ecuacion.Replace($"{numero1}/{numero2}", resultado.ToString());

                    }
                    else
                    {
                        Console.WriteLine($"Error. No se puede dividir por 0");
                        Environment.Exit(0);
                    }
                }
            }
            return ecuacion;
        }
        public String Restar(String ecuacion)
        {
            int contador = 0;
            while (ecuacion.Contains('-') && ecuacion.LastIndexOf('-') != 0 && numeros.IndexOf(ecuacion[ecuacion.LastIndexOf('-') - 1]) != -1 && contador < 5)
            {
                String numero1 = "";
                String numero2 = null;

                for (int i = ecuacion.LastIndexOf('-') - 1; i >= 0; i--)
                {
                    if (numero1.IndexOf('-') == 0)
                    {
                        numero2 = "-";
                        numero1 = "";
                    }
                    if (numero1.Length > 1)
                    {
                        if (numero1.Substring(1).Contains('-'))
                        {
                            numero1 = numero1.Substring(0,numero1.IndexOf("-"));
                            break;
                        }
                    }


                    if (numeros.Contains(ecuacion[i]))
                    {
                        numero1 += ecuacion[i];
                    }
                    if (signos.Contains(ecuacion[i]))
                    {
                        break;
                    }
                }

                for (int i = ecuacion.LastIndexOf('-') + 1; i < ecuacion.Length; i++)
                {
                    if (numeros.Contains(ecuacion[i]))
                    {
                        numero2 += ecuacion[i];
                    }
                    if (signos.Contains(ecuacion[i]))
                    {
                        break;
                    }
                }
                char[] caracteres = numero1.ToCharArray();
                Array.Reverse(caracteres);
                numero1 = new string(caracteres);
                double cero = 0;
                double resultado = 0;
                if (double.TryParse(numero1, out cero))
                {
                    resultado = double.Parse(numero1)-double.Parse(numero2);
                    ecuacion = ecuacion.Replace($"{numero1}-{numero2}", resultado.ToString());
                }
                else
                {
                    numero1 = "0";
                    resultado = double.Parse(numero1) - double.Parse(numero2);
                    ecuacion = ecuacion.Replace($"--{numero2}", resultado.ToString());
                }

                contador++;
            }
            return ecuacion;
        }
        public String Multiplicar(String ecuacion)
        {
            while (ecuacion.Contains('*'))
            {
                String numero1 = null;
                String numero2 = null;

                for (int i = ecuacion.IndexOf('*') - 1; i >= 0; i--)
                {
                    
                    if (numeros.Contains(ecuacion[i]))
                    {
                        numero1 += ecuacion[i];
                    }
                    if (signos.Contains(ecuacion[i]))
                    {
                        break;
                    }
                    if (numero1.Length > 1)
                    {
                        if (numero1.Substring(1).Contains('-'))
                        {
                            numero1 = numero1.Substring(0, numero1.IndexOf("-"));
                            break;
                        }
                    }

                }
                char[] caracteres = numero1.ToCharArray();
                Array.Reverse(caracteres);
                numero1 = new string(caracteres);

                for (int i = ecuacion.IndexOf('*') + 1; i < ecuacion.Length; i++)
                {
                    if (numeros.Contains(ecuacion[i]))
                    {
                        numero2 += ecuacion[i];
                    }
                    if (signos.Contains(ecuacion[i]))
                    {
                        break;
                    }
                }
                double resultado = double.Parse(numero1) * double.Parse(numero2);
                ecuacion = ecuacion.Replace($"{numero1}*{numero2}", resultado.ToString());
            }
            return ecuacion;
        }
        public String Sumar(String ecuacion)
        {
            while (ecuacion.Contains('+'))
            {
                String numero1 = null;
                String numero2 = null;

                for (int i = ecuacion.IndexOf('+') - 1; i >= 0; i--)
                {
                    if (numeros.Contains(ecuacion[i]))
                    {
                        numero1 += ecuacion[i];
                    }
                    if (signos.Contains(ecuacion[i]))
                    {
                        break;
                    }

                }
                char[] caracteres = numero1.ToCharArray();
                Array.Reverse(caracteres);
                numero1 = new string(caracteres);

                for (int i = ecuacion.IndexOf('+') + 1; i < ecuacion.Length; i++)
                {
                    if (numeros.Contains(ecuacion[i]))
                    {
                        numero2 += ecuacion[i];
                    }
                    if (signos.Contains(ecuacion[i]))
                    {
                        break;
                    }
                }
                double resultado = double.Parse(numero1) + double.Parse(numero2);
                ecuacion = ecuacion.Replace($"{numero1}+{numero2}", resultado.ToString());
            }
            return ecuacion;
        }
    }
}
