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
                "4. Delete a Badge\n" +
                "5. Exit");

                string input = Console.ReadLine();

                Console.Clear();
                switch (input)
                {
                    case "1":
                        var _doorNames = new List<string>();
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
                                string inpt = Console.ReadLine().ToUpper();
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
                                        doorUpdate = false;
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
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Delete badge ID:");
                        string inputAsStr = Console.ReadLine();
                        int badgeid = int.Parse(inputAsStr);
                        _repo.DeleteBadge(badgeid);
                        break;
                    case "5":
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
            var _doorNames1 = new List<string>();
            _doorNames1.Add("A7");
            _repo.AddBadge(12345, _doorNames1);

            var _doorNames2 = new List<string>();
            _doorNames2.Add("A1");
            _doorNames2.Add("A4");
            _doorNames2.Add("B1");
            _doorNames2.Add("B2");
            _repo.AddBadge(22345, _doorNames2);

            var _doorNames3 = new List<string>();
            _doorNames3.Add("A4");
            _doorNames3.Add("A5");
            _repo.AddBadge(32345, _doorNames3);
            
        }

    }
}
