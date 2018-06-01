using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    public class EventClass
    {
        public void CreateAndRaise()
        {
            Pub p = new Pub();
            p.OnChange += () => Console.WriteLine("Event raised to method 1");
            p.OnChange += () => Console.WriteLine("Event raised to method 2");
            p.Raise();




            pub2 t = new pub2();

            t.OnChange += () => { Console.WriteLine("54545"); };



            pubWithEventHandler m = new pubWithEventHandler();

            // it will execute
            m.onChange += (sender, e) => Console.WriteLine("Number: {0}", e.Value);
            //it will throw an exception
            m.onChange += (sender, e) => { throw new Exception(); };
            //it will be never called
            m.onChange += (sender, e) => Console.WriteLine("Number: {0}", e.Value);


            m.Raise();

        }
    }

    public class Pub
    {
        public Action OnChange { get; set; }


        public void Raise()
        {
            if (OnChange != null)
            {
                OnChange();
            }
        }
    }

    public class pub2
    {
        //when u initialize the event with an empty delegate 
        //there is not necesity to check whether is null or not
        public event Action OnChange = delegate{};

        public void Raise()
        {
            OnChange();
        }

    }


    public class MyArgs : EventArgs
    {
        public MyArgs(int value)
        {
            this.Value = value;
        }

        public int Value { get; set; }
    }

    public class pubWithEventHandler
    {
        private event EventHandler<MyArgs> OnChange = delegate { };
        public event EventHandler<MyArgs> onChange
        {
            add
            {
                lock (OnChange)
                {
                    OnChange += value;
                }
            }
            remove
            {
                lock (OnChange) {
                    OnChange -= value;
                }
            }
        }


        public void Raise()
        {
            OnChange(this, new MyArgs(42));
        }

    }


    public class pubHandlingErrors
    {
        public EventHandler OnChange = delegate { };

        public void Raise()
        {
            var exceptions = new List<Exception>();

            foreach (Delegate handler in OnChange.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }

    }
}
