using _02_Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KClaims
{
    public class ProgramUI
    {
        private ClaimRepo _repo = new ClaimRepo();
        public void Run()
        {
            SeedTheQueue();
            OpenMainMenu();
        }
        public void OpenMainMenu()
        {
            bool openMenu = true;
            while (openMenu)
            {
                Console.Clear();
                Console.WriteLine("Choose a menu item: \n" +
                    "1. See all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter a new claim \n" +
                    "4. Close menu");
                var menuOption = Console.ReadLine();
                switch (menuOption)
                {
                    case "1":
                        {
                            ShowAllClaims();
                            break;
                        }
                    case "2":
                        {
                            TakeCareOfNextClaim();
                            break;
                        }
                    case "3":
                        {
                            AddNewClaim();
                            break;
                        }
                    case "4":
                        {
                            openMenu = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please choose option listed. \n" +
                                "Press any key to return to the menu...");
                            Console.ReadKey();
                            break;
                        }
                }
            }

        }

        public void ShowAllClaims()
        {
            var headers = String.Format("|{0,8} {1,10} ${2,10} {3,15} {4,15} {5,10}|", "ClaimID", "Type", "Amount", " DateOfAccident", "DateOfClaim", "IsTrue");
            Console.WriteLine(headers);
            var claimList =_repo.ShowAllClaims().ToList();
            foreach(Claim claim in claimList)
            {
                var content = String.Format("|{0,8} {1,10} {2,10} {3,15} {4,15} {5,10} |", claim.ClaimID,claim.TypeOfClaim,claim.ClaimAmount,claim.DateOfIncident.ToString("d"),claim.DateOfClaim.ToString("d"), claim.IsValid);
                Console.WriteLine(content);
                
            }
            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey();
        }
        public void TakeCareOfNextClaim()
        {
            var nextClaim = _repo.ShowNextInLine();
            Console.WriteLine($"Here are the details for the next claim to be handled \n" +
                $"ClaimID: {nextClaim.ClaimID} \n" +
                $"Type: {nextClaim.TypeOfClaim} \n" +
                $"Description: {nextClaim.Description} \n" +
                $"Amount: ${nextClaim.ClaimAmount} \n" +
                $"Date Of Accident: {nextClaim.DateOfIncident} \n" +
                $"Date Of Claim: {nextClaim.DateOfClaim} \n" +
                $"Valid claim?: {nextClaim.IsValid} \n" +
                $"Do you want to deal with this claim now (y/n)?");
            var userInput = Console.ReadLine().ToLower();
            switch (userInput)
            {
                case "y":
                    {
                        _repo.RemoveClaimFromQueue();
                        break;
                    }
                case "n":
                    {

                        break;
                    }
                default:
                    {
                        Console.WriteLine("Please enter y or n..\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
            }
        }
        public void AddNewClaim()
        {
            var newClaim = new Claim();
            Console.WriteLine("Welcome! \n" +
                "Let us get the new claim entered \n" +
                "Please enter the Claim ID. ");
            newClaim.ClaimID = int.Parse(Console.ReadLine());
            Console.WriteLine("Thank you! \n" +
                "Now please enter a brief description of the claim");
            newClaim.Description = Console.ReadLine();
            Console.WriteLine("Perfect! \n" +
                "Please choose the type of claim from the options below...\n" +
                "1) Car \n" +
                "2) Home \n" +
                "3) Theft \n");
            var claimType = int.Parse(Console.ReadLine());
            newClaim.TypeOfClaim = (ClaimType)claimType;
            Console.WriteLine("Now, please enter the claim amount. ");
            newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter the date of the accident in the following format 2019,12,25 (year,month,day)");
            var doi = Console.ReadLine();
            newClaim.DateOfIncident = DateTime.Parse(doi);
            Console.WriteLine("Almost done, the final piece of data we need is the date the claim is being filed. \n" +
                "Enter the date in the following format 2019,12,25 (year,month,day)");
            var doc = Console.ReadLine();
            newClaim.DateOfClaim = DateTime.Parse(doc);
            _repo.AddNewClaim(newClaim);
            Console.WriteLine("If the information above has been entered correctly the claim will be saved into the queue. \n" +
                "Please press any key to continue..");
            Console.ReadKey();
        }
        public void SeedTheQueue()
        {
            var claimOne = new Claim(8675309, ClaimType.Home, "Tornado moved house on top of a witch", new DateTime(2019,12,03), new DateTime(2019,12,15), 100000.235m);
            var claimTwo = new Claim(222, ClaimType.Theft, "One heart, in poor condition", new DateTime(2012,12,12), new DateTime(2014,4,14), 42);
            var claimThree = new Claim(12290, ClaimType.Car, "Dude...where is my car?", new DateTime(2019,4,13), new DateTime(2019,4,25), 50);
            var claimFour = new Claim(898989, ClaimType.Home, "Roof was removed by unknown source", new DateTime(2013,3,3), new DateTime(2013,3,13), 130000.23m);
            _repo.AddNewClaim(claimOne);
            _repo.AddNewClaim(claimTwo);
            _repo.AddNewClaim(claimThree);
            _repo.AddNewClaim(claimFour);
        }
    }
}
