using _04_Outings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_KOutingUI
{
    public class ProgramUI
    {
        private OutingRepo _outingRepo = new OutingRepo();
        public void Run()
        {
            SeedData();
            OpenMenu();
        }
        public void OpenMenu()
        {
            bool menuOpen = true;
            while (menuOpen)
            {
                Console.Clear();
                Console.WriteLine("Welcome to TechComp Outing Tracker \n" +
                    "Please choose an option from below. \n" +
                    "1) Show all Outings \n" +
                    "2) Show all Outings by Year \n" +
                    "3) Show total cost by year and Type of outing \n" +
                    "4) Add new Outing \n" +
                    "5) Exit Menu");
                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1": //show all outings ever
                        {
                            DisplayOutings();
                            break;
                        }
                    case "2": //show all outings by year
                        {
                            ShowOutingsByYear();
                            break;
                        }
                    case "3": // show total by year and type
                        {
                            ShowTotalsByYearAndType();
                            break;
                        }
                    case "4": // add new outing
                        {
                            AddNewOuting();
                            break;
                        }
                    case "5": //close menu
                        {
                            Console.WriteLine("Are you sure you want to close the menu? \n" +
                                "Please enter y or n..");
                            var answer = Console.ReadLine().ToLower();
                            switch (answer)
                            {
                                case "y":
                                    {
                                        menuOpen = false;
                                        break;
                                    }
                                case "n":
                                    {
                                        break;
                                    }
                            }
                            break;
                        }
                }

            }
        }
        public void DisplayOutings()
        {
            var outingList = _outingRepo.ShowAllOutings();
            foreach (Outing outing in outingList)
            {
                Console.WriteLine($"Date of Event: {outing.DateOfEvent.ToString("d")}---{outing.TypeOfEvent} \n" +
                    $"Number of people attending - {outing.TotalNumberOfPeopleAttending} - Cost Per Person- ${outing.CostPerPerson} \n" +
                    $"Total Cost of the event: ${outing.TotalCostOfEvent} \n");
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
        public void ShowOutingsByYear()
        {
            Console.WriteLine("Please enter the year you wish to see");
            var year = int.Parse(Console.ReadLine());
            while (!IsAYear(year))
            {
                Console.WriteLine("Please enter a valid year");
                year = int.Parse(Console.ReadLine());

            }
            var outingList = _outingRepo.ShowAllByYear(year);
            if (outingList.Count == 0)
            {
                Console.WriteLine($"There are no outings recorded for year {year} \n" +
                    $"Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                var outingCost = _outingRepo.ReturnCostForTheYear(year);
                Console.WriteLine($"The total outing cost of {year} is ${outingCost}\n" +
                    $"------------------------");
                foreach (Outing outing in outingList)
                {
                    Console.WriteLine($"Date of Event: {outing.DateOfEvent.ToString("d")}---{outing.TypeOfEvent} \n" +
                        $"Number of people attending - {outing.TotalNumberOfPeopleAttending} - Cost Per Person- ${outing.CostPerPerson} \n" +
                        $"Total Cost of the event: ${outing.TotalCostOfEvent} \n");
                }
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
            }

        }
        public void ShowTotalsByYearAndType()
        {
            Console.WriteLine("Please enter the year that you wish to see");
            var inputYear = int.Parse(Console.ReadLine());
            while (!IsAYear(inputYear))
            {
                Console.WriteLine("Please enter a valid year");
                inputYear = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Please choose the type of event you wish to sort by \n" +
                "1) Golf \n" +
                "2)Bowling \n" +
                "3) Amusement Park \n" +
                "4) Concert \n" +
                "Enter a value between 1 and 4.");
            var inputType = int.Parse(Console.ReadLine());
            while (!IsAnEventType(inputType))
            {
                Console.WriteLine("Enter a valid choice. Only a numerical value of 1 through 4 will be accepted. \n" +
                "Press any key to continue..");
                inputType = int.Parse(Console.ReadLine());
            }
            var eventType = (EventType)inputType;
            var totalCost = _outingRepo.ReturnCostForTheYearByType(eventType, inputYear);
            Console.WriteLine($"The total cost for year {inputYear} for all {eventType} events is \n" +
                $"${totalCost} \n" +
                $"Press any key to return to the menu...");
            Console.ReadKey();
    }
        public void AddNewOuting()
        {
            var newOuting = new Outing();
            Console.WriteLine("Let us start adding that new event! \n" +
                "First please type in the date of the event. \n" +
                "Use the following format.\n" +
                "year/month/day \n" +
                "2019/12/24");
            var dateInput = Console.ReadLine();
            var eventDate = DateTime.Parse(dateInput);
            newOuting.DateOfEvent = eventDate;
            Console.WriteLine("How many people are attending or did attend this event?");
            newOuting.TotalNumberOfPeopleAttending = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the cost per person for this event?");
            newOuting.CostPerPerson = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Last question! \n " +
                "Please choose the type of event from the options below. \n" +
                "1) Golf \n" +
                "2) Bowling \n" +
                "3) Amusement Park \n" +
                "4) Concert \n" +
                "Enter a value between 1 and 4.");
            var inputType = int.Parse(Console.ReadLine());
            while (!IsAnEventType(inputType))
            {
                Console.WriteLine("Enter a valid choice. Only a numerical value of 1 through 4 will be accepted. \n" +
                "Press any key to continue..");
                inputType = int.Parse(Console.ReadLine());
            }
            newOuting.TypeOfEvent = (EventType)inputType;
            _outingRepo.AddNewOuting(newOuting);
        }

    public bool IsAYear(int year)
    {
        if (year >= 2000 && year < 5000)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsAnEventType(int type)
    {
        if (type > 0 || type <= 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void SeedData()
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
    }
}
}

