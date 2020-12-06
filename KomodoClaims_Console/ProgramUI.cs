using KomodoClaims;
using KomodoClaims_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Console
{
    class ProgramUI
    {
        private ClaimsRepo _claimsRepo = new ClaimsRepo();
        public void Run()
        {
            Menu();
        }

        //Main Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Options
                Console.WriteLine("Choose a Menu Option:\n" +
                    "1. See All Claims\n" +
                    "2. Process Existing Claim\n" +
                    "3. Enter a New Claim\n" +
                    "4. Exit");

                //User Input
                string input = Console.ReadLine();

                //Evaluate Input
                switch (input)
                {
                    case "1":
                        //See All Claims
                        DisplayAllClaims();
                        break;
                    case "2":
                        //Process Existing
                        ProcessClaim();
                        break;
                    case "3":
                        //Enter New
                        NewClaim();
                        break;
                    case "4":
                        //Exit
                        keepRunning = false;
                        Console.WriteLine("Press any key to log off.");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Please Enter a Valid Option.");
                        break;
                }

                Console.Clear();
            }

        }

        //See All Claims
        private void DisplayAllClaims()
        {

        }

        //Process Claim
        private void ProcessClaim()
        {

        }

        //Enter New Claim
        private void NewClaim()
        {
            Console.Clear();
            Claims newClaim = new Claims();

            //ClaimID
            newClaim.ClaimID = _claimsRepo.GetListOfClaims().Count + 1;

            //ClaimType
            Console.WriteLine("Enter a number for Type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string inputAsString = Console.ReadLine();
            int inputAsInt = int.Parse(inputAsString);
            newClaim.TypeOfClaim = (ClaimType)inputAsInt;

            //Description
            Console.WriteLine("Please enter a brief description:");
            newClaim.Description = Console.ReadLine();

            //ClaimAmount
            Console.WriteLine("What is the dollar amount of the claim?");
            string amountAsString= Console.ReadLine();
            newClaim.ClaimAmount = double.Parse(amountAsString);

            //DateOfLoss
            Console.WriteLine("What is the date of incident?");
            string dateOfLossString = Console.ReadLine();
            newClaim.DateOfIncident = DateTime.Parse(dateOfLossString);

            //DateOfClaim
            Console.WriteLine("What is the reporting date of this claim?");
            string dateOfClaimString = Console.ReadLine();
            newClaim.DateOfClaim = DateTime.Parse(dateOfClaimString);
            
            
            _claimsRepo.AddClaim(newClaim);
        }
    }
}
