using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    class CancelingTask
    {
        public void CancelingTaskMethod(bool notificarCancelacion)
        {
            CancellationTokenSource cancellationSource = new CancellationTokenSource();

            CancellationToken cancellationToken = cancellationSource.Token;

            Task task = Task.Run(() =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(0);


                }
                if (notificarCancelacion)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                }


            }, cancellationToken);



            Console.WriteLine("Press enter to stop the task");
            Console.ReadLine();
            cancellationSource.Cancel();

            task.Wait();

        }


        public void AddContinuationTask()
        {
            CancellationTokenSource tokensource = new CancellationTokenSource();
            CancellationToken token = tokensource.Token;

            Task tt = Task.Run(() => {
                while (!token.IsCancellationRequested) {
                    Console.Write("*");
                }
            }, token).ContinueWith((t) => {
                t.Exception.Handle((e) => true);
                Console.WriteLine("task is finished");

            }, TaskContinuationOptions.OnlyOnCanceled);
        }


        public void SettingTimeOut() {

            Task longTime = Task.Run(() => {
                Thread.Sleep(1000);
            });

            int index = Task.WaitAny(new[] { longTime }, 1100);

            if (index == -1)
            {
                Console.WriteLine("Task timed out");
            }

        }

    }
}
