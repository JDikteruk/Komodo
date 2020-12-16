using KomodoBadge;
using KomodoBadge_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadge_Console
{
    public class ProgramUI
    {
        private Badge _badge = new Badge();
        private BadgeRepo _repo = new BadgeRepo();
        private List<string> _doorNames = new List<string>();
        public void Run()
        {
            Seed();
            Menu();
        }

        private void Menu()
        {
            bool active = true;
            while (active)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                "1. Add a badge\n" +
                "2. Edit a badge\n" +
                "3. List all Badges\n" +
                "4. Exit");

                string input = Console.ReadLine();

                Console.Clear();
                switch (input)
                {
                    case "1":
                        bool idLoop = true;
                        while (idLoop)
                        {
                            Console.WriteLine("What is the Badge ID?");
                            string badgeAsString = Console.ReadLine();
                            int badgeID = int.Parse(badgeAsString);
                            bool doorUpdate = true;
                            while (doorUpdate)
                            {
                                Console.WriteLine("Grant access to door:");
                                string inpt = Console.ReadLine();
                                _doorNames.Add(inpt);
                                Console.WriteLine("Add another door (y/n) ?");

                                string inp = Console.ReadLine().ToLower();

                                switch (inp)
                                {
                                    case "y":
                                        break;
                                    case "n":
                                        doorUpdate = false;
                                        idLoop = false;
                                        break;
                                    default:
                                        Console.WriteLine("Please enter a valid option.");
                                        break;
                                }
                            }
                            _repo.AddBadge(badgeID, _doorNames);
                        }
                        break;

                    case "2":
                        Console.WriteLine("Update badge ID:");
                        string inputAsString = Console.ReadLine();
                        int badge = int.Parse(inputAsString);
                        _repo.UpdateBadgeAccess(badge);
                        break;
                    case "3":
                        _repo.GetBadgeList();
                        break;
                    case "4":
                        active = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        //Seed Badge List
        private void Seed()
        {
            _doorNames.Add("A7");
            _repo.AddBadge(12345, _doorNames);
            _doorNames.Clear();

            _doorNames.Add("A1");
            _doorNames.Add("A4");
            _doorNames.Add("B1");
            _doorNames.Add("B2");
            _repo.AddBadge(22345, _doorNames);
            _doorNames.Clear();

            _doorNames.Add("A4");
            _doorNames.Add("A5");
            _repo.AddBadge(32345, _doorNames);
            _doorNames.Clear();
        }

    }
}
