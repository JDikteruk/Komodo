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
            SeedClaimsList();
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
                Console.Clear();

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
            //Queue & peek method
            //_queue.queue
            //_queue.dequeue

            Queue<Claims> _queue = _claimsRepo.GetQueueOfClaims();

            if (_queue!= null)
            {
                Console.WriteLine("Claim ID\t " +
                  "Type\t" +
                  "Dscription\t\t" +
                  "Amount\t" +
                  "DateOfAccident\t" +
                  "DateOfClaim\t" +
                  "IsValid");

                foreach (Claims claim in _queue)
                { Console.WriteLine(claim.ClaimID.ToString() + "\t" + claim.TypeOfClaim + "\t" + claim.Description + "\t" + claim.ClaimAmount + "\t" + claim.DateOfIncident + "\t" + claim.DateOfClaim + "\t" + claim.IsValid); }
                

            }
            else
            {
                Console.WriteLine("No Claims Currently Exist.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        //Process Claim
        private void ProcessClaim()
        {
            Queue<Claims> _queue = _claimsRepo.GetQueueOfClaims();

            Claims claim = _queue.Peek();

            Console.WriteLine($"ClaimID: {claim.ClaimID}\n" +
                $"Type: {claim.TypeOfClaim}\n" +
                $"Description: {claim.Description}\n" +
                $"Amount: {claim.ClaimAmount}\n" +
                $"DateOfAccident: {claim.DateOfIncident}\n" +
                $"DateOfClaim: {claim.DateOfClaim}\n" +
                $"IsValid: {claim.IsValid}\n");


            Console.WriteLine("Do you want to deal with this claim now (y/n)?");
            string input = Console.ReadLine().ToLower();

            switch(input)
            {
                case "y":
                    _queue.Dequeue();
                    break;
                case "n":
                    break;
                default:
                    Console.WriteLine("Please enter a valid option.");
                    break;
            }
        }

        //Enter New Claim
        private void NewClaim()
        {
            Claims newClaim = new Claims();

            //ClaimID
            newClaim.ClaimID = _claimsRepo.GetQueueOfClaims().Count + 1;

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

        //Seed Claims
        private void SeedClaimsList()
        {
            Claims claim1 = new Claims(1, ClaimType.Car,"Car accident on 464", 400.00, "4/25/18", "4/27/18");
            Claims claim2 = new Claims(2, ClaimType.Home, "House fire in kitchen", 4000, "4/11/18", "4/12/18");
            Claims claim3 = new Claims(3, ClaimType.Theft, "Stolen pancakes", 4,"4/27/18", "6/1/18");

            _claimsRepo.AddClaim(claim1);
            _claimsRepo.AddClaim(claim2);
            _claimsRepo.AddClaim(claim3);
        }



    }
}
