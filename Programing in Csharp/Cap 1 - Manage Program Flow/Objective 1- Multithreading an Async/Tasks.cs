using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    class Tasks
    {
        public void SimpleTask() {
            Task t = Task.Run(() => {
                for (int x = 0; x < 100; x++)
                {
                    Console.Write('*');
                }
            });

            t.Wait();
        }

        public int TaskReturnsAValue()
        {
            Task<int> t = Task.Run(() => {
                return 42;
            });

            return t.Result;
        }

        public void AddAContinuationMethod() {
            Task<int> t = Task.Run(() => {
                return 42;
            }).ContinueWith((i) => {
                return i.Result * 2;
            });

            
            Console.WriteLine(t.Result);
        }

        public void AddOverLoadingContinousMethod()
        {
            int val = 0;
            Task<int> t = Task.Run(() => { return 42/ val; });

            t.ContinueWith((i) => {
                Console.WriteLine("Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);

            var faulted = t.ContinueWith((i) => {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);

            var completedTask = t.ContinueWith((i) => {
                Console.WriteLine("Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            faulted.Wait();
        }

        public void CreateAParentWithChildren() {
            Task<Int32[]> parent = Task.Run(() => {
                var result = new Int32[3];

                new Task(() => result[0] = 0, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => result[1] = 1, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => result[2] = 2, TaskCreationOptions.AttachedToParent).Start();

                
                return result;
            });

            var finalTask = parent.ContinueWith((i) => {
                foreach (int re in i.Result)
                {
                    Console.Write(re);
                }
            });

            finalTask.Wait();
        }

        public void UsetaskFactory()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var result = new Int32[3];

                TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);

                tf.StartNew(() => result[0] = 0);
                tf.StartNew(() => result[1] = 1);
                tf.StartNew(() => result[2] = 2);

                return result;
            });

            var finalTask = parent.ContinueWith((i) => {
                foreach (int re in i.Result)
                {
                    Console.Write(re);
                }
            });

            finalTask.Wait();

        }

        public void UseWailtAll()
        {
            Task[] tasks = new Task[3];

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine(1);
                return 1;
            });

            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine(2);
                return 2;
            });

            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine(3);
                return 3;
            });

            Task.WaitAll(tasks);
        }

        public void UseWaitAny()
        {
            Task<int>[] tasks = new Task<int>[3];
            tasks[0] = Task.Run(() => { Thread.Sleep(2000); return 1; });
            tasks[1] = Task.Run(() => { Thread.Sleep(1000); return 2; });
            tasks[2] = Task.Run(() => { Thread.Sleep(3000); return 3; });

            while (tasks.Length > 0)
            {
                int i = Task.WaitAny(tasks);
                Task<int> completed = tasks[i];
                Console.WriteLine(completed.Result);

                var temp = tasks.ToList();
                temp.Remove(completed);
                tasks = temp.ToArray();
            }

        }
    }
}
