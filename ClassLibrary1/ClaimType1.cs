using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsRepository
{
    public enum ClaimType { Theft, Car, Home }
    public class Claims
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateofIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                var days = (DateOfClaim - DateofIncident).TotalDays;
                if (days <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Claims() { }

        public Claims(int id, ClaimType claimType, string description, decimal amount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = id;
            TypeOfClaim = claimType;
            Description = description;
            ClaimAmount = amount;
            DateofIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}