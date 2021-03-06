﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    public enum ClaimType { Car = 1, Home, Theft }
    public class Claims
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim{ get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
            // infinite loop
        {
            get
            {
                return DateOfClaim.Subtract(DateOfIncident).Days < 31; 
            }
            set
            {
                IsValid = DateOfClaim.Subtract(DateOfIncident).Days < 31; 
            }
        }

        public Claims() { }

        public Claims(int claimID, ClaimType typeOfClaim, string description, double claimAmount, string dateOfIncident, string dateOfClaim)
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = DateTime.Parse(dateOfIncident);
            DateOfClaim = DateTime.Parse(dateOfClaim);
        }
    }
}
