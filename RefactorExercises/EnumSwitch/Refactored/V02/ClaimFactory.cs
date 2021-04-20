using RefactorExercises.EnumSwitch.Model;
using System;

namespace RefactorExercises.EnumSwitch.Refactored.V02
{
    public static class ClaimFactory
    {
        public static IGetClaim GetClaim(Permission permission)
        {
            return permission switch
            {
                Permission.Read => new GetReadClaim(),
                Permission.Write => new GetWriteClaim(),
                Permission.Delete => new GetDeleteClaim(),
                _ => throw new NotSupportedException($"Claim of type '{permission}' is not supported"),
            };
        }
    }
}
