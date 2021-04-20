using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorExercises.EnumSwitch.Model
{
    [Flags]
    public enum Permission
    {
        Read = 1,
        Write = 2,
        Delete = 4,
    }

    public static class ClassificationRoleTypeExtensions
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

        public static Permission ToFlagsEnum(this IEnumerable<Permission> permission)
        {
            if (permission?.Any() != true)
            {
                throw new ArgumentNullException(nameof(permission));
            }

            int result = 0;
            foreach (var claim in permission)
            {
                result += (int)claim;
            }

            return (Permission)result;
        }
    }
}
