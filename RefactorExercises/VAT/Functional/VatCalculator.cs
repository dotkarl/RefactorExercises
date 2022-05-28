using RefactorExercises.VAT.Model;
using System;

namespace RefactorExercises.VAT.Functional
{
    public static class VatCalculator
    {
        public static decimal Vat(Address address, Order order)
            => address switch
            {
                UsAddress(var state) => Vat(RateByState(state), order),
                ("de") _ => DeVat(order),
                (var country) _ => Vat(RateByCountry(address.Country), order)
            };

        static decimal DeVat(Order order)
            => order.NetPrice * (order.Product.IsFood ? 0.08m : 0.2m);

        static decimal RateByCountry(string country)
            => country switch
            {
                "it" => 0.22m,
                "jp" => 0.08m,
                _ => throw new ArgumentException($"Missing rate for {country}")
            };

        static decimal RateByState(string state)
            => state switch
            {
                "ca" => 0.1m,
                "ma" => 0.0625m,
                "ny" => 0.085m,
                _ => throw new ArgumentException($"Missing rate for {state}")
            };

        static decimal Vat(decimal rate, Order order)
            => order.NetPrice * rate;
    }
}
