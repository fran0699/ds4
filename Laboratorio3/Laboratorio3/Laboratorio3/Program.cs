using System;

namespace Laboratorio3
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculosMatematicos calculo = new CalculosMatematicos();

            Console.Write("Introduce el primer número: ");
            calculo.primerNumero = Convert.ToInt32(Console.ReadLine());

            Console.Write("Introduce el segundo número: ");
            calculo.segundoNumero = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("El resultado de ({0}+{1})*({0}-{1}) es: {2}", calculo.primerNumero, calculo.segundoNumero, calculo.calcular());
        }
    }

    public class CalculosMatematicos
    {
        //Declarando variables de instancia en clase.
        public int primerNumero { get; set; }
        public int segundoNumero { get; set; }

        public double calcular()
        {
            //Utilizando variables de instancia dentro de metodos de la clase.
            return (primerNumero + segundoNumero) * (primerNumero - segundoNumero);
        }
    }

}