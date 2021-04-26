using RefactorExercises.EnumSwitch.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactorExercises.EnumSwitch.Refactored.V03
{
    public static class ClaimProviderFactory
    {
        public static IProvideClaims GetClaimProvider(Permission permission)
        {
            var types = GetAllImplementationsOfIProvideClaims();
            var type = GetClaimProviderForPermission(types, permission);
            if (type is null)
            {
                throw new NotSupportedException($"Permission of type '{permission}' is not supported");
            }

            return Activator.CreateInstance(type) as IProvideClaims;
        }

        private static IEnumerable<Type> GetAllImplementationsOfIProvideClaims()
        {
            return typeof(ClaimProviderFactory).Assembly
                .GetTypes()
                .Where(t => !t.IsInterface &&
                            !t.IsAbstract &&
                            t.Namespace.Equals("RefactorExercises.EnumSwitch.Refactored.V03") &&
                            typeof(IProvideClaims).IsAssignableFrom(t));
        }

        private static Type GetClaimProviderForPermission(IEnumerable<Type> claimProviderTypes, Permission permission)
        {
            return claimProviderTypes.FirstOrDefault(c => c.GetProperty(nameof(IProvideClaims.Permission)).GetValue(null, null).Equals(permission));
        }
    }
}
