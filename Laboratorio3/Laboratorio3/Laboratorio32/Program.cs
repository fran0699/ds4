using System;

namespace Laboratorio32
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculosMatematicos calculo = new CalculosMatematicos();

            Console.Write("Introduce la base del rectángulo: ");
            calculo.baseR = Convert.ToInt32(Console.ReadLine());

            Console.Write("Introduce la altura del rectángulo: ");
            calculo.altura = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("El perímetro del rectángulo con base {0} y altura {1} es: {2}", calculo.baseR, calculo.altura, calculo.calcular());
        }
    }

    public class CalculosMatematicos
    {
        public int baseR { get; set; }
        public int altura { get; set; }

        public double calcular()
        {
            return (baseR*2) + (altura*2);
        }
    }

}