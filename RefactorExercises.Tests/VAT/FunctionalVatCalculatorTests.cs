using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorExercises.VAT.Functional;
using RefactorExercises.VAT.Model;

namespace RefactorExercises.Tests.VAT
{
    [TestClass]
    public class FunctionalVatCalculatorTests : VatCalculatorTestsTemplate
    {
        protected override decimal CalculateVat(Address address, Order order)
        {
            return VatCalculator.Vat(address, order);
        }
    }
}
