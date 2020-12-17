using KomodoBadge;
using KomodoBadge_Repo;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using KomodoBadge_Console;

namespace KomodoBadge_Test
{
    [TestClass]
    public class BadgeRepoTest
    {
        private Badge _badge = new Badge();
        private BadgeRepo _repo = new BadgeRepo();

        [TestInitialize]
        public void Setup()
        {
            Seed();
        }
        
        [TestMethod]
        public void AddBadgeTest()
        {
            List<string> doorNames = new List<string>();
            doorNames.Add("A2");
            doorNames.Add("A3");
            doorNames.Add("B5");

            int badgeID = 54321;

            Badge newBadge = new Badge(badgeID, doorNames);

            Assert.IsNotNull(newBadge);
        }

        [TestMethod]
        public void DeleteBadgeTest()
        {
            
            _badge.BadgeID = 12345;

            bool del = _repo.DeleteBadge(_badge.BadgeID);

            Assert.IsTrue(del);

        }



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
