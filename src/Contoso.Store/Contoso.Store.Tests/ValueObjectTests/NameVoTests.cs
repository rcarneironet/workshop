using Contoso.Store.Domain.Contexts.ValueObjects;
using NUnit.Framework;

namespace Contoso.Store.Tests.ValueObjectTests
{
    public class NameVoTests
    {
        /*
         ctrl+R+T
        */

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NameVoTests_IsValid_ReturnTrue()
        {
            //ARRANGE
            var name = new NameVo("Ray", "Carneiro");

            //ASSERT
            Assert.AreEqual(true, name.IsValid);
        }

        [Test]
        public void NameVoTests_IsInvalid_ReturnFalse()
        {
            //ARRANGE
            var name = new NameVo("R", "Carneiro");

            //ASSERT
            Assert.AreEqual(true, name.Invalid);
        }
    }
}
