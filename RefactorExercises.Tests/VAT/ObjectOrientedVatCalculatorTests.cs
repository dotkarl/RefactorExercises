using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorExercises.VAT.Model;
using RefactorExercises.VAT.ObjectOriented;

namespace RefactorExercises.Tests.VAT
{
    [TestClass]
    public class ObjectOrientedVatCalculatorTests : VatCalculatorTestsTemplate
    {
        protected override decimal CalculateVat(Address address, Order order)
        {
            var calculator = new VatCalculator(address, order);
            return calculator.Vat();
        }
    }
}
