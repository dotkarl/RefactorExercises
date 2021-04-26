using RefactorExercises.EnumSwitch.Model;

namespace RefactorExercises.EnumSwitch.Refactored.V04
{
    public interface IProvideClaims
    {
        static Permission Permission { get; }
        string GetClaim();
    }
}
