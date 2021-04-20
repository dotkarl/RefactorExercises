using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorExercises.EnumSwitch.Model;
using OriginalClaimsHelper = RefactorExercises.EnumSwitch.Original.ClaimsHelper;
using RefactoredV01ClaimsHelper = RefactorExercises.EnumSwitch.Refactored.V01.ClaimsHelper;
using RefactoredV02ClaimsHelper = RefactorExercises.EnumSwitch.Refactored.V02.ClaimsHelper;
using RefactoredV03ClaimsHelper = RefactorExercises.EnumSwitch.Refactored.V03.ClaimsHelper;

namespace RefactorExercises.Tests.EnumSwitch
{
    [TestClass]
    public class PermissionsHelperTestsOriginal : PermissionsHelperTestsTemplate
    {
        public override IClaimsHelper GetClaimsHelper(User user)
        {
            return new OriginalClaimsHelper(user);
        }
    }

    [TestClass]
    public class PermissionsHelperTestsRefactoredV01 : PermissionsHelperTestsTemplate
    {
        public override IClaimsHelper GetClaimsHelper(User user)
        {
            return new RefactoredV01ClaimsHelper(user);
        }
    }

    [TestClass]
    public class PermissionsHelperTestsRefactoredV02 : PermissionsHelperTestsTemplate
    {
        public override IClaimsHelper GetClaimsHelper(User user)
        {
            return new RefactoredV02ClaimsHelper(user);
        }
    }

    [TestClass]
    public class PermissionsHelperTestsRefactoredV03 : PermissionsHelperTestsTemplate
    {
        public override IClaimsHelper GetClaimsHelper(User user)
        {
            return new RefactoredV03ClaimsHelper(user);
        }
    }
}
