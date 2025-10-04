namespace Laboratorio84
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Empleado empleado = new Empleado();
            empleado.Nombre = "John Doe";
            Console.WriteLine($"Nombre del empleado: {empleado.Nombre}");

            CuentaBancaria cuenta = new CuentaBancaria();
            cuenta.Saldo = 100;
            Console.WriteLine($"El saldo del empleado: {cuenta.Saldo}");
            //probar despues con un saldo negativo, para ver la excepción

            Cobertura c = new Cobertura(5);
            Console.WriteLine($"Con una cobertura de: {c.Radio}");
        }
    }
}