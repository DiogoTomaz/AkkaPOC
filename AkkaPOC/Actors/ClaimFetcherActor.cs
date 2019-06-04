using Akka.Actor;
using System;
using AkkaPOC.Messages;

namespace AkkaPOC.Actors
{
    public class ClaimFetcherActor : UntypedActor // The simplest for of an Actor declaration
    {
        public ClaimFetcherActor()
        {
            Console.WriteLine("Creating a " + nameof(ClaimFetcherActor));
        }

        protected override void OnReceive(object message)
        {
            if (message is FetchClaimMessage fetchMessage)
            {
                Console.WriteLine("Received fetch request for claim Id: " + fetchMessage.ClaimId);                
            }
            else
            {
                Unhandled(message); // Recommended approach to message that won't be handled. They should be handled up stream.
            }
        }

        protected override void PreStart()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Opening DB Connection!");
            Console.ForegroundColor = ConsoleColor.White;            
        }

        protected override void PostStop()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Disposing of DB Connection");
            Console.ForegroundColor = ConsoleColor.White;            
        }
    }
}
