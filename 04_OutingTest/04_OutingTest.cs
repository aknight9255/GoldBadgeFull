using System;
using _04_Outings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_OutingTest
{
    [TestClass]
    public class UnitTest1
    {
        private OutingRepo _outingRepo;
        private Outing _outingItem;
        [TestInitialize]
        public void Arrange()
        {
            _outingRepo = new OutingRepo();
            _outingItem = new Outing(EventType.Concert,42,new DateTime(2019,12,12),23.3m);
        }
        [TestMethod]
        public void AddAnEvent()
        {
            _outingRepo.AddNewOuting(_outingItem);
            var expected = 1;
            var actual = _outingRepo.ShowAllOutings().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ReturnnByYear()
        {
            var itemOne = new Outing(EventType.Concert, 42, new DateTime(2019, 12, 12), 23.3m);
            var itemTwo = new Outing(EventType.Golf, 42, new DateTime(2019, 12, 12), 23.3m);
            var itemThree = new Outing(EventType.AmusementParke, 42, new DateTime(2019, 12, 12), 23.3m);
            var itemFour = new Outing(EventType.Bowling, 42, new DateTime(2019, 12, 12), 13.3m);
            var itemFive = new Outing(EventType.Concert, 42, new DateTime(2019, 12, 12), 40.3m);
            var itemSix = new Outing(EventType.Concert, 42, new DateTime(2017, 12, 12), 23.3m);
            _outingRepo.AddNewOuting(itemOne);
            _outingRepo.AddNewOuting(itemTwo);
            _outingRepo.AddNewOuting(itemThree);
            _outingRepo.AddNewOuting(itemFour);
            _outingRepo.AddNewOuting(itemFive);
            _outingRepo.AddNewOuting(itemSix);
            var actual = _outingRepo.ReturnCostForTheYear(2019);
            var expected = 5187;
            Console.WriteLine(actual);
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void ReturnByType()
        {
            var itemOne = new Outing(EventType.Concert, 42, new DateTime(2019, 12, 12), 23.3m);
            var itemTwo = new Outing(EventType.Golf, 42, new DateTime(2019, 12, 12), 23.3m);
            var itemThree = new Outing(EventType.AmusementParke, 42, new DateTime(2019, 12, 12), 23.3m);
            var itemFour = new Outing(EventType.Bowling, 42, new DateTime(2019, 12, 12), 13.3m);
            var itemFive = new Outing(EventType.Concert, 42, new DateTime(2019, 12, 12), 40.3m);
            var itemSix = new Outing(EventType.Concert, 42, new DateTime(2017, 12, 12), 23.3m);
            _outingRepo.AddNewOuting(itemOne);
            _outingRepo.AddNewOuting(itemTwo);
            _outingRepo.AddNewOuting(itemThree);
            _outingRepo.AddNewOuting(itemFour);
            _outingRepo.AddNewOuting(itemFive);
            _outingRepo.AddNewOuting(itemSix);
            var actual = _outingRepo.ReturnCostForTheYearByType(EventType.Concert, 2017);
            var expected = 978.6m;
            Assert.AreEqual(actual, expected);

        }
    }
}
