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
                Console.Clear();
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
                        cust.LastName = Console.ReadLine();
                        Console.WriteLine("Select Customer Type:\n" +
                            "1. Current\n" +
                            "2. Future\n" +
                            "3. Past");
                        string inputAsString = Console.ReadLine();
                        int inputAsInt = int.Parse(inputAsString);
                        cust.Type = (CustType)inputAsInt;

                        repo.AddCustomer(cust);
                        break;
                    case "2":
                        Console.WriteLine("Enter Customer First Name");
                        string oldfName = Console.ReadLine();
                        Console.WriteLine("Enter Customer Last Name");
                        string oldlName = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Enter Customer Updated First Name");
                        cust.FirstName = Console.ReadLine();
                        Console.WriteLine("Enter Customer Updated Last Name");
                        cust.LastName = Console.ReadLine();
                        Console.WriteLine("Select Customer Type:\n" +
                            "1. Current\n" +
                            "2. Future\n" +
                            "3. Past");
                        string inputAsStr = Console.ReadLine();
                        int inptAsInt = int.Parse(inputAsStr);
                        cust.Type = (CustType)inptAsInt;
                        repo.UpdateCustomer(oldfName, oldlName, cust);
                        break;
                    case "3":
                        List<Customer> custList = repo.GetCustomers();
                        Console.WriteLine("FirstName\tLastName\tType\tMessage");
                        foreach (Customer cust in custList)
                        {
                            Console.WriteLine(cust.FirstName + "\t" + cust.LastName + "\t" + cust.Type + "\t" + cust.Message);
                        }

                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Enter Customer First Name");
                        string fName = Console.ReadLine();
                        Console.WriteLine("Enter Customer Last Name");
                        string lName = Console.ReadLine();
                        repo.RemoveCustomer(fName, lName);
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
            var cust1 = new Customer("Jake","Smith",CustType.Future);
            var cust2 = new Customer("James", "Smith", CustType.Current);
            var cust3 = new Customer("Jane", "Smith", CustType.Past);

            repo.AddCustomer(cust1);
            repo.AddCustomer(cust2);
            repo.AddCustomer(cust3);

        }
    }


}
