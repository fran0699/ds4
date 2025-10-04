namespace Laboratorio88
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ClassConcreta1 concreta1 = new ClassConcreta1();
            concreta1.printOut();
            Console.WriteLine(concreta1.prefixValor("ES_"));

            ClassConcreta2 concreta2 = new ClassConcreta2();
            concreta2.printOut();
            Console.WriteLine(concreta2.prefixValor("ES_"));
        }
    }
}