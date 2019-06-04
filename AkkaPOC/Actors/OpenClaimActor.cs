using Akka.Actor;
using AkkaPOC.Messages;
using System;

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

        protected override void PreRestart(Exception reason, object message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Restarting " + nameof(OpenClaimActor));
            Console.ForegroundColor = ConsoleColor.White;

            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Restarted " + nameof(OpenClaimActor));
            Console.ForegroundColor = ConsoleColor.White;

            base.PostRestart(reason);
        }
    }
}
