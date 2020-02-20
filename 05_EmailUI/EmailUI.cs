using _05_KEmails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_EmailUI
{
    public class EmailUI
    {
        private CustomerRepo _repo = new CustomerRepo();
        public void Run()
        {
            SeedData();
            RunMenu();
        }
        public void RunMenu()
        {
            bool menuIsOpen = true;
            while (menuIsOpen)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Customer email hub. \n" +
                    "What can we help you with today? \n" +
                    "1) Show all customers alphabetically \n" +
                    "2) Show all customers (Names and IDs Only) \n" +
                    "3) Add new customer \n" +
                    "4) Edit customer \n" +
                    "5) Delete a customer \n" +
                    "6) Show one customer \n" +
                    "7) Exit Menu \n" +
                    "Please choose and option between 1 and 6");
                var userMenuSelection = Console.ReadLine();
                switch (userMenuSelection)
                {
                    case "1":// Show all Customers alphabetical
                        {
                            ShowAllCustomers();
                            break;
                        }
                    case "2": //Show all Customers, names and IDs only
                        {
                            ShowOptionTwo();
                            break;
                        }
                    case "3": //Add New customer
                        {
                            AddNewCustomer();
                            break;
                        }
                    case "4": //Edit a customer
                        {
                            EditCustomer();
                            break;
                        }
                    case "5": //Delete a customer
                        {
                            DeleteACustomer();
                            break;
                        }
                    case "6": //Show one customer
                        {
                            ShowOneCustomer();
                            break;
                        }
                    case "7": //Close menu
                        {
                            menuIsOpen = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter a value between 1 and 6 \n" +
                                "Press any key to continue...");
                            Console.ReadKey();
                            break;
                        }
                }
            }
        }

        public void ShowOptionTwo()
        {
            var allCustomers = _repo.ReturnAllCustomer();
            var headers = string.Format("|| {0,15} {1,15} {2,15} ||", "First Name", "Last Name", "CustomerID");
            Console.WriteLine(headers);
            foreach(Customer customer in allCustomers)
            {
                var content = string.Format("|| {0,15} {1,15} {2,15} ||", customer.FirstName, customer.LastName, customer.CustomerID);
                Console.WriteLine(content);
            }
            Console.WriteLine("Press any key to continue . . ");
            Console.ReadKey();
        }
        public void ShowOneCustomer()
        {
            Console.WriteLine("Please enter the Customer ID of the customer you wish to see.");
            var customerID = int.Parse(Console.ReadLine());
            var customer = _repo.GetOneCustomer(customerID);
            if (customer != null)
            {
                Console.WriteLine($"Customer Name: {customer.FirstName} {customer.LastName}" +
                    $"Customer ID: {customer.CustomerID} \n" +
                    $"Customer Type: {customer.TypeOfCustomer} \n" +
                    $"Customer Email Content: {customer.EmailContent}");
            }
            else
            {
                Console.WriteLine("This is not a valid Customer ID. Please confirm the number and try again..\n" +
                    "Press any key to continue...");
                Console.ReadKey();
            }
        }
        public void DeleteACustomer()
        {
            Console.WriteLine("Please enter the Customer ID of the customer you wish to delete.");
            var customerID = int.Parse(Console.ReadLine());
            var customer = _repo.GetOneCustomer(customerID);
            if (customer != null)
            {
                Console.WriteLine($"We will now be deleting customer {customer.FirstName} {customer.LastName}");
                _repo.DeleteCustomer(customer.CustomerID);
                Console.WriteLine($"Press any key to continue to return to the menu..");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("This is not a valid Customer ID. Please confirm the number and try again..\n" +
                    "Press any key to continue...");
                Console.ReadKey();
            }


        }
        public void EditCustomer()
        {
            Console.WriteLine("Please enter the CustomerID you wish to update");
            var customerID = int.Parse(Console.ReadLine());
            var customer = _repo.GetOneCustomer(customerID);
            if (customer != null)
            {
                bool editMenu = true;
                while (editMenu)
                {
                    Console.Clear();
                    Console.WriteLine("We have pulled customer \n" +
                        $"{customer.FirstName} {customer.LastName} \n" +
                        $"What do you wish to edit? \n" +
                        $"1) First Name --- {customer.FirstName}\n" +
                        $"2) Last Name --- {customer.LastName}\n" +
                        $"3) Customer type ---{customer.TypeOfCustomer}\n" +
                        $"4) Default Email Content. ---{customer.EmailContent}\n" +
                        $"5) Finish editing");
                    var editOption = Console.ReadLine();
                    switch (editOption)
                    {
                        case "1":
                            {
                                Console.WriteLine("What is correct First Name? ");
                                customer.FirstName = Console.ReadLine();
                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine("What is the correct Last Name?");
                                customer.LastName = Console.ReadLine();
                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine("Please choose the correst customer type? \n" +
                                    "Please choose from below. \n" +
                                    "1) Current \n" +
                                    "2) Past \n" +
                                    "3) Potential \n ");
                                var customerType = int.Parse(Console.ReadLine());
                                customer.TypeOfCustomer = (CustomerType)customerType;
                                break;
                            }
                        case "4":
                            {
                                Console.WriteLine("What would you like to change the email content to?");
                                customer.EmailContent = Console.ReadLine();
                                break;
                            }
                        case "5":
                            {
                                _repo.UpdateCustomer(customer);
                                editMenu = false;
                                break;
                            }
                    }

                }

            }
            else
            {
                Console.WriteLine("This is not a valid Customer ID. Please confirm the number and try again..\n" +
                    "Press any key to return to the main menu");
                Console.ReadKey();
            }
        }
        public void AddNewCustomer()
        {
            Console.WriteLine("Welcome to the Create A Customer portal! \n" +
                "Let us start off with the Customer ID please..");
            var newCustomer = new Customer();
            var customerID = int.Parse(Console.ReadLine());
            if (_repo.GetOneCustomer(customerID) == null)
            {
                newCustomer.CustomerID = customerID;
                Console.WriteLine("Thank you! \n" +
                    "Now please enter the first name of the customer.");
                newCustomer.FirstName = Console.ReadLine();
                Console.WriteLine("Now Please enter the Last Name");
                newCustomer.LastName = Console.ReadLine();
                Console.WriteLine("Very good. Now Please choose what type of customer they are from the options below \n" +
                    "1) Current \n" +
                    "2) Past \n" +
                    "3) Potential \n");
                var customerType = int.Parse(Console.ReadLine());
                newCustomer.TypeOfCustomer = (CustomerType)customerType;
                _repo.AddNewCustomer(newCustomer);
                Console.WriteLine("Thank you! And a hiphooray for the new customer. \n" +
                    "Press any key to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("There is already a customer with that ID, you are being returned to the main menu.. \n" +
                    "Please press any key");
                Console.ReadLine();
            }
        }
        public void ShowAllCustomers()
        {
            var headers = string.Format("|| {0,15} {1,15} {2,15} {3,20} ||", "First Name", "Last Name", "Customer Type ", "Email Content");
            var allCustomers = _repo.ReturnAllCustomer();
            Console.WriteLine(headers);
            foreach (Customer customer in allCustomers)
            {
                var content = string.Format("|| {0,15} {1,15} {2,15} {3,20} ||", customer.FirstName, customer.LastName, customer.TypeOfCustomer, customer.EmailContent);
                Console.WriteLine(content);
            }
            Console.WriteLine("Press any key to return to the menu..");
            Console.ReadKey();
        }
        public void SeedData()
        {
            var cOne = new Customer(1234, "Amanda", "Knight", "This is only a test", CustomerType.Potential);
            var cTwo = new Customer(456, "Ing", "TheBombDotCom", "This is only a test", CustomerType.Potential);
            var cThree = new Customer(8897, "Josh", "DoesHisBest", "This is only a test", CustomerType.Potential);
            var cFour = new Customer(2222, "Becky", "TheTraitor", "This is only a test", CustomerType.Potential);
            var cFive = new Customer(8484829, "Banana", "TheOneAndOnly", "This is only a test", CustomerType.Potential);
            _repo.AddNewCustomer(cOne);
            _repo.AddNewCustomer(cTwo);
            _repo.AddNewCustomer(cThree);
            _repo.AddNewCustomer(cFour);
            _repo.AddNewCustomer(cFive);
        }
    }
}
