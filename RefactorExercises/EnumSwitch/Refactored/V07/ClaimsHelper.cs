using RefactorExercises.EnumSwitch.Model;
using System.Text;

namespace RefactorExercises.EnumSwitch.Refactored.V07
{
    public class ClaimsHelper : IClaimsHelper
    {
        private readonly SmartUser _user;

        public ClaimsHelper(SmartUser user)
        {
            _user = user;
        }

        public string GetClaimsForUser()
        {
            var claimsBuilder = new StringBuilder($"User '{_user.Id}' has the following claims:");

            // User can have multiple claims, so loop through them
            foreach (SmartPermission permission in _user.SmartPermissions)
            {
                claimsBuilder.AppendLine(permission.Claim);
            }

            // Return all the claims for the User
            return claimsBuilder.ToString();
        }
    }
}
