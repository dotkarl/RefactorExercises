﻿using RefactorExercises.EnumSwitch.Model;

namespace RefactorExercises.EnumSwitch.Refactored.V03
{
    public class GetWriteClaim : IGetClaim
    {
        public static Permission Permission => Permission.Write;

        public string GetClaim()
        {
            // Processing...
            return "- User can Write entries";
        }
    }
}
