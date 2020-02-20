using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KGreen
{
        public enum CarType
        {
            Electric =1,
            Hybrid,
            Gas
        }
    public class Car
    {
        public int CarID { get; set; }
        public string CarName { get; set; }
        public string CarDetails { get; set; }
        public CarType TypeOfCar { get; set; }

        public Car() { }
        public Car ( string carName,string carDetails,CarType typeOfCar)
        {
            //CarID = carID;
            CarName = carName;
            CarDetails = carDetails;
            TypeOfCar = typeOfCar;
        }
    }
}
