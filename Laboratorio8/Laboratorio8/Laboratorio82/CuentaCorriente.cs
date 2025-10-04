namespace Laboratorio82
{
    internal class CuentaCorriente : Cuenta
    {
        public CuentaCorriente(string printIdCuenta) : base(printIdCuenta)
        {
        }

        public override void CalcularIntereses()
        {
            System.Console.WriteLine(
                "CuentaCorriente.CalcularIntereses() efectuado para " +
                "la cuenta {0}", getIdCuenta());
        }

    }
}
