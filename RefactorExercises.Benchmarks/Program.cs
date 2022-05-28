using BenchmarkDotNet.Running;

namespace RefactorExercises.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<VAT.VatCalculatorBenchmarks>();
        }
    }
}
