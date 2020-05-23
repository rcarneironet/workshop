using Contoso.Store.Domain.Contexts.ValueObjects;
using NUnit.Framework;

namespace Contoso.Store.Tests.ValueObjectTests
{
    public class CpfVoTests
    {
        private CpfVo _cpfValido;
        private CpfVo _cpfInvalido;

        /*
         * Curso: Mosh Hamadami (Udemy)
         * Cenarios de testes e implementação unitaria
         * Convenção dos testes: NomeDaEntidade_Intencao_Retorno
         */

        [SetUp]
        public void Setup()
        {
            _cpfValido = new CpfVo("88041300081");
            _cpfInvalido = new CpfVo("12345678900");
        }

        [Test]
        public void CpfVoTests_IsValid_ReturnTrue()
        {
            Assert.AreEqual(true, _cpfValido.IsValid);
        }

        [Test]
        public void CpfVoTests_IsInvalid_ReturnFalse()
        {
            Assert.AreEqual(true, _cpfInvalido.Invalid);
        }
    }
}
