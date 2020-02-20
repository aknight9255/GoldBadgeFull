using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KGreen
{
    public class CarRepo
    {
        private List<Car> _listOfCars = new List<Car>();
        public List<Car> ShowAllCars()
        {
            return _listOfCars;
        }
        public List<Car> ShowByType(CarType carType)
        {
            var listByType = new List<Car>();
            foreach(Car car in _listOfCars)
            {
                if(car.TypeOfCar == carType)
                {
                    listByType.Add(car);
                }
            }
            return listByType;
        }
        public Car ReturnOneCar(int carID)
        {
            var list = ShowAllCars();
            foreach (Car car in list)
            {
                if(carID == car.CarID)
                {
                    return car;
                }
            }
            return null;

        }
        public void AddNewCar(Car newCar)
        {
            var lastCar =_listOfCars.LastOrDefault();
            if (lastCar != null)
            {
            newCar.CarID = lastCar.CarID + 1;
            }
            else
            {
                newCar.CarID = 1;
            }
            _listOfCars.Add(newCar);
        }
        public bool DeleteCar(int carID)
        {
            var returnedCar = ReturnOneCar(carID);
            if(returnedCar == null)
            {
                return false;
            }
            return _listOfCars.Remove(returnedCar);


        }
        public bool UpdateCar(Car car)
        {
            foreach(Car aCar in _listOfCars)
            {
                if(aCar.CarID == car.CarID)
                {
                    aCar.CarDetails = car.CarDetails;
                    aCar.CarName = car.CarName;
                    aCar.TypeOfCar = car.TypeOfCar;
                    return true;
                }
            }
            return false;
        }
    }
}
