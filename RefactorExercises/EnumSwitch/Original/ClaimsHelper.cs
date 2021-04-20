using RefactorExercises.EnumSwitch.Model;
using System;
using System.Text;

namespace RefactorExercises.EnumSwitch.Original
{
    public class ClaimsHelper : IClaimsHelper
    {
        private readonly User _user;

        public ClaimsHelper(User user)
        {
            _user = user;
        }

        public string GetClaimsForUser()
        {
            var claimsBuilder = new StringBuilder($"User '{_user.Id}' has the following claims:");

            // User can have multiple claims, so loop through them
            foreach (var permission in _user.Permissions.ToEnumerable())
            {
                switch (permission)
                {
                    case Permission.Read:
                        // Processing...
                        claimsBuilder.AppendLine("- User can Read entries");
                        break;
                    case Permission.Write:
                        // Processing...
                        claimsBuilder.AppendLine("- User can Write entries");
                        break;
                    case Permission.Delete:
                        // Processing...
                        claimsBuilder.AppendLine("- User can Delete entries");
                        break;
                    default:
                        throw new NotSupportedException($"Claim of type '{permission}' is not supported");
                }
            }

            // Return all the claims for the User
            return claimsBuilder.ToString();
        }
    }
}
