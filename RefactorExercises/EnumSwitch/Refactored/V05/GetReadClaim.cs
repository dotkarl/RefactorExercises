using RefactorExercises.EnumSwitch.Model;

namespace RefactorExercises.EnumSwitch.Refactored.V05
{
    public class GetReadClaim : IGetClaim
    {
        public static Permission Permission => Permission.Read;

        public string GetClaim()
        {
            // Processing...
            return "- User can Read entries";
        }
    }
}
