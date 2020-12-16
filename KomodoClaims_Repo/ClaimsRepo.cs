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
        private Queue<Claims> _queueOfClaims = new Queue<Claims>();
        
        //Create
        public void AddClaim(Claims detail)
        {
            _queueOfClaims.Enqueue(detail);
        }

        //Read
        public Queue<Claims> GetQueueOfClaims()
        {
            return _queueOfClaims;
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

            int initialCount = _queueOfClaims.Count;
            //_queueOfClaims.Dequeue(claim);
            if (initialCount > _queueOfClaims.Count)
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
            foreach(Claims claim in _queueOfClaims)
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
