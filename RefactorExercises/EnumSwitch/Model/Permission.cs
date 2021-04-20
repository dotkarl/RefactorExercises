using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactorExercises.EnumSwitch.Model
{
    [Flags]
    public enum Permission
    {
        Read = 1,
        Write = 2,
        Delete = 4,
    }

    public static class PermissionExtensions
    {
        public static IEnumerable<Permission> ToEnumerable(this Permission permission)
        {
            foreach (Permission val in Enum.GetValues(typeof(Permission)))
            {
                if (permission.HasFlag(val))
                {
                    yield return val;
                }
            }
        }

        public static Permission ToFlagsEnum(this IEnumerable<Permission> permissions)
        {
            if (permissions?.Any() != true)
            {
                throw new ArgumentNullException(nameof(permissions));
            }

            int result = 0;
            foreach (var claim in permissions)
            {
                result += (int)claim;
            }

            return (Permission)result;
        }
    }
}
