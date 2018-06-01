using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    public class ConcurrentDictionaryClass
    {
        public void UsingConcurringDictionary()
        {
            var dic = new ConcurrentDictionary<string, int>();

            if (dic.TryAdd("k1", 42))
            {
                Console.WriteLine("Added");
            }

            if(dic.TryUpdate("k1", 21, 42))
            {
                Console.WriteLine("42 updated to 21");
            }

            dic["k1"] = 42; //overwrite unconditionally osea sin validar nada

            int r1 = dic.AddOrUpdate("k1", 3, (s, i) => i * 2);
            int r2 = dic.GetOrAdd("k2", 3);

            Console.WriteLine(r1);
            Console.WriteLine(r2);
        }
    }
}
