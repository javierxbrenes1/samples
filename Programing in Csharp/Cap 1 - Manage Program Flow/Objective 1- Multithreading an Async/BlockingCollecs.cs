using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    public class BlockingCollecs
    {
        public void usingBlokicnCollections() {

            BlockingCollection<string> col = new BlockingCollection<string>();

            Task read = Task.Run(() => {
                while (true)
                {
                    Console.WriteLine(col.Take());
                }
            });


            Task write = Task.Run(() => {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    col.Add(s);
                }
            });

            write.Wait();

        }

        public void notUsingWhileTrue()
        {
            BlockingCollection<string> col = new BlockingCollection<string>();

            Task read = Task.Run(() => {
                foreach (string value in col.GetConsumingEnumerable())
                {
                    Console.WriteLine(value);
                }
            });


            Task write = Task.Run(() => {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    col.Add(s);
                }
            });

            write.Wait();
        }
    }
}
