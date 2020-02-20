using System;

namespace _02_Claims
{
    public enum ClaimType
    {
        Car =1,
        Home,
        Theft
    }
    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan validWindow = DateOfClaim - DateOfIncident;
                if(validWindow.Days < 30)
                {
                    return true;
                }
                return false;
            }
        }

        public Claim() { }
        public Claim(int claimID, ClaimType typeOfClaim,string description,DateTime dateOfIncident, DateTime dateOfClaim, decimal claimAmount)
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            Description = description;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            ClaimAmount = claimAmount;
        }
    }
}
