using System;
using _06_KGreen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06_KGreenTest
{
    [TestClass]
    public class GreenTest
    {
        CarRepo _carRepo;
        Car _newCar;

        [TestInitialize]
        public void Arrange()
        {
            _carRepo = new CarRepo();
            _newCar = new Car();

        }
        [TestMethod]
        public void AddNewCarTest()
        {
            _carRepo.AddNewCar(_newCar);
            var expected = 1;
            var actual = _carRepo.ShowAllCars().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DeleteCarTest()
        {
            _carRepo.DeleteCar(_newCar.CarID);
            var actual = _carRepo.ShowAllCars().Count;
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UpdateCarTest()
        {
            _carRepo.AddNewCar(_newCar);
            var updateCar = new Car("OldBoi", "an old boi but a good boi",CarType.Electric);
            updateCar.CarID = _newCar.CarID;
            _carRepo.UpdateCar(updateCar);
            var expected = "OldBoi";
            var actual = updateCar.CarName;
            Assert.AreEqual(expected, actual);
        }

    }
}
