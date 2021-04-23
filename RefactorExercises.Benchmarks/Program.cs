using BenchmarkDotNet.Running;
using RefactorExercises.Benchmarks.EnumSwitch;

namespace RefactorExercises.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ClaimsHelperBenchMarks>();
        }
    }
}
