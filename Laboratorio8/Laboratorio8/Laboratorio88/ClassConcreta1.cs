namespace Laboratorio88
{
    internal class ClassConcreta1 : ClassAbstracta
    {
        protected override string tomarValor()
        {
            return "ClassConcreta1";
        }

        public override string prefixValor(string prefix)
        {
            return $"{prefix}ClassConcreta1";
        }
    }
}
