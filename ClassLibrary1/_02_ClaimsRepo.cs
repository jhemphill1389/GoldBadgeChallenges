using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsRepository
{
    public class ClaimsRepo
    {
        private readonly List<Claims> _claims = new List<Claims>();

        public List<Claims> GetAllClaims()
        {
            return _claims;
        }

        public bool AddClaim(Claims claim)
        {
            int startCount = _claims.Count;
            _claims.Add(claim);
            bool wasAdded = (_claims.Count > startCount);
            return wasAdded;
        }

        public bool RemoveClaim(Claims claim)
        {
            bool removed = _claims.Remove(claim);
            return removed;
        }
    }
}