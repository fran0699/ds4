internal class Program
{
    private static void Main(string[] args)
    {
        double[] lados = new double[3];
        try 
        {
            Console.WriteLine("Determinemos el tipo de triángulo considerando sus lados.");
            int i = 0;
            while (i < 3)
            {
                Console.WriteLine($"Ingrese el lado {i + 1} del triángulo: ");
                lados[i] = Convert.ToDouble(Console.ReadLine());
                if (lados[i] <= 0)
                {
                    Console.WriteLine("Los lados del triángulo deben ser números positivos.");
                }
                else
                {
                    i++;
                }
            }
            if (lados[0] == lados[1] && lados[1] == lados[2])
            {
                Console.WriteLine("El triángulo es equilátero.");
            }
            else if (lados[0] == lados[1] || lados[1] == lados[2] || lados[0] == lados[2])
            {
                Console.WriteLine("El triángulo es isósceles.");
            }
            else
            {
                Console.WriteLine("El triángulo es escaleno.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Formato de número no válido");
            return;
        }
         catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error: {ex.Message}");
            return;
        }

    }
}