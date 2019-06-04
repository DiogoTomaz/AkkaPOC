using System;
using System.Threading.Tasks;
using Akka.Actor;
using AkkaPOC.Actors;
using AkkaPOC.Messages;

namespace AkkaPOC
{
    class Program
    {

        private static ActorSystem ClaimHandlingSystem; // Change to better naming
        static async Task Main(string[] args)
        {
            ClaimHandlingSystem = ActorSystem.Create("ClaimHandlingSystem");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Claim Handling System is up!");
            Console.ForegroundColor = ConsoleColor.White;

            Props claimFetchProps = Props.Create<ClaimFetcherActor>();
            Props openClaimProps = Props.Create<OpenClaimActor>();

            IActorRef claimFetcherActorRef = ClaimHandlingSystem.ActorOf(claimFetchProps, "claimFetcher");
            IActorRef claimOpenerActorRef = ClaimHandlingSystem.ActorOf(openClaimProps, "claimOpener");

            claimFetcherActorRef.Tell(new FetchClaimMessage(Guid.NewGuid()));
            claimFetcherActorRef.Tell(new FetchClaimMessage(Guid.NewGuid()));

            claimOpenerActorRef.Tell(new ManualOpenClaimMessage(0, 0)); // Won't be handled
            claimOpenerActorRef.Tell(new ManualOpenClaimMessage(4000, 2019));
            claimOpenerActorRef.Tell(new AutomaticallyOpenClaimMessage(5000, 2019));

            Console.ReadKey();

            // Tells the actor to shutdown, BUT first deal with all the messages in it's mail box
            claimFetcherActorRef.Tell(PoisonPill.Instance);

            // Gracefully stop the actor, awaiting 5 seconds. If more time passes, throw exception
            await claimOpenerActorRef.GracefulStop(TimeSpan.FromSeconds(5));

            Console.ReadKey();
            
            await ClaimHandlingSystem.Terminate();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Claim Handling System is down!");
            Console.ForegroundColor = ConsoleColor.White;

            Console.ReadKey();
        }
    }
}
