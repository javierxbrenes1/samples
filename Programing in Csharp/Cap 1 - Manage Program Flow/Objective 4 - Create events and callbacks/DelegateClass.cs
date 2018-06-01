using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    class DelegateClass
    {
        public delegate int Calculate(int x, int y);

        public int Add(int a, int b) {
            return a + b;
        }

        public int Multiply(int d, int e) {
            return d * e;
        }

        public void workWithDelegates() {
            Calculate calc = Add;
            Console.WriteLine(calc(3, 4));

            calc = Multiply;
            Console.WriteLine(calc(2, 4));
        }


        public void MethodA()
        {
            Console.WriteLine("MethodOne");
        }

        public void MethodB()
        {
            Console.WriteLine("MethodTwo");
        }

        public delegate void del();

        public void Multicast()
        {
            del d = MethodA;
            d += MethodB;

            d();


        }


        //covariance
        //esto es posible porque streamwriter y stringwriter vienen de la misma clase padre.

        public delegate TextWriter CovarianceDel();

        public StreamWriter MethodStream() { return null; }
        public StringWriter MethodString() { return null; }

        public void UseCovariance()
        {
            CovarianceDel del;
            del = MethodStream;
            del = MethodString;

        }

        public void DoSomething(TextWriter tw) { }
        public delegate void ContravarianceDel(StreamWriter tx);

        public void useContravariance()
        {

            ContravarianceDel del2 = DoSomething;
        }

    }
}
