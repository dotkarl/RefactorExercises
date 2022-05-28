using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorExercises.VAT.Model;

namespace RefactorExercises.Tests.VAT
{
    public abstract class VatCalculatorTestsTemplate
    {
        protected abstract decimal CalculateVat(Address address, Order order);

        [TestMethod]
        public void GivenItalianAddress_WhenCalculatingVat_ReturnRateOf022()
        {
            //Arrange
            var address = new Address("it");
            var product = new Product("Couch", 1m, false);
            var order = new Order(product, 1);

            //Act
            var vat = CalculateVat(address, order);

            //Assert
            vat.Should().Be(0.22m);
        }

        [TestMethod]
        public void GivenJapaneseAddress_WhenCalculatingVat_ReturnRateOf008()
        {
            //Arrange
            var address = new Address("jp");
            var product = new Product("Couch", 1m, false);
            var order = new Order(product, 1);

            //Act
            var vat = CalculateVat(address, order);

            //Assert
            vat.Should().Be(0.08m);
        }

        [TestMethod]
        public void GivenGermanAddressAndNonFoodProduct_WhenCalculatingVat_ReturnRateOf02()
        {
            //Arrange
            var address = new Address("de");
            var product = new Product("Couch", 1m, false);
            var order = new Order(product, 1);

            //Act
            var vat = CalculateVat(address, order);

            //Assert
            vat.Should().Be(0.2m);
        }

        [TestMethod]
        public void GivenGermanAddressAndFoodProduct_WhenCalculatingVat_ReturnRateOf008()
        {
            //Arrange
            var address = new Address("de");
            var product = new Product("Carrot", 1m, true);
            var order = new Order(product, 1);

            //Act
            var vat = CalculateVat(address, order);

            //Assert
            vat.Should().Be(0.08m);
        }

        [TestMethod]
        public void GivenUsAddressAndStateCa_WhenCalculatingVat_ReturnRateOf01()
        {
            //Arrange
            var address = new UsAddress("ca");
            var product = new Product("Couch", 1m, false);
            var order = new Order(product, 1);

            //Act
            var vat = CalculateVat(address, order);

            //Assert
            vat.Should().Be(0.1m);
        }

        [TestMethod]
        public void GivenUsAddressAndStateMa_WhenCalculatingVat_ReturnRateOf00625()
        {
            //Arrange
            var address = new UsAddress("ma");
            var product = new Product("Couch", 1m, false);
            var order = new Order(product, 1);

            //Act
            var vat = CalculateVat(address, order);

            //Assert
            vat.Should().Be(0.0625m);
        }

        [TestMethod]
        public void GivenUsAddressAndStateNy_WhenCalculatingVat_ReturnRateOf0085()
        {
            //Arrange
            var address = new UsAddress("ny");
            var product = new Product("Couch", 1m, false);
            var order = new Order(product, 1);

            //Act
            var vat = CalculateVat(address, order);

            //Assert
            vat.Should().Be(0.085m);
        }
    }
}
