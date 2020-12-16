using KomodoBadge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadge_Repo
{
    public class BadgeRepo
    {
        private Dictionary<int, List<string>> _dictBadges = new Dictionary<int, List<string>>();


        //Create
        public void AddBadge(int badgeID, List<string> doorNames)
        {
            _dictBadges.Add(badgeID, doorNames);
        }

        //Read
        public Dictionary<int, List<string>> GetBadgeList()
        {
            Console.WriteLine("Badge #\t" +
                "Door Access");
            foreach (KeyValuePair<int, List<string>> _badges in _dictBadges)
            {
                Console.WriteLine("{0}\t{1}",
                    _badges.Key,
                    _badges.Value);
            }
            return null;
        }

        //Update
        public void UpdateBadgeAccess(int badgeID)
        {
            var badge = GetBadgeByID(badgeID);
            Console.WriteLine("Badge {0} has access to doors: {1}", badge.BadgeID, badge.DoorNames);

            //Add or Remove
            Console.WriteLine("\nWhat would you like to do?\n" +
                "\t1. Add a door\n" +
                "\t2. Remove a door\n" +
                "\t3. Exit");

            //input
            string input = Console.ReadLine();
            bool update = true;
            while (update)
            {
                Console.Clear();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Door Code to GRANT Access:");
                        string inpt = Console.ReadLine();
                        badge.DoorNames.Add(inpt);
                        break;
                    case "2":
                        Console.WriteLine("Door Code to REMOVE Access:");
                        string inp = Console.ReadLine();
                        badge.DoorNames.Remove(inp);
                        break;
                    case "3":
                        update = false;
                        break;
                    default:
                        break;
                }
            }
        }

        //Delete
        public bool DeleteBadge(int badgeID)
        {
            Badge badge = GetBadgeByID(badgeID);

            if (badge == null)
            {
                return false;
            }

            int initialCount = _dictBadges.Count;
            _dictBadges.Remove(badgeID);

            if (initialCount > _dictBadges.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper
        private Badge GetBadgeByID(int bID)
        {
            var badge = new Badge();


            if (_dictBadges.ContainsKey(bID))
            {
                badge.BadgeID = bID;
                _dictBadges.TryGetValue(bID, out List<string> doorNames);
                badge.DoorNames = doorNames;
            }

            return null;
        }
    }
}
