using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Aula aula = new Aula();
            aula.rellenarTabla();
            int opcion = 0;
            int alumno;
            int asignatura;
            do
            {
                Console.WriteLine("Selecciona una opcion:");
                Console.WriteLine("1. Calcular la media de notas de toda la tabla");
                Console.WriteLine("2. Media de un alumno");
                Console.WriteLine("3. Media de una asignatura");
                Console.WriteLine("4. Visualizar notas de un alumno");
                Console.WriteLine("5. Visualizar notas de una asignatura");
                Console.WriteLine("6. Nota máxima y mínima de un alumno");
                Console.WriteLine("7. Tabla solo de aprobados");
                Console.WriteLine("8. Visualizar tabla completa");
                Console.WriteLine("9. Salir del programa");
                opcion = pedirInt();
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("La media de todas las notas es: {0:N2}", aula.calcularMediaTotal());
                        Console.WriteLine();
                        Console.WriteLine("Pulsa ENTER para continuar");
                        Console.ReadLine();
                        break;

                    case 2:
                        do
                        {
                            Console.WriteLine("Selecciona un alumno");
                            alumno = pedirInt();
                        } while (alumno <= 0 || alumno > 12);
                        Console.WriteLine("La media de las notas de {0} es : {1:N2}", aula[alumno - 1], aula.calcularMediaAlumno(alumno));
                        Console.WriteLine();
                        Console.WriteLine("Pulsa ENTER para continuar");
                        Console.ReadLine();
                        break;

                    case 3:
                        do
                        {
                            Console.WriteLine("Selecciona una asignatura");
                            asignatura = pedirInt();
                        } while (asignatura <= 0 || asignatura > 4);
                        Console.WriteLine("La media de las notas es: {0:N2}", aula.calcularMediaAsignatura(asignatura));
                        Console.WriteLine();
                        Console.WriteLine("Pulsa ENTER para continuar");
                        Console.ReadLine();
                        break;

                    case 4:
                        do
                        {
                            Console.WriteLine("Selecciona un alumno");
                            alumno = pedirInt();
                        } while (alumno <= 0 || alumno>12);
                        int[] notasAlumno = aula.verNotasAlumno(alumno);
                        Console.WriteLine("Las notas de {0} son: ", aula[alumno - 1]);
                        for(int i=0; i < notasAlumno.Length; i++)
                        {
                            Console.WriteLine("{0}\t", notasAlumno[i]);
                        }
                        Console.Write("\n");
                        Console.WriteLine();
                        Console.WriteLine("Pulsa ENTER para continuar");
                        Console.ReadLine();
                        break;

                    case 5:
                        do
                        {
                            Console.WriteLine("Selecciona una asignatura");
                            asignatura = pedirInt();

                        } while (asignatura <= 0 || asignatura>4);
                        int[] notasAsignatura = aula.verNotasAsignatura(asignatura);
                        Console.WriteLine("Las notas son: ");
                        for(int i=0; i < notasAsignatura.Length; i++)
                        {
                            Console.WriteLine("{0} :\t", aula[i]);
                            Console.WriteLine("{0}\n", notasAsignatura[i]);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Pulsa ENTER para continuar");
                        Console.ReadLine();
                        break;

                    case 6:
                        do
                        {
                            Console.WriteLine("Selecciona un alumno");
                            alumno = pedirInt();
                        } while (alumno <= 0 || alumno>12);
                        int[] notaMaxMin = aula.notaMaxMinAlumno(ref alumno);
                        Console.WriteLine("La nota más baja de {0} es: {1}", aula[alumno-1], notaMaxMin[0]);
                        Console.WriteLine("La nota más alta de {0} es: {1}", aula[alumno-1], notaMaxMin[1]);
                        Console.WriteLine();
                        Console.WriteLine("Pulsa ENTER para continuar");
                        Console.ReadLine();
                        break;

                    case 7:
                        for (int i=0; i<aula.tAprobados().GetLength(0); i++)
                        {
                            for (int j=0; j<aula.tAprobados().GetLength(1);j++)
                            {
                                Console.Write("{0,3}",aula.tAprobados()[i, j]); 
                            }
                            Console.WriteLine();
                        }

                        //Console.WriteLine(aula.tAprobados().GetLength(1));
                        break;

                    case 8:
                        for(int i=0; i<12; i++)
                        {
                            if (i == 0)
                            {
                                Console.Write(String.Format("{0,20}", aula[i]));
                            }else if (i == 11)
                            {
                                Console.Write(String.Format("{0,12}", aula[i]));
                            }
                            else
                            {
                                Console.Write(String.Format("{0,8}", aula[i]));
                            }
                        }
                        Console.WriteLine();

                        Aula.asignaturas asig;
                        for (int i=0; i < aula.longitudTabla(0); i++)
                        {
                            asig = (Aula.asignaturas)i;
                            Console.Write(String.Format("{0, -12}", asig));

                            for(int j=0; j < aula.longitudTabla(1); j++)
                            {
                                if (j == 11)
                                {
                                    Console.Write(String.Format("{0,10}",aula[i,j]));
                                }
                                else
                                {
                                    Console.Write(String.Format("{0,8}",aula[i,j]));
                                }
                            }
                            Console.WriteLine("\n");
                        }
                        break;

                    case 9:
                        Console.WriteLine("Saliendo del programa");
                        break;

                    default:
                        Console.WriteLine("Error, opción no válida");
                        break;
                }
            } while (opcion != 9);
        }

        public static int pedirInt()
        {
            int num = 0;
            do
            {
                try
                {
                    num = Convert.ToInt32(Console.ReadLine());
                    return num;
                }
                catch (System.OverflowException)
                {
                    Console.WriteLine("Error, valor no válido, introduce otro");
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Error, valor no válido, introduce otro");
                }
            } while (num == 0);
            return 0;
        }
    }
}
