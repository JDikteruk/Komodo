using System;
using KomodoClaims;
using KomodoClaims_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoClaims_Test
{
    [TestClass]
    public class ClaimsRepoTest
    {
        private Claims _claim;
        private ClaimsRepo _repo;

        [TestInitialize]
        public void Setup()
        {
            _repo = new ClaimsRepo();
            _claim = new Claims(1, ClaimType.Car, "Collision NB/SB Emerson Ave @ 465W Ramp", 1427.32, "12/1/2020", "12/5/2020");

            _repo.AddClaim(_claim);
        }

        

        [TestMethod]
        public void AddClaim_ShouldReturnNotNull()
        {
            Claims claim = new Claims();
            claim.ClaimID = 1;
            ClaimsRepo repo = new ClaimsRepo();

            repo.AddClaim(claim);
            Claims claimFromList = repo.GetClaimByID(1);

            Assert.IsNotNull(claimFromList);
        }

        [TestMethod]
        public void UpdateClaim_ShouldReturnTrue()
        {
            Claims newParm = new Claims(1, ClaimType.Car, "Collision NB/SB Emerson Ave @ 465W Ramp", 3427.32, "11/25/2020", "12/5/2020");

            bool updateResult = _repo.UpdateClaimDetails(1, newParm);

            Assert.IsTrue(updateResult);
        }
    }
}
