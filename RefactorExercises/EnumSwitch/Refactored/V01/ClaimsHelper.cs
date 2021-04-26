using RefactorExercises.EnumSwitch.Model;
using System;
using System.Text;

namespace RefactorExercises.EnumSwitch.Refactored.V01
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
                        var r = new ReadClaimProvider();
                        claimsBuilder.AppendLine(r.GetReadClaim());
                        break;
                    case Permission.Write:
                        var w = new WriteClaimProvider();
                        claimsBuilder.AppendLine(w.GetWriteClaim());
                        break;
                    case Permission.Delete:
                        var d = new DeleteClaimProvider();
                        claimsBuilder.AppendLine(d.GetDeleteClaim());
                        break;
                    default:
                        throw new NotSupportedException($"Permission of type '{permission}' is not supported");
                }
            }

            // Return all the claims for the User
            return claimsBuilder.ToString();
        }
    }
}

