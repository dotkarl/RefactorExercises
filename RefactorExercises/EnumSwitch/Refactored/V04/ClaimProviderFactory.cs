using RefactorExercises.EnumSwitch.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactorExercises.EnumSwitch.Refactored.V04
{
    public static class ClaimProviderFactory
    {
        private static IEnumerable<Type> _claimProviderTypes = null;

        public static IProvideClaims GetClaimProvider(Permission permission)
        {
            _claimProviderTypes ??= GetAllImplementationsOfIProvideClaims();
            var type = GetClaimProviderForPermission(permission);
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
                            t.Namespace.Equals("RefactorExercises.EnumSwitch.Refactored.V04") &&
                            typeof(IProvideClaims).IsAssignableFrom(t));
        }

        private static Type GetClaimProviderForPermission(Permission permission)
        {
            return _claimProviderTypes.FirstOrDefault(c => c.GetProperty(nameof(IProvideClaims.Permission)).GetValue(null, null).Equals(permission));
        }
    }
}
