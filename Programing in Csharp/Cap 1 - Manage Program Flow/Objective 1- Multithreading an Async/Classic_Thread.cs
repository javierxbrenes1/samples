using System;
using System.Threading;

namespace Programing_in_Csharp
{
    class Classic_Thread
    {
        [ThreadStatic]
        static int _field;

        

        public void ThreadMethod(int SleepTime) {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc:{0}", i);
                Thread.Sleep(SleepTime);
            }
        }

        public void ThreadMethod2(object SleepTime)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc:{0}", i);
                Thread.Sleep((int)SleepTime);
            }
        }

        public void MainClass_ThreadMethod()
        {
            Thread t = new Thread(() => ThreadMethod(0));
            t.Start();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: do some work");
                Thread.Sleep(0);
            }

            t.Join();
        }

        public void Main_ForeGroundBackground()
        {
            var t = new Thread(() => ThreadMethod(100));
            t.IsBackground = false;
            t.Start();
        }

        public void Thread_overloadconstuctor() {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod2));
            t.Start(100);
        }

        public void StoppingAthread() {
            bool Stopped = false;
            Thread t = new Thread(new ThreadStart(() => {
                while (!Stopped) {
                    Console.WriteLine("Running...");
                    Thread.Sleep(1000);
                }
            }));
            t.Start();
            Console.Write("Press ant key to exit");
            Console.ReadKey();

            Stopped = true;
            t.Join();

        }

        public void usingthreadStaticAttribute() {
            

             new Thread(() => {
                for (int x = 0; x < 10; x++)
                {
                    _field++;
                    Console.WriteLine("Thread A: {0}", _field);
                }
            }).Start();

            new Thread(() => {
                for (int x = 0; x < 10; x++)
                {
                    _field++;
                    Console.WriteLine("Thread B: {0}", _field);
                }
            }).Start();

        }

        public void ThreadLocalClass() {
            ThreadLocal<int> _field = new ThreadLocal<int>(()=> {
                return Thread.CurrentThread.ManagedThreadId;
            } );


            new Thread(() => {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("Thread A: {0}", x);
                }
            }).Start();

            new Thread(() => {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("Thread B: {0}", x);
                }
            }).Start();

        }
    }
}
