using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraEjercicio.Servicios
{
    internal class Corroborador
    {
        String posibles = ("0123456789,()/*+-");
        String posibles2 = ("0123456789,(/*+-");
        String posibles3 = ("0123456789,)/*+-");
        String posibles4 = ("0123456789(-");
        String posibles5 = ("0123456789)");
        String posibles6 = ("0123456789(");
        String posibles7 = ("(/*+-");
        String posibles8 = (")/*+-");
        String posibles9 = ("0123456789");
        String posibles10 = ("0123456789()");

        public String CorroborarContenido(String ecuacion)
        {
            String caracteresNoValidos = null;
            foreach (char c in ecuacion)
            {
                if (!posibles.Contains(c))
                {
                    caracteresNoValidos += c;
                }
            }
            if (caracteresNoValidos == null)
            {
                CorroborarParentesis(ecuacion);
            }
            else
            {
                Console.WriteLine("La corroboración de caracteres no pasó.");
            }
            return caracteresNoValidos;
        }

        public void CorroborarParentesis(String ecuacion)
        {
            int contador = 0;
            foreach (char c in ecuacion)
            {
                if (c == '(')
                {
                    contador += 1;
                }
                if (c == ')')
                {
                    contador -= 1;
                }
                if (contador < 0)
                {
                    break;
                }
            }
            if (contador != 0 || contador == -1)
            {
                Console.WriteLine("La corroboración de () no pasó.");
            }
            else
            {
                Console.WriteLine("La corroboración de () pasó.");
                Boolean corroborarEscritura = CorroborarEscritura(ecuacion);
                if (corroborarEscritura)
                {
                    Console.WriteLine("Entró al desglose");
                    Desglosador desglosador = new Desglosador();
                    desglosador.Desglosar(ecuacion);
                }
            }
        }

        public Boolean CorroborarEscritura(String ecuacion)
        {
            Boolean correcto = true;
            for (int i = 0; i < ecuacion.Length; i++)
            {
                if (i == 0)
                {
                    if (posibles4.Contains(ecuacion[i]))
                    {
                        Console.WriteLine($"{i} Corroborar indice 0 pasó");

                    }
                    else
                    {
                        Console.WriteLine($"{i} Corroborar indice 0 NO pasó");
                        correcto = false;
                    }
                }
                else if (i == ecuacion.Length - 1)
                {
                    if (posibles5.Contains(ecuacion[i]))
                    {
                        Console.WriteLine($"{i} Corroborar último indice pasó");

                    }
                    else
                    {
                        Console.WriteLine($"{i} Corroborar último indice NO pasó");
                        correcto = false;
                    }
                }
                else
                {
                    switch (ecuacion[i])
                    {
                        case '+':
                            if (posibles5.Contains(ecuacion[i - 1]) && posibles4.Contains(ecuacion[i + 1]))
                            {
                                Console.WriteLine($"{i} Corroborar + pasó");
                            }
                            else
                            {
                                Console.WriteLine($"{i} Corroborar + NO pasó");
                                correcto = false;
                            }
                            break;

                        case '-':
                            if (posibles10.Contains(ecuacion[i - 1]) && posibles6.Contains(ecuacion[i + 1]))
                            {
                                Console.WriteLine($"{i} Corroborar - pasó");
                            }
                            else
                            {
                                Console.WriteLine($"{i} Corroborar - NO pasó");
                                correcto = false;
                            }
                            break;

                        case '*':
                            if (posibles5.Contains(ecuacion[i - 1]) && posibles4.Contains(ecuacion[i + 1]))
                            {
                                Console.WriteLine($"{i} Corroborar * pasó");
                            }
                            else
                            {
                                Console.WriteLine($"{i} Corroborar * NO pasó");
                                correcto = false;
                            }
                            break;

                        case '/':
                            if (posibles5.Contains(ecuacion[i - 1]))
                            {
                                Console.WriteLine($"{i} Corroborar / pasó");
                            }
                            else
                            {
                                Console.WriteLine($"{i} Corroborar / NO pasó");
                                correcto = false;
                            }
                            break;

                        case '(':
                            if (posibles7.Contains(ecuacion[i - 1]) && posibles4.Contains(ecuacion[i + 1]))
                            {
                                Console.WriteLine($"{i} Corroborar ( pasó");
                            }
                            else
                            {
                                Console.WriteLine($"{i} Corroborar ( NO pasó");
                                correcto = false;
                            }
                            break;

                        case ')':
                            if (posibles5.Contains(ecuacion[i - 1]) && posibles8.Contains(ecuacion[i + 1]))
                            {
                                Console.WriteLine($"{i} Corroborar ) pasó");
                            }
                            else
                            {
                                Console.WriteLine($"{i} Corroborar ) NO pasó");
                                correcto = false;
                            }
                            break;

                        case '.':
                            if (posibles9.Contains(ecuacion[i - 1]) && posibles9.Contains(ecuacion[i + 1]))
                            {
                                Console.WriteLine($"{i} Corroborar , pasó");
                            }
                            else
                            {
                                Console.WriteLine($"{i} Corroborar , NO pasó");
                                correcto = false;
                            }
                            break;

                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                        case '7':
                        case '8':
                        case '9':
                            if (posibles2.Contains(ecuacion[i - 1]) && posibles3.Contains(ecuacion[i + 1]))
                            {
                                Console.WriteLine($"{i} Corroborar números pasó");
                            }
                            else
                            {
                                Console.WriteLine($"{i} Corroborar números NO pasó");
                                correcto = false;
                            }
                            break;

                        default:
                            break;
                    }
                }
                if (correcto == false)
                {
                    Console.WriteLine($"{i} La ecuación está mal escrita");
                    break;
                }
            }
            return correcto;
        }
    }
}

