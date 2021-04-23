using RefactorExercises.EnumSwitch.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactorExercises.EnumSwitch.Refactored.V06
{
    public sealed class ClaimFactorySingleton
    {
        private ClaimFactorySingleton()
        {
            _getClaimTypes = GetAllImplementationsOfIGetClaim();
        }

        private static ClaimFactorySingleton _instance = null;
        public static ClaimFactorySingleton Instance
        {
            get
            {
                _instance ??= new ClaimFactorySingleton();
                return _instance;
            }
        }

        private static Dictionary<Permission, Type> _getClaimTypes;

        public IGetClaim GetClaim(Permission permission)
        {
            var type = _getClaimTypes[permission];
            if (type is null)
            {
                throw new NotSupportedException($"Permission of type '{permission}' is not supported");
            }
            return Activator.CreateInstance(type) as IGetClaim;
        }

        private static Dictionary<Permission, Type> GetAllImplementationsOfIGetClaim()
        {
            var types = typeof(ClaimFactorySingleton).Assembly
                .GetTypes()
                .Where(t => !t.IsInterface &&
                            !t.IsAbstract &&
                            t.Namespace.Equals("RefactorExercises.EnumSwitch.Refactored.V06") &&
                            typeof(IGetClaim).IsAssignableFrom(t));
            var allPermissions = (Permission)255;

            var dict = new Dictionary<Permission, Type>();
            foreach (var permission in allPermissions.ToEnumerable())
            {
                dict.Add(permission, GetClaimClassForPermission(types, permission));
            }
            return dict;
        }

        private static Type GetClaimClassForPermission(IEnumerable<Type> getClaimTypes, Permission permission)
        {
            return getClaimTypes.FirstOrDefault(c => c.GetProperty(nameof(IGetClaim.Permission)).GetValue(null, null).Equals(permission));
        }
    }
}
