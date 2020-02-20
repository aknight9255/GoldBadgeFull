using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Claims
{
    public class ClaimRepo
    {
        private Queue<Claim> _queueOfClaims = new Queue<Claim>();

        public Queue<Claim> ShowAllClaims()
        {
            return _queueOfClaims;
        }

        public void AddNewClaim(Claim claim)
        {
            _queueOfClaims.Enqueue(claim);
        }

        public Claim ShowNextInLine()
        {
            return _queueOfClaims.Peek();
        }

        public void RemoveClaimFromQueue()
        {
            _queueOfClaims.Dequeue();
        }
    }
}
