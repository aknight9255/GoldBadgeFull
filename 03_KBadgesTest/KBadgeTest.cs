using System;
using System.Collections.Generic;
using KBadges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_KBadgesTest
{
    [TestClass]
    public class KBadgeTest
    {
        private BadgeRepo _badgeRepo;
        [TestInitialize]
        public void Arrange()
        {
            _badgeRepo = new BadgeRepo();
        }
        [TestMethod]
        public void AddBadgeTest()
        {
            var key = 123;
            var value = new List<string> { "A1", "A5", "B" };

            _badgeRepo.AddNewBadge(key, value);
            int expected = 1;
            int actual = _badgeRepo.ShowAllBadges().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveBadgeFromDoor()
        {
            var key = 123;
            var value = new List<string> { "A1", "A5", "B" };

            _badgeRepo.AddNewBadge(key, value);
            _badgeRepo.RemoveDoorFromBadge(123, "A1");
            var badgeList = _badgeRepo.ShowAllBadges();
            int expected = 2;
            int actual = value.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WipeAllDoorsTest()
        {
            var key = 123;
            var value = new List<string> { "A1", "A5", "B" };

            _badgeRepo.AddNewBadge(key, value);
            _badgeRepo.WipeAllDoorsFromBadge(key);
            var expected = 0;
            var actual = value.Count;
            Assert.AreEqual(expected, actual);

        }
    }
}
