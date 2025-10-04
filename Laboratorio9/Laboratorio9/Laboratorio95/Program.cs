using System;
using System.Collections.Generic;

namespace Laboratorio95
{
    class Aleatorios
    {
        Random rnd = new Random();

        public int GenerarNumero(int min, int max)
        {
            return rnd.Next(min, max + 1);
        }

        public int[] GenerarArreglo(int cantidad, int min, int max)
        {
            int[] arreglo = new int[cantidad];
            for (int i = 0; i < cantidad; i++)
            {
                arreglo[i] = GenerarNumero(min, max);
            }
            return arreglo;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Aleatorios aleatorios = new Aleatorios();

            Console.Write("Número mínimo: ");
            int min = int.Parse(Console.ReadLine());

            Console.Write("Número máximo: ");
            int max = int.Parse(Console.ReadLine());

            Console.Write("Cantidad de números: ");
            int cantidad = int.Parse(Console.ReadLine());

            if (cantidad > (max - min + 1))
            {
                Console.WriteLine("No se pueden generar números sin repetir. El rango es muy pequeño.");
            }
            else
            {
                int[] arreglo = GenerarArregloNoRepetido(cantidad, min, max, aleatorios);

                Console.WriteLine("\nNúmeros aleatorios sin repetir:");
                for (int i = 0; i < arreglo.Length; i++)
                {
                    Console.Write(arreglo[i] + " ");
                }
                Console.WriteLine();
            }
        }

        static int[] GenerarArregloNoRepetido(int cantidad, int min, int max, Aleatorios aleatorios)
        {
            List<int> numeros = new List<int>();

            while (numeros.Count < cantidad)
            {
                int num = aleatorios.GenerarNumero(min, max);

                if (!numeros.Contains(num))
                {
                    numeros.Add(num);
                }
            }

            return numeros.ToArray();
        }
    }
}

