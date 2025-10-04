using System;

namespace Laboratorio94
{
    class Aleatorios
    {
        private Random rnd;

        public Aleatorios()
        {
            rnd = new Random();
        }

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
        public static void Main(string[] args)
        {
            Aleatorios aleatorios = new Aleatorios();

            // Generar un número entre 2 números
            int num = aleatorios.GenerarNumero(1, 10);
            Console.WriteLine("Número aleatorio entre 1 y 10: " + num);

            // Generar un arreglo de números
            int[] arreglo = aleatorios.GenerarArreglo(5, 1, 10);
            Console.WriteLine("Arreglo aleatorio entre 1 y 10:");
            foreach (int n in arreglo)
                Console.Write(n + " ");
            Console.WriteLine();
        }
    }
}
