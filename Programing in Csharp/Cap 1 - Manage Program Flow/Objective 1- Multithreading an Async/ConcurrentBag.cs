using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    public class ConcurrentBagClass
    {
        public void usingConcurrentBag() {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();

            bag.Add(42);
            bag.Add(21);

            int result;
            if (bag.TryTake(out result))
                Console.WriteLine(result);

            //este methodo no es muy utilizable en un ambiente multihilo
            if (bag.TryPeek(out result))
                Console.WriteLine("There is a next item: {0}", result);



        }

        public void usingForToConcurrentBag() {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();

            Task.Run(() =>
            {
                bag.Add(42);
                Thread.Sleep(1000);
                bag.Add(21);
            });

            Task.Run(() =>
            {
                foreach (int i in bag)
                {
                    Console.WriteLine(i);
                }
            }).Wait();

        }
    }
}
