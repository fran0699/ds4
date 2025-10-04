namespace Laboratorio82
{
    internal class Cuenta
    {
        private string idCuenta;

        public Cuenta(string printIdCuenta)
        {
            this.idCuenta = printIdCuenta;
            System.Console.WriteLine(
                "Constructor Clase Base para cuenta {0}", printIdCuenta);
        }

        public virtual void CalcularIntereses()
        {
            System.Console.WriteLine(
                "Cuenta.CalcularIntereses() efectuado para la cuenta {0}",
                this.idCuenta);
        }

        public string getIdCuenta()
        {
            return this.idCuenta;
        }
    }
}
