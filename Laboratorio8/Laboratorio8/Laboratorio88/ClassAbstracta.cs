namespace Laboratorio88
{
    abstract class ClassAbstracta
    {
        //Se fuerza la herencia de la clase para definir estos métodos
        abstract protected string tomarValor();
        abstract public string prefixValor(string prefix);

        // Método común
        public void printOut()
        {
            Console.WriteLine(tomarValor());  // Corregí: tonarValor → tomarValor
        }
    }
}
