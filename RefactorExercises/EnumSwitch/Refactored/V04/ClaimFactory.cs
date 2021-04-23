using RefactorExercises.EnumSwitch.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactorExercises.EnumSwitch.Refactored.V04
{
    public static class ClaimFactory
    {
        private static IEnumerable<Type> _getClaimTypes = null;

        public static IGetClaim GetClaim(Permission permission)
        {
            _getClaimTypes ??= GetAllImplementationsOfIGetClaim();
            var type = GetClaimClassForPermission(permission);
            if (type is null)
            {
                throw new NotSupportedException($"Permission of type '{permission}' is not supported");
            }

            return Activator.CreateInstance(type) as IGetClaim;
        }

        private static IEnumerable<Type> GetAllImplementationsOfIGetClaim()
        {
            return typeof(ClaimFactory).Assembly
                .GetTypes()
                .Where(t => !t.IsInterface &&
                            !t.IsAbstract &&
                            t.Namespace.Equals("RefactorExercises.EnumSwitch.Refactored.V04") &&
                            typeof(IGetClaim).IsAssignableFrom(t));
        }

        private static Type GetClaimClassForPermission(Permission permission)
        {
            return _getClaimTypes.FirstOrDefault(c => c.GetProperty(nameof(IGetClaim.Permission)).GetValue(null, null).Equals(permission));
        }
    }
}
