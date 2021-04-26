using RefactorExercises.EnumSwitch.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactorExercises.EnumSwitch.Refactored.V05
{
    public sealed class ClaimProviderFactorySingleton
    {
        private static ClaimProviderFactorySingleton _instance = null;
        public static ClaimProviderFactorySingleton Instance
        {
            get
            {
                _instance ??= new ClaimProviderFactorySingleton();
                return _instance;
            }
        }

        private static IEnumerable<Type> _claimProviderTypes;

        private ClaimProviderFactorySingleton()
        {
            _claimProviderTypes = GetAllImplementationsOfIProvideClaims();
        }

        private static IEnumerable<Type> GetAllImplementationsOfIProvideClaims()
        {
            return typeof(ClaimProviderFactorySingleton).Assembly
                .GetTypes()
                .Where(t => !t.IsInterface &&
                            !t.IsAbstract &&
                            t.Namespace.Equals("RefactorExercises.EnumSwitch.Refactored.V05") &&
                            typeof(IProvideClaims).IsAssignableFrom(t));
        }

        public IProvideClaims GetClaimProvider(Permission permission)
        {
            var type = GetClaimProviderForPermission(permission);
            if (type is null)
            {
                throw new NotSupportedException($"Permission of type '{permission}' is not supported");
            }

            return Activator.CreateInstance(type) as IProvideClaims;
        }

        private static Type GetClaimProviderForPermission(Permission permission)
        {
            return _claimProviderTypes.FirstOrDefault(c => c.GetProperty(nameof(IProvideClaims.Permission)).GetValue(null, null).Equals(permission));
        }
    }
}
