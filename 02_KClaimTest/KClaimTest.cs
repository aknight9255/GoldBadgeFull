using System;
using _02_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_KClaimTest
{
    [TestClass]
    public class KClaimTest
    {
        private ClaimRepo _ClaimRepo;
        private Claim _claimItem;
        [TestInitialize]
        public void Arrange()
        {
            _ClaimRepo = new ClaimRepo();
            _claimItem = new Claim(8675309, ClaimType.Home, "Tornado moved house on top of a witch", new DateTime(12 / 03 / 2019), new DateTime(12 / 15 / 19), 100000.235m);
        }
        [TestMethod]
        public void TestAddMethod()
        {
            _ClaimRepo.AddNewClaim(_claimItem);
            var expected = 1;
            var actual = _ClaimRepo.ShowAllClaims().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestDequeueMethod()
        {
            var testOne = new Claim(222, ClaimType.Theft, "One heart, in poor condition", new DateTime(02 / 02 / 12), new DateTime(04 / 04 / 14), 42);
            var testTwo = new Claim(12290, ClaimType.Car, "Dude...where is my car?", new DateTime(4 / 13 / 19), new DateTime(4 / 25 / 19), 50);
            _ClaimRepo.AddNewClaim(_claimItem);
            _ClaimRepo.AddNewClaim(testOne);
            _ClaimRepo.AddNewClaim(testTwo);
            _ClaimRepo.RemoveClaimFromQueue();
            var expected = 2;
            var actual = _ClaimRepo.ShowAllClaims().Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
