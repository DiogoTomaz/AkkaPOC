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


            // Setting the default behavior
            ManualOpening();
        }

        public void ManualOpening()
        {
            // State this actor is able to receive 'OpenClaimMessage' and redirect to handler method
            // Define a predicate on when to receive a message, in this case only for messages that have Number and Year > 0
            Receive<ManualOpenClaimMessage>(HandleManualClaimOpeningRequest, message => message.Number > 0 && message.Year > 0);
        }

        public void AutomaticOpening()
        {
            Receive<AutomaticallyOpenClaimMessage>(HandleAutomaticallyClaimOpeningRequest, message => message.Number > 0 && message.Year > 0);
        }

        private void HandleManualClaimOpeningRequest(ManualOpenClaimMessage message)
        {
            Console.WriteLine("Attempting to manual open claim with id: " + message.Number + "/" + message.Year);            

            // Change the behavior to now Automatically open claims
            Become(AutomaticOpening);

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Changed behavior to auto");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void HandleAutomaticallyClaimOpeningRequest(AutomaticallyOpenClaimMessage message)
        {
            Console.WriteLine("Attempting to automatically open claim with id: " + message.Number + "/" + message.Year);

            // Change the behavior to now Manually open claims
            Become(ManualOpening);


            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Changed behavior to manual");
            Console.ForegroundColor = ConsoleColor.White;
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
