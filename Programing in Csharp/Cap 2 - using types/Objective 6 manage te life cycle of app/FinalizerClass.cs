using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    class FinalizerClass
    {

        public void ForceAGarbageCollection() {
            StreamWriter stream = File.CreateText("temp.data");
            stream.Write("some data");
            GC.Collect();
            //wait for all the finalizer 
            GC.WaitForPendingFinalizers();
            File.Delete("temp.data");
        }

        public void CallDispose()
        {
            StreamWriter stream = File.CreateText("temp.data");
            stream.Write("some");
            stream.Dispose();
            File.Delete("temp.data");

        }

        public void useDispose()
        {
            using (StreamWriter sw = File.CreateText("xxx"))
            {

            }
        }


        //using weak reference
        WeakReference data;

        public void Run()
        {
            object result = GetData();
            //GC.Collect();
            result = GetData();
        }

        public object GetData()
        {
            if (data == null)
            {
                data = new WeakReference(LoadLargeList());
            }

            if (data.Target == null)
            {
                data.Target = LoadLargeList();
            }

            return data.Target;

        }

        public object LoadLargeList()
        {
            return new List<string>();
        }
    }

    public class SomeType {
        //finalizer
        ~SomeType() {

        }
    }

    //Implementing by own.
    public class UnmangedWrapper : IDisposable
    {


        public FileStream Stream { get; private set; }


        public UnmangedWrapper()
        {
            this.Stream = File.Open("temp.dat", FileMode.Create);
        }

        ~UnmangedWrapper()
        {
            Dispose(false);
        }

        public void Close() {
            Dispose();
        }



        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Stream != null)
                {
                    Stream.Close();
                }
            }
        }
    }



}
