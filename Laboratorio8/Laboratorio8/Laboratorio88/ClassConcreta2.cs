
namespace Laboratorio88
{
    internal class ClassConcreta2 : ClassAbstracta
    {
        protected override string tomarValor()
        {
            return "ClassConcreta2";
        }

        public override string prefixValor(string prefix)
        {
            return $"{prefix}ClassConcreta2";
        }
    }
}
