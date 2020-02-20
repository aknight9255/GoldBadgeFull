using _06_KGreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KGreenUI
{
    public class GreenUI
    {
        CarRepo _CarRepo = new CarRepo();
        public void Run()
        {
            SeedData();
            OpenMenu();
        }

        private void OpenMenu()
        {
            bool openMenu = true;
            while (openMenu)
            {
                Console.Clear();
                Console.WriteLine("Go Green! Let's track some cars. \n" +
                    "1) Show All Cars \n" +
                    "2) Show All Cars by Type \n" +
                    "3) Add New Car \n" +
                    "4) Update Car \n" +
                    "5) Remove Car \n" +
                    "6) Close Menu");
                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1": //Show All Cars
                        {
                            ShowAllCars();
                            break;
                        }
                    case "2": //Show All cars by type
                        {
                            ShowAllCarsByType();
                            break;
                        }
                    case "3": // Add new car
                        {
                            AddNewCar();
                            break;
                        }
                    case "4": //update car
                        {
                            UpdateCar();
                            break;
                        }
                    case "5": //remove car
                        {
                            RemoveCar();
                            break;
                        }
                    case "6": // close menu
                        {
                            openMenu = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter a value between 1 and 6 \n" +
                                "Press any key to return and try again ");
                            Console.ReadKey();
                            break;
                        }

                }
            }
        }
        private void RemoveCar()
        {
            Console.WriteLine("Please enter the ID of the Car you would like to remove... ");
            var deleteCar = _CarRepo.ReturnOneCar(int.Parse(Console.ReadLine()));
            Console.WriteLine($"You are about to delete \n" +
                $"{deleteCar.CarName} \n" +
                $"Do wish to continue..? \n" +
                $"Please enter y or n");
            var confirmation = Console.ReadLine().ToLower();
            bool miniMenu = true;
            while (miniMenu)
            {
                switch (confirmation)
                {
                    case "y":
                        {
                            Console.WriteLine("This car WILL now be deleted. ");
                            _CarRepo.DeleteCar(deleteCar.CarID);
                            miniMenu = false;
                            break;
                        }
                    case "n":
                        {
                            Console.WriteLine("This car will NOT be deleted, and you will returned to the main menu. \n" +
                                "Press any key to continue..");
                            Console.ReadKey();
                            miniMenu = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter either y or n");
                            break;
                        }
                }
            }
        }
        private void UpdateCar()
        {
            Console.WriteLine("Please enter the ID of the car you would like to update. \n");
            var userInput = int.Parse(Console.ReadLine());
            var oneCar = _CarRepo.ReturnOneCar(userInput);
            if (oneCar == null)
            {
                Console.WriteLine("That is not a valid ID. You are being returned to the main menu, please verify the ID there. \n" +
                    "Press any key...");
                Console.ReadKey();
            }
            else
            {
                bool miniMenu = true;
                while (miniMenu)
                {
                    Console.Clear();
                    Console.WriteLine("You have now entered the car edit menu. Please choose what you would like to update below. \n" +
                        "1) Update Car Name \n" +
                        "2) Update Car Details \n" +
                        "3) Update Car Type \n" +
                        "4) Finish Update");
                    var answer = Console.ReadLine();
                    switch (answer)
                    {
                        case "1":
                            {
                                Console.WriteLine($"The current name of this car is {oneCar.CarName} \n" +
                                    $"What would you like to update it too?");
                                oneCar.CarName = Console.ReadLine();
                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine($"The current details are \n" +
                                    $"{oneCar.CarDetails}\n" +
                                    $"What would like to update it too?");
                                oneCar.CarDetails = Console.ReadLine();
                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine($"The current car type is {oneCar.TypeOfCar} \n" +
                                    $"Please choose from the options below what you would like it to be. \n" +
                                    $"1) Electric \n" +
                                    $"2) Hybrid \n" +
                                    $"3) Gas \n");
                                var response = int.Parse(Console.ReadLine());
                                oneCar.TypeOfCar = (CarType)response;
                                break;
                            }
                        case "4":
                            {
                                var didItUpdate = _CarRepo.UpdateCar(oneCar);
                                if (didItUpdate)
                                {
                                    Console.WriteLine("This car has been updated. \n" +
                                        "Press any key to continue to the main menu.");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("There was an error in saving this. Please try again. \n" +
                                        "Press any key...");
                                    Console.ReadKey();
                                }
                                miniMenu = false;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Please enter a value between 1 and 4. \n" +
                                    "Press any key to continue..");
                                Console.ReadKey();
                                break;
                            }
                    }

                }
            }
        }
        private void AddNewCar()
        {
            var newCar = new Car();
            Console.WriteLine("Welcome! Let us add that new car! \n" +
                "Let us start out with the car name!");
            newCar.CarName = Console.ReadLine();
            Console.WriteLine("Thank you! Now please choose the car type from below. \n" +
                "1) Electric \n" +
                "2) Hybrid \n" +
                "3) Gas \n");
            var userResponse = int.Parse(Console.ReadLine());
            newCar.TypeOfCar = (CarType)userResponse;
            Console.WriteLine("Almost done! Now we just need you add details about that car, and then we can save it into the system.");
            newCar.CarDetails = Console.ReadLine();
            _CarRepo.AddNewCar(newCar);
            Console.WriteLine("Thank you! Your car has been saved. \n" +
                "Press any key to return to the menu..");
            Console.ReadKey();
        }
        private void ShowAllCarsByType()
        {
            Console.WriteLine("What type of car would like \n" +
                "Please choose and option from below \n" +
                "1) Electric \n" +
                "2) Hybrid \n" +
                "3) Gas");
            var carType = int.Parse(Console.ReadLine());
            var input = (CarType)carType;
            var byTypeList = _CarRepo.ShowByType(input);
            Console.WriteLine($"Here is the list of {input} cars! \n");
            foreach (Car car in byTypeList)
            {
                Console.WriteLine($"{car.CarName}  -- ID: {car.CarID}\n" +
                    $"Type of car - {car.TypeOfCar} \n" +
                    $"Details - {car.CarDetails} \n" +
                    $"-------------------------------");
            }
            Console.WriteLine("Press any key to return to main menu..");
            Console.ReadKey();
        }
        public void ShowAllCars()
        {
            var carList = _CarRepo.ShowAllCars();
            foreach (Car car in carList)
            {
                Console.WriteLine($"{car.CarName} -- ID: {car.CarID} \n" +
                    $"Type of car - {car.TypeOfCar} \n" +
                    $"Details - {car.CarDetails} \n" +
                    $"-------------------------------");

            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void SeedData()
        {
            var carOne = new Car("The Ing Mobile", "Foreign. Reliable. Eco Friendly", CarType.Electric);
            var carTwo = new Car("Tony-Cycle", "Cooler than you. Magestic Beard Included. High Five to start", CarType.Gas);
            var carThree = new Car("Josh S4000", "Runs best on C# and sarcasm. 10/10 will troll you. Very Dependable", CarType.Gas);
            var carFour = new Car("The Danielle", "Knows Japanese, rear wheel sometimes sticks, high performing.", CarType.Hybrid);
            _CarRepo.AddNewCar(carOne);
            _CarRepo.AddNewCar(carTwo);
            _CarRepo.AddNewCar(carThree);
            _CarRepo.AddNewCar(carFour);
        }
    }
}
