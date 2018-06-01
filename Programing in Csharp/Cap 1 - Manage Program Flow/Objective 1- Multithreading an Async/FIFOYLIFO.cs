using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp.Multithreading
{
    class FIFOYLIFO
    {

        public void UsingaStack() {
            ConcurrentStack<int> stack = new ConcurrentStack<int>();

            stack.Push(42);

            int result;

            if (stack.TryPop(out result))
            {
                Console.WriteLine("Popped: {0}: ", result);

            }

            stack.PushRange(new[] { 1, 2, 3 });
            int[] values = new int[2];

            stack.TryPopRange(values);

            foreach (int i in values)
            {
                Console.WriteLine(i);
            }
        }

        public void UsingQueue()
        {
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            queue.Enqueue(42);

            int result;
            if (queue.TryDequeue(out result))
                Console.WriteLine("Dequeued: {0}", result);

        }

    }
}
