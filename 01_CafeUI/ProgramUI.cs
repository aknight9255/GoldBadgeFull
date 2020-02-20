using _01_Cafe;
using SecondGold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeUI
{
    public class ProgramUI
    {
        private MenuRepo _menuRepo = new MenuRepo();
        public void Run()
        {
            SeedSomeData();
            OpenMenu();
        }

        public void OpenMenu()
        {
            bool menuRemainOpen = true;
            while (menuRemainOpen)
            {
                Console.Clear();
                Console.WriteLine("Please choose an option from below \n" +
                    "1) Show All Menu Items \n" +
                    "2) Add New Menu Item \n" +
                    "3) Delete Menu Item \n" +
                    "4) Exit");
                var UserRespone = Console.ReadLine();
                switch (UserRespone)
                {
                    case "1":
                        {
                            ShowAllItems();
                            break;
                        }
                    case "2":
                        {
                            AddNewItem();
                            break;
                        }
                    case "3":
                        {
                            DeleteMenuItem();
                            break;
                        }
                    case "4":
                        {
                            menuRemainOpen = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter in a number from 1-4 \n" +
                                "Press any key to continue..... \n");
                            Console.ReadKey();
                            break;

                        }
                }

            }

        }



        public void ShowAllItems()
        {
            var menu = _menuRepo.GetFullMenu();
            foreach (Menu item in menu)
            {
                Console.WriteLine($"{item.MealNumber}) {item.MealName} - - - ${item.Price} \n" +
                    $"{item.Description} \n" +
                    $"Ingredients - ");
                foreach (string ing in item.ListOfIngredients)
                {
                    Console.Write($" {ing}, ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("---------------------------\n" +
                "Press any key to continue");
            Console.ReadKey();

        }

        public void AddNewItem()
        {
            Menu menuItem = new Menu();
            Console.WriteLine("Enter the new menu item number, please choose the next in line and remember not to duplicate(if you duplicate your new menu item will not be added).");
            var menuNumber = Console.ReadLine();
            menuItem.MealNumber = int.Parse(menuNumber);
            Console.WriteLine("Thank you! \n" +
                "Next please enter a name for the Menu item");
            menuItem.MealName = Console.ReadLine();
            Console.WriteLine("Thank you! \n" +
                "Now Please enter a description for the menu item.");
            menuItem.Description = Console.ReadLine();
            Console.WriteLine("Perfect! \n" +
                "Please enter the price of the new menu item.");
            var price = Console.ReadLine();
            menuItem.Price = decimal.Parse(price);
            bool isAddingIng = true;
            Console.WriteLine("Almost done! \n" +
                "Now we will enter the ingredients one at a time \n" +
                "Please Enter the first ingredient..");
            List<string> _ingred = new List<string> { Console.ReadLine() };
            while (isAddingIng)
            {
                Console.WriteLine("Press 1 to add another ingregient  \n" +
                    "Press 2 when you finish adding the last ingredient and wish to save your new menu item");
                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        {
                            Console.WriteLine("Please enter ingredient...");
                            _ingred.Add(Console.ReadLine());
                            break;
                        }
                    case "2":
                        {
                            menuItem.ListOfIngredients = _ingred;
                            _menuRepo.AddMenuItem(menuItem);
                            isAddingIng = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter 1 or 2 \n" +
                                "press any key to continue....");
                            Console.ReadKey();
                            break;
                        }
                }
            }

        }

        public void DeleteMenuItem()
        {
            var options = _menuRepo.GetFullMenu();
            Console.WriteLine("Which Item do you want to delete?");
            foreach(Menu item in options)
            {
                Console.WriteLine($"{item.MealNumber}){item.MealName}");
            }
            Console.WriteLine("Please enter a numerical value");
            var id = int.Parse(Console.ReadLine());
            _menuRepo.DeleteMenutItem(id);
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        public void SeedSomeData()
        {
            var anotherItem = new Menu(2, "Salad", "what is a sa-la-d", 2.48m, new List<string> { "Something called lettuce", "one tomato", "how about a little cheese?", "some cronch, some bread cronch" });
            var oneMoreItem = new Menu(3, "Ice Cream", "healing to the soul but not to the thighs", 1.65m, new List<string> { "Ice", "Cream" });
            var AnotherOne = new Menu(1, "Taters", "not a full meal but close", 3.99m, new List<string> { "tater", "butter", "cheese", "chives", "chili", "bacon", "sour cream" });
            var test = new Menu(4, "Lemonade", "More lemonade than you need or want but you will drink it anyway", 6.85m, new List<string> { "lemons", "More Lemons", "a dash and a half of sugar", "some water", "maybe a little H2O", "sunshine" });
            var testingTest = new Menu(5, "nothing", "for the person who says they want nothing but really want some of your fries", 1.99m, new List<string> { "half order of fries" });
            _menuRepo.AddMenuItem(AnotherOne);
            _menuRepo.AddMenuItem(anotherItem);
            _menuRepo.AddMenuItem(oneMoreItem);
            _menuRepo.AddMenuItem(test);
            _menuRepo.AddMenuItem(testingTest);

        }
    }
}
