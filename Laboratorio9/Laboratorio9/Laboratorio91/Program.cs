using System;

namespace Laboratorio81
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Escriba el precio del producto");
            double precio = Convert.ToDouble(Console.ReadLine());
            try
            {
                if (precio < 0)
                {
                    throw new ArgumentOutOfRangeException("El precio no puede ser negativo");
                }
                else
                {
                    Console.WriteLine("Introduzca el método de pago (1: Efectivo, 2: Tarjeta)");
                    int metodoPago = Convert.ToInt32(Console.ReadLine());
                    while (metodoPago != 1 && metodoPago != 2)
                    {
                        Console.WriteLine("Método de pago no válido. Introduzca 1 para Efectivo o 2 para Tarjeta.");
                        metodoPago = Convert.ToInt32(Console.ReadLine());
                    }
                    if (metodoPago == 1)
                    {
                        Console.WriteLine("Introduzca el efectivo");
                        Console.WriteLine("Pago con efectivo realizado");
                    }
                    else
                    {
                        Console.WriteLine("Introduzca el número de tarjeta");
                        while (true)
                        {
                            string? numeroTarjeta = Console.ReadLine();
                            if (!string.IsNullOrEmpty(numeroTarjeta) && numeroTarjeta.Length == 16 && long.TryParse(numeroTarjeta, out _))
                            {
                                Console.WriteLine("Pago con tarjeta realizado");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Número de tarjeta no válido. Debe tener 16 dígitos. Inténtelo de nuevo.");
                            }
                        }
                    }

                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato de número no válido");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        }
    }
}