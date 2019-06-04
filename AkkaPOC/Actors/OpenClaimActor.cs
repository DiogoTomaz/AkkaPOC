using System;
using System.Collections.Generic;
using System.Text;
using Akka.Actor;
using AkkaPOC.Messages;

namespace AkkaPOC.Actors
{
    public class OpenClaimActor : ReceiveActor
    {
        public OpenClaimActor()
        {
            Console.WriteLine("Creating a " + nameof(OpenClaimActor));

            // State this actor is able to receive 'OpenClaimMessage' and redirect to handler method
            // Define a predicate on when to receive a message, in this case only for messages that have Number and Year > 0
            Receive<OpenClaimMessage>(HandleClaimOpeningRequest, message => message.Number > 0 && message.Year > 0);
        }

        private void HandleClaimOpeningRequest(OpenClaimMessage message)
        {
            Console.WriteLine("Attempting to open claim with id: " + message.Number + "/" + message.Year);
        }
    }
}
