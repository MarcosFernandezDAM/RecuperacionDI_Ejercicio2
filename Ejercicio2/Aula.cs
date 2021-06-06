using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    class Aula
    {
        private int[,] tablaNotas = new int[4, 12];

        public int longitudTabla(int i)
        {
            if (i == 0 || i == 1)
            {
                return tablaNotas.GetLength(i);
            }
            else
            {
                return -1;
            }
        }

        public int this[int i, int j]
        {
            set
            {
                tablaNotas[i, j] = value;
            }
            get
            {
                return tablaNotas[i, j];
            }
        }

        public string[] alumnos = { "Marcos", "Juanjo", "Jan", "Kieran", "Stefan", "Josema", "Mario", "Jorge", "Lucas", "Yanick", "Luis", "Joao" };
        public string this[int i]
        {
            set
            {
                alumnos[i] = value;
            }
            get
            {
                return alumnos[i];
            }
        }

        public enum asignaturas
        {
            Programación,
            Bases,
            Sistemas,
            Redes
        }

        public void rellenarTabla()
        {
            Random random = new Random();
            for (int i = 0; i < this.tablaNotas.GetLength(0); i++)
            {
                for (int j = 0; j < this.tablaNotas.GetLength(1); j++)
                {
                    this.tablaNotas[i, j] = calcularNota(random);
                }
            }
        }

        static int calcularNota(Random random)
        {
            int prob = random.Next(1, 101);

            switch (prob)
            {
                case int n when n <= 5:
                    return 0;

                case int n when n <= 10:
                    return 1;

                case int n when n <= 15:
                    return 2;

                case int n when n <= 25:
                    return 3;

                case int n when n <= 40:
                    return 4;

                case int n when n <= 55:
                    return 5;

                case int n when n <= 70:
                    return 6;

                case int n when n <= 80:
                    return 7;

                case int n when n <= 90:
                    return 8;

                case int n when n <= 95:
                    return 9;

                case int n when n <= 100:
                    return 10;

                default:
                    return 0;
            }
        }

        public double calcularMediaTotal()
        {
            double suma = 0;
            double media;
            for (int i = 0; i < this.tablaNotas.GetLength(0); i++)
            {
                for (int j = 0; j < this.tablaNotas.GetLength(1); j++)
                {
                    suma += this.tablaNotas[i, j];
                }
            }

            media = suma / (this.tablaNotas.Length);
            return media;
        }

        public double calcularMediaAlumno(int numAlumno)
        {
            double suma = 0;
            double media;
            for (int i = 0; i < this.tablaNotas.GetLength(0); i++)
            {
                suma += this.tablaNotas[i, numAlumno - 1];
            }

            media = suma / this.tablaNotas.GetLength(0);
            return media;
        }

        public double calcularMediaAsignatura(int numAsignatura)
        {
            double suma = 0;
            double media;
            for (int i = 0; i < this.tablaNotas.GetLength(1); i++)
            {
                suma += this.tablaNotas[numAsignatura - 1, i];
            }

            media = suma / this.tablaNotas.GetLength(1);
            return media;
        }

        public int[] verNotasAlumno(int numAlumno)
        {
            int[] notasAlumno = new int[this.tablaNotas.GetLength(0)];
            for (int i = 0; i < this.tablaNotas.GetLength(0); i++)
            {
                notasAlumno[i] = this.tablaNotas[i, numAlumno - 1];
            }

            return notasAlumno;
        }

        public int[] verNotasAsignatura(int numAsignatura)
        {
            int[] notasAsignatura = new int[this.tablaNotas.GetLength(1)];
            for (int i = 0; i < this.tablaNotas.GetLength(1); i++)
            {
                notasAsignatura[i] = this.tablaNotas[numAsignatura - 1, i];
            }
            return notasAsignatura;
        }

        public int[] notaMaxMinAlumno(ref int numAlumno)
        {
            int[] notasAlumno = new int[4];
            int menor = 10;
            int mayor = 0;

            for (int i = 0; i < this.tablaNotas.GetLength(0); i++)
            {
                notasAlumno[i] = this.tablaNotas[i, numAlumno - 1];
            }

            for (int i = 0; i < notasAlumno.Length; i++)
            {
                if (notasAlumno[i] < menor)
                {
                    menor = notasAlumno[i];
                }
                if (notasAlumno[i] > mayor)
                {
                    mayor = notasAlumno[i];
                }
            }
            int[] notas = { menor, mayor };
            return notas;
        }

        public int[,] tAprobados()
        {
            int asigAprobadas = 0;
            int numColumnas = 0;
            List<int> indices = new List<int>();
            int[,] soloAprobados = null;
            for (int i = 0; i < tablaNotas.GetLength(1); i++)
            {
                asigAprobadas = 0;
                for (int j = 0; j < tablaNotas.GetLength(0); j++)
                {
                    if (tablaNotas[j, i] >= 5)
                    {
                        asigAprobadas++;

                    }
                }

                if (asigAprobadas >= tablaNotas.GetLength(0))
                {
                    numColumnas++;
                    indices.Add(i);
                }

            }

            soloAprobados = new int[tablaNotas.GetLength(0), numColumnas];

            for (int i = 0; i < soloAprobados.GetLength(0); i++)
            {
                for (int j = 0; j < soloAprobados.GetLength(1); j++)
                {

                    soloAprobados[i, j] = tablaNotas[i, indices[j]];
                }
            }
            return soloAprobados;
        }
    }
}
