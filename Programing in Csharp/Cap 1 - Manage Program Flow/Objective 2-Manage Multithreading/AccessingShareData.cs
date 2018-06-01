using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    class AccessingShareData
    {
        public void AccesingTheSameResource() {
            int n = 0;

            var up = Task.Run(() => {
                for (int i = 0; i < 1000000; i++)
                {
                    n++;
                }
            });

            for (int i = 0; i < 1000000; i++)
            {
                n--;
            }

            up.Wait();
            Console.WriteLine(n);


        }
    

        public void UsingLockOperator() {
            int n = 0;
            object _lock = new object();
            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                    lock (_lock)
                        n++;
            });
            for (int i = 0; i < 1000000; i++)
                lock (_lock)
                    n--;
            up.Wait();
            Console.WriteLine(n);
        }

        public void UsingLock()
        {
            int y = 0;
            object bloqueador = new object();

            var up = Task.Run(() => {
                for (int i = 0; i < 1000; i++)
                {
                    lock (bloqueador)
                    {
                        y++;
                    } 
                }
            });

            for (int i = 0; i < 1000; i++)
            {
                lock (bloqueador) {
                    y--;
                }
            }

            up.Wait();
            Console.WriteLine(y);
        }


        public void DeadLockExample() {
            object a = new object();
            object b = new object();

            var up = Task.Run(()=>{
                lock (a)
                {
                    Thread.Sleep(1000);
                    lock (b)
                    {
                        Console.WriteLine("Locked a and b");
                    }
                }
            });


            lock (b) {
                lock (a)
                {
                    Console.WriteLine("Loacked a and b");
                }
            }

            up.Wait();

        }

        public void UsingInterlockedClass()
        {
            int n = 0;

            var up = Task.Run(() => {
                for (int i = 0; i < 1000; i++)
                {
                    Interlocked.Increment(ref n);
                }
            });

            for (int i = 0; i < 1000; i++)
            {
                Interlocked.Decrement(ref n);
            }

            up.Wait();

            Console.WriteLine(n);
        }


        public void CompareAndExchange()
        {

            int valor = 1;

            Task t1 = Task.Run(() =>
            {
                if (valor == 1)
                {
                    Thread.Sleep(1000);
                    valor = 2;
                }
            });
           
            Task t2 = Task.Run(() =>
            {
                valor = 3;
            });


            Task.WaitAll(t1, t2);
            Console.WriteLine(valor);
        

        }

        public void compare2()
        {
            int value = 1;

            Task t1 = Task.Run(() =>
            {
                Interlocked.CompareExchange(ref value, 2, 1);
                


                
            });

            Task t2 = Task.Run(() =>
            {
                Interlocked.CompareExchange(ref value, 3, 2);
            });

            Task.WaitAll(t1, t2);

            Console.WriteLine(value);
        }

        
    }
}
