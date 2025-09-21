using System;

namespace Laboratorio31
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculosMatematicos calculo = new CalculosMatematicos();

            Console.Write("Introduzca el radio del círculo: ");
            calculo.radio = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("El area del círculo con radio {0} es: {1}", calculo.radio, calculo.calculoArea());
        }
    }

    public class CalculosMatematicos
    {
        public double radio { get; set; }

        public double calculoArea()
        {
            double pi = 3.1416;
            return pi*(radio*radio);
        }
    }

}