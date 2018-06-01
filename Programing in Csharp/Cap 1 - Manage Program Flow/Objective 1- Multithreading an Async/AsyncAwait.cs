using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    class AsyncAwait
    {

        public async Task<string> simpleExample()
        {
            using (HttpClient client = new HttpClient()) {
                string result = await client.GetStringAsync("http://www.microsoft.com");
                return result;
            }
        }

        // scalability versus responsiveness
        public Task SleepAsyncA(int milliseconds)
        {
            return Task.Run(() => {
                Thread.Sleep(milliseconds);
            });
        }

        public Task SleepAsyncB(int million)
        {
            TaskCompletionSource<bool> tcs = null;
            var t = new Timer(delegate { tcs.TrySetResult(true); }, null, -1, -1);
            tcs = new TaskCompletionSource<bool>(t);
            t.Change(million, -1);
            return tcs.Task;
        }

    }
}
