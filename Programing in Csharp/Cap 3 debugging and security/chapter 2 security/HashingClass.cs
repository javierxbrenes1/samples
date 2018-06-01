using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    class HashingClass
    {
        public void SHA256Managed()
        {
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            SHA256 sha256 = SHA256.Create();

           
            string data = "A paragraph of text";
            byte[] hasA = sha256.ComputeHash(byteConverter.GetBytes(data));

            //another
            data = "a páragraph of changed text";
            byte[] hasB = sha256.ComputeHash(byteConverter.GetBytes(data));

            //the same A
            data = "A paragraph of text";
            byte[] hasC = sha256.ComputeHash(byteConverter.GetBytes(data));

            //comparte them each other
            Console.WriteLine(hasA.SequenceEqual(hasB));
            Console.WriteLine(hasA.SequenceEqual(hasC));


        }
    }


    class Set<T> {

        private List<T>[] buckets = new List<T>[100];

        public void Insert(T item)
        {
            int bucket = GetBucket(item.GetHashCode());
            if (Contains(item, bucket))
            {
                return;
            }
            if (buckets[bucket] == null)
            {
                buckets[bucket] = new List<T>();

            }
            buckets[bucket].Add(item);
        }


        private int GetBucket(int hascode)
        {
            unchecked
            {
                return (int)((uint)hascode % (uint)buckets.Length);
            }
        }

        public bool Contains(T item)
        {
            return Contains(item, GetBucket(item.GetHashCode()));
        }

        public bool Contains(T item, int nbucket)
        {
            if (buckets[nbucket] != null)
            {
                foreach (T member in buckets[nbucket])
                {
                    if (member.Equals(item)) {
                        return true;
                    }
                }
                
            }
            return false;
        }

    }

}
