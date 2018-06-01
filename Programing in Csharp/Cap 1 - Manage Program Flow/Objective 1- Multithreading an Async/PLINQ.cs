using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    public class PLINQ
    {

        public void SimpleExample(int range)
        {
            var number = Enumerable.Range(0, range);
            var result = number.AsParallel()
                .Where(i => i % 2 == 0)
                .ToArray();

            Parallel.ForEach(result, n => {
                Console.WriteLine(n);
            });
        }


        public void SecuentialQuery() {

            var numbers = Enumerable.Range(0, 20);

            var parallelResult = numbers.AsParallel().AsOrdered()
                .Where(r => r % 2 == 0).AsSequential();

            foreach (var item in parallelResult)
            {
                Console.WriteLine(item);
            }

        }

        public void CatchAggregateExcepcion() {
            var numbers = Enumerable.Range(0, 20);
            try
            {
                var pq = numbers.AsParallel()
                    .Where(t => IsEven(t)).ToList();

                pq.ForEach(r => Console.WriteLine(r));

            }
            catch (AggregateException e)
            {

                Console.WriteLine("There where {0} exceptions", e.InnerExceptions.Count);
            }
        }

        private bool IsEven(int t)
        {
            if (t % 10 == 0) throw new ArgumentException("t");

            return t % 2 == 0;
        }
    }
}
