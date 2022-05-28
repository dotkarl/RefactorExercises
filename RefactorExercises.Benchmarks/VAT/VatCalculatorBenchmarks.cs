using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using RefactorExercises.VAT.Model;
using System.Collections.Generic;
using ObjectOrientedVatCalculator = RefactorExercises.VAT.ObjectOriented.VatCalculator;
using FunctionalVatCalculator = RefactorExercises.VAT.Functional.VatCalculator;

namespace RefactorExercises.Benchmarks.VAT
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class VatCalculatorBenchmarks
    {
        private readonly List<(Address address, Order order)> _values;

        public VatCalculatorBenchmarks()
        {
            var nonFoodProduct = new Product("Couch", 1m, false);
            var foodProduct = new Product("Carrot", 1m, true);
            _values = new List<(Address address, Order order)>
            {
                (new Address("it"), new Order(nonFoodProduct, 1)),
                (new Address("jp"), new Order(nonFoodProduct, 1)),
                (new Address("de"), new Order(nonFoodProduct, 1)),
                (new Address("de"), new Order(foodProduct, 1)),
                (new UsAddress("ca"), new Order(nonFoodProduct, 1)),
                (new UsAddress("ma"), new Order(nonFoodProduct, 1)),
                (new UsAddress("ny"), new Order(nonFoodProduct, 1)),
            };
        }

        [Benchmark(Baseline = true)]
        public void CalculateVatObjectOriented()
        {
            foreach (var (address, order) in _values)
            {
                var calculator = new ObjectOrientedVatCalculator(address, order);
                _ = calculator.Vat();
            }
        }

        [Benchmark]
        public void CalculateVatFunctional()
        {
            foreach (var (address, order) in _values)
            {
                _ = FunctionalVatCalculator.Vat(address, order);
            }
        }
    }
}
