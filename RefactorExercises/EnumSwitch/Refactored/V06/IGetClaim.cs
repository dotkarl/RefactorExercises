using RefactorExercises.EnumSwitch.Model;

namespace RefactorExercises.EnumSwitch.Refactored.V06
{
    public interface IGetClaim
    {
        static Permission Permission { get; }
        string GetClaim();
    }
}
