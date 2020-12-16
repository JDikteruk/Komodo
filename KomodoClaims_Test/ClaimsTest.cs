using System;
using KomodoClaims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoClaims_test
{
    [TestClass]
    public class Claims_Test
    {
        [TestMethod]
        public void SetClaimType_ShouldSetCorrectType()
        {
            Claims claim = new Claims();

            claim.TypeOfClaim = ClaimType.Car;

            ClaimType expected = ClaimType.Car;
            ClaimType actual = claim.TypeOfClaim;

            Assert.AreEqual(expected, actual);
        }
        
        //CultureInfo us = new CultureInfo("en-US");

        [DataTestMethod]
        [DataRow("10/5/2020", "10/25/2020", true)]
        [DataRow("9/8/2020", "10/22/2020", false)]
        public void ClaimValid_ShouldReturnGiven(string dateOfLoss, string dateOfClaim, bool islessthan31)
        {
            Claims claim = new Claims();
            claim.DateOfIncident = DateTime.Parse(dateOfLoss);
            claim.DateOfClaim = DateTime.Parse(dateOfClaim);

            bool expected = islessthan31;
            bool actual = claim.IsValid;

            Assert.AreEqual(expected, actual);
        }
    }
}
