using RefactorExercises.EnumSwitch.Model;
using System.Collections.Generic;

namespace RefactorExercises.EnumSwitch.Refactored.V07
{
    public class SmartUser : User
    {
        public IEnumerable<SmartPermission> SmartPermissions { get; set; }
    }
}
