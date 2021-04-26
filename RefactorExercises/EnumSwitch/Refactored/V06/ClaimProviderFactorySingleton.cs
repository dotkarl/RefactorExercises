using RefactorExercises.EnumSwitch.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactorExercises.EnumSwitch.Refactored.V06
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

        private static Dictionary<Permission, Type> _claimProviderTypes;

        private ClaimProviderFactorySingleton()
        {
            _claimProviderTypes = GetAllImplementationsOfIProvideClaims();
        }

        private static Dictionary<Permission, Type> GetAllImplementationsOfIProvideClaims()
        {
            var types = typeof(ClaimProviderFactorySingleton).Assembly
                .GetTypes()
                .Where(t => !t.IsInterface &&
                            !t.IsAbstract &&
                            t.Namespace.Equals("RefactorExercises.EnumSwitch.Refactored.V06") &&
                            typeof(IProvideClaims).IsAssignableFrom(t));
            var allPermissions = (Permission)int.MaxValue;

            var dict = new Dictionary<Permission, Type>();
            foreach (var permission in allPermissions.ToEnumerable())
            {
                dict.Add(permission, GetClaimProviderForPermission(types, permission));
            }
            return dict;
        }

        private static Type GetClaimProviderForPermission(IEnumerable<Type> claimProviderTypes, Permission permission)
        {
            return claimProviderTypes.FirstOrDefault(c => c.GetProperty(nameof(IProvideClaims.Permission)).GetValue(null, null).Equals(permission));
        }

        public IProvideClaims GetClaimProvider(Permission permission)
        {
            var type = _claimProviderTypes[permission];
            if (type is null)
            {
                throw new NotSupportedException($"Permission of type '{permission}' is not supported");
            }
            return Activator.CreateInstance(type) as IProvideClaims;
        }
    }
}
