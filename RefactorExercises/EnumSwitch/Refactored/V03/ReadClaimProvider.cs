using RefactorExercises.EnumSwitch.Model;

namespace RefactorExercises.EnumSwitch.Refactored.V03
{
    public class ReadClaimProvider : IProvideClaims
    {
        public static Permission Permission => Permission.Read;

        public string GetClaim()
        {
            // Processing...
            return "- User can Read entries";
        }
    }
}
