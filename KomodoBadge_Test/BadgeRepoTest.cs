using KomodoBadge;
using KomodoBadge_Repo;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace KomodoBadge_Test
{
    [TestClass]
    public class BadgeRepoTest
    {
        private Badge _badge;
        private BadgeRepo _repo;
        
        [TestMethod]
        public void AddBadgeTest()
        {
            List<string> doorNames = new List<string>();
            doorNames.Add("A2");
            doorNames.Add("A3");
            doorNames.Add("B5");

            int badgeID = 12345;

            Badge newBadge = new Badge(badgeID, doorNames);

            Assert.IsNotNull(newBadge);
        }
        
        [TestMethod]
        public void DeleteBadgeTest()
        {

        }
    }
    

}
