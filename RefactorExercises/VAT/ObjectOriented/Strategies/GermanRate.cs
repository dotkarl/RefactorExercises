using RefactorExercises.VAT.Model;

namespace RefactorExercises.VAT.ObjectOriented.Strategies
{
    internal class GermanRate : ICalculateRate
    {
        private readonly Order _order;

        public GermanRate(Order order)
        {
            _order = order;
        }

        public decimal Rate()
        {
            if (_order.Product.IsFood)
            {
                return 0.08m;
            }

            return 0.2m;
        }
    }
}
