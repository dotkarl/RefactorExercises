using RefactorExercises.EnumSwitch.Model;

namespace RefactorExercises.EnumSwitch.Refactored.V05
{
    public interface IGetClaim
    {
        static Permission Permission { get; }
        string GetClaim();
    }
}
