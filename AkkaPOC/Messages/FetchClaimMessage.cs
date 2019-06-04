using System;

namespace AkkaPOC.Messages
{
    public class FetchClaimMessage
    {
        public Guid ClaimId { get; private set; }

        public FetchClaimMessage(Guid claimId)
        {
            this.ClaimId = claimId;
        }
    }
}
