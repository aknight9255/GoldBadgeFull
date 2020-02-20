using System;
using System.Collections.Generic;
using _01_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecondGold;

namespace _01_CafeTest
{
    [TestClass]
    public class CafeTest
    {
        private MenuRepo _menuRepo;
        private Menu _menuItem;
        [TestInitialize]
        public void Arrange()
        {
            _menuRepo = new MenuRepo();
            _menuItem = new Menu(1, "Taters", "not a full meal but close", 3.99m, new List<string> {"tater","butter","cheese","chives","chili","bacon","sour cream" });
        }

        [TestMethod]
        public void AddMenuItemTest()
        {
            _menuRepo.AddMenuItem(_menuItem);
            int expected = 1;
            int actual = _menuRepo.GetFullMenu().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteMenuItemTest()
        {
            _menuRepo.DeleteMenutItem(_menuItem.MealNumber);
            int expected = 0;
            int actual = _menuRepo.GetFullMenu().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AnotherDeleteMenuMethodTest()
        {
            var anotherItem = new Menu(2, "Salad", "what is a sa-la-d", 2.48m, new List<string> { "Something called lettuce", "one tomato", "how about a little cheese?", "some cronch, some bread cronch" });
            var oneMoreItem = new Menu(3, "Ice Cream", "healing to the soul but not to the thighs", 1.65m, new List<string> { "Ice", "Cream" });
            _menuRepo.AddMenuItem(anotherItem);
            _menuRepo.AddMenuItem(oneMoreItem);
            _menuRepo.AddMenuItem(_menuItem);
            var answer =_menuRepo.AnotherDeleteMethod(oneMoreItem.MealNumber);
            Assert.IsTrue(answer);
        }
    }
}
