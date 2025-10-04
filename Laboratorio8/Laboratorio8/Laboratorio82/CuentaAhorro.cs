namespace Laboratorio82
{
    internal class CuentaAhorro : Cuenta
    {
        public CuentaAhorro(string printIdCuenta) : base(printIdCuenta)
        {
        }

        public override void CalcularIntereses()
        {
            System.Console.WriteLine(
                "CuentaAhorro.CalcularIntereses() efectuado para " +
                "la cuenta {0}", getIdCuenta());
        }
    }
}
