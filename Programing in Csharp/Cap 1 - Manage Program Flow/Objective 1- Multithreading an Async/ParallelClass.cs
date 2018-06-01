using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    public class ParallelClass
    {
        public void UseForMethod() {
            Parallel.For(0, 10, i => {
                Thread.Sleep(1000);
                Console.WriteLine("Done process {0}", i);
            });
        }

        public void useNormalfor()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Done process {0}", i);
            }
        }

        public void useforEach() {
            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i => {
                Thread.Sleep(1000);
            });
        }

        public void useNormalforEach()
        {
            var numbers = Enumerable.Range(0, 10);
            foreach (var item in numbers)
            {
                Thread.Sleep(1000);
            }
                
            
        }


        public void StopALoopUsingBreak()
        {
            ParallelLoopResult result = Parallel.For(0, 1000,
                (int i, ParallelLoopState ls) => {
                    if (i == 500)
                    {
                        Console.WriteLine("Breaking loop");
                        ls.Break();
                    }
                    return;

                });

            Console.WriteLine("LowestbreakIteration {0}", result.LowestBreakIteration);
            Console.WriteLine("is it completed ? {0}",result.IsCompleted);


        }

        public void StopALoopUsingStop()
        {
            ParallelLoopResult result = Parallel.For(0, 1000,
                (int i, ParallelLoopState ls) => {
                    if (i == 500)
                    {
                        Console.WriteLine("Breaking loop");
                        ls.Stop();
                    }
                    return;

                });
            Console.WriteLine("LowestbreakIteration {0}", result.LowestBreakIteration);
            Console.WriteLine("is it completed ? {0}", result.IsCompleted);


        }
    }
}
