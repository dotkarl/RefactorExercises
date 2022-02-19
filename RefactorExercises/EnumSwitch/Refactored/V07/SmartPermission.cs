using Ardalis.SmartEnum;
using System.Collections.Generic;

namespace RefactorExercises.EnumSwitch.Refactored.V07
{
    public class SmartPermission : SmartEnum<SmartPermission>
    {
        public static readonly SmartPermission Read = new(nameof(Read), 1, "- User can Read entries");
        public static readonly SmartPermission Write = new(nameof(Write), 2, "- User can Write entries");
        public static readonly SmartPermission Delete = new(nameof(Delete), 4, "- User can Delete entries");

        public string Claim { get; private set; }

        public SmartPermission(string name, int value, string claim) : base(name, value)
        {
            Claim = claim;
        }
    }
}
