using System;
using Akka.Actor;
using AkkaPOC.Actors;
using AkkaPOC.Messages;

namespace AkkaPOC
{
    class Program
    {

        private static ActorSystem MyActorSystem; // Change to better naming
        static void Main(string[] args)
        {
            MyActorSystem = ActorSystem.Create("MyActorSystem");
            Console.WriteLine("MyActorSystem is up!");

            Props myProps = Props.Create<ClaimFetcherActor>();

            IActorRef claimFetcherActorRef = MyActorSystem.ActorOf(myProps, "claimFetcher");

            claimFetcherActorRef.Tell(new FetchClaimMessage(Guid.NewGuid()));
            

            Console.ReadLine();

            MyActorSystem.Terminate();
        }
    }
}
