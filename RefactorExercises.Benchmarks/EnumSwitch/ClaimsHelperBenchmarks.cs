using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using RefactorExercises.EnumSwitch.Model;
using RefactorExercises.EnumSwitch.Refactored.V07;
using OriginalClaimsHelper = RefactorExercises.EnumSwitch.Original.ClaimsHelper;
using RefactoredV01ClaimsHelper = RefactorExercises.EnumSwitch.Refactored.V01.ClaimsHelper;
using RefactoredV02ClaimsHelper = RefactorExercises.EnumSwitch.Refactored.V02.ClaimsHelper;
using RefactoredV03ClaimsHelper = RefactorExercises.EnumSwitch.Refactored.V03.ClaimsHelper;
using RefactoredV04ClaimsHelper = RefactorExercises.EnumSwitch.Refactored.V04.ClaimsHelper;
using RefactoredV05ClaimsHelper = RefactorExercises.EnumSwitch.Refactored.V05.ClaimsHelper;
using RefactoredV06ClaimsHelper = RefactorExercises.EnumSwitch.Refactored.V06.ClaimsHelper;
using RefactoredV07ClaimsHelper = RefactorExercises.EnumSwitch.Refactored.V07.ClaimsHelper;

namespace RefactorExercises.Benchmarks.EnumSwitch
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class ClaimsHelperBenchMarks
    {
        private static readonly User _user = new User()
        {
            Id = "UserId01",
            Permissions = (Permission)7
        };

        private static readonly SmartUser _smartUser = new SmartUser()
        {
            Id = "SmartUserId07",
            SmartPermissions = SmartPermission.List
        };

        private static readonly OriginalClaimsHelper _claimsHelperV00 = new(_user);
        private static readonly RefactoredV01ClaimsHelper _claimsHelperV01 = new(_user);
        private static readonly RefactoredV02ClaimsHelper _claimsHelperV02 = new(_user);
        private static readonly RefactoredV03ClaimsHelper _claimsHelperV03 = new(_user);
        private static readonly RefactoredV04ClaimsHelper _claimsHelperV04 = new(_user);
        private static readonly RefactoredV05ClaimsHelper _claimsHelperV05 = new(_user);
        private static readonly RefactoredV06ClaimsHelper _claimsHelperV06 = new(_user);
        private static readonly RefactoredV07ClaimsHelper _claimsHelperV07 = new(_smartUser);

        [Benchmark(Baseline = true)]
        public void GetClaimsForUserV00()
        {
            _ = _claimsHelperV00.GetClaimsForUser();
        }

        [Benchmark]
        public void GetClaimsForUserV01()
        {
            _ = _claimsHelperV01.GetClaimsForUser();
        }

        [Benchmark]
        public void GetClaimsForUserV02()
        {
            _ = _claimsHelperV02.GetClaimsForUser();
        }

        [Benchmark]
        public void GetClaimsForUserV03()
        {
            _ = _claimsHelperV03.GetClaimsForUser();
        }

        [Benchmark]
        public void GetClaimsForUserV04()
        {
            _ = _claimsHelperV04.GetClaimsForUser();
        }

        [Benchmark]
        public void GetClaimsForUserV05()
        {
            _ = _claimsHelperV05.GetClaimsForUser();
        }

        [Benchmark]
        public void GetClaimsForUserV06()
        {
            _ = _claimsHelperV06.GetClaimsForUser();
        }

        [Benchmark]
        public void GetClaimsForUserV07()
        {
            _ = _claimsHelperV07.GetClaimsForUser();
        }
    }
}
