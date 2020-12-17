using KomodoEmail_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoEmail_Console
{
    public class ProgramUI
    {
        public void Run()
        {
            Seed();
            Menu();
        }
        private Customer cust = new Customer();
        private CustomerRepo repo = new CustomerRepo();
        
        private void Menu()
        {
            bool active = true;
            while (active)
            {
                Console.WriteLine("What would you like to do?\n" +
                    "1. Add a Customer/Lead\n" +
                    "2. Update a Customer/Lead\n" +
                    "3. View all Customer/Leads\n" +
                    "4. Remove a Customer/Lead\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                Console.Clear();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Enter Customer First Name");
                        cust.FirstName = Console.ReadLine();
                        Console.WriteLine("Enter Customer Last Name");
                        cust.LastName= Console.ReadLine();
                        Console.WriteLine("Select Customer Type:\n" +
                            "1. Current\n" +
                            "2. Future\n" +
                            "3. Past");
                        string inputAsString = Console.ReadLine();

                        
                        repo.AddCustomer(cust); 
                        break;
                    case "2":

                        break;
                    case "3":

                        break;
                    case "4":

                        break;
                    case "5":
                        active = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        break;
                }
            }
        }

        private void Seed()
        {

        }
    }

    
}
