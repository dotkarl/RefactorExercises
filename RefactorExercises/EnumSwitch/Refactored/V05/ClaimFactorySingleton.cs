using RefactorExercises.EnumSwitch.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactorExercises.EnumSwitch.Refactored.V05
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

        private static IEnumerable<Type> _getClaimTypes;

        public IGetClaim GetClaim(Permission permission)
        {
            var type = GetClaimClassForPermission(_getClaimTypes, permission);
            if (type is null)
            {
                throw new NotSupportedException($"Permission of type '{permission}' is not supported");
            }

            return Activator.CreateInstance(type) as IGetClaim;
        }

        private static IEnumerable<Type> GetAllImplementationsOfIGetClaim()
        {
            return typeof(ClaimFactorySingleton).Assembly
                .GetTypes()
                .Where(t => !t.IsInterface &&
                            !t.IsAbstract &&
                            t.Namespace.Equals("RefactorExercises.EnumSwitch.Refactored.V05") &&
                            typeof(IGetClaim).IsAssignableFrom(t));
        }

        private static Type GetClaimClassForPermission(IEnumerable<Type> getClaimClasses, Permission permission)
        {
            return getClaimClasses.FirstOrDefault(c => c.GetProperty(nameof(IGetClaim.Permission)).GetValue(null, null).Equals(permission));
        }
    }
}
