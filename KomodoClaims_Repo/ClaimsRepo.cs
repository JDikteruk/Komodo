using KomodoClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Repo
{
    public class ClaimsRepo
    {
        private List<Claims> _listOfClaims = new List<Claims>();
        
        //Create
        public void AddClaim(Claims detail)
        {
            _listOfClaims.Add(detail);
        }

        //Read
        public List<Claims> GetListOfClaims()
        {
            return _listOfClaims;
        }

        //Update
        public bool UpdateClaimDetails(int claimID, Claims newParm )
        {
            //Find Claim
            Claims oldClaim = GetClaimByID(claimID);

            //Update Claim
            if(oldClaim != null)
            {
                oldClaim.ClaimID = newParm.ClaimID;
                oldClaim.TypeOfClaim = newParm.TypeOfClaim;
                oldClaim.Description = newParm.Description;
                oldClaim.ClaimAmount = newParm.ClaimAmount;
                oldClaim.DateOfIncident = newParm.DateOfIncident;
                oldClaim.DateOfClaim = newParm.DateOfClaim;
                oldClaim.IsValid = newParm.IsValid;
                
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveClaim(int id)
        {
            Claims claim = GetClaimByID(id);

            if (claim == null)
            {
                return false;
            }

            int initialCount = _listOfClaims.Count;
            _listOfClaims.Remove(claim);
            if (initialCount > _listOfClaims.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper
        public Claims GetClaimByID(int id)
        {
            foreach(Claims claim in _listOfClaims)
            {
                if(claim.ClaimID == id)
                {
                    return claim;
                }
            }

            return null;
        }
    }
}
