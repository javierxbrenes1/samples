using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    class ExceptionClass
    {
        public void Method()
        {
            string s = Console.ReadLine();
            try
            {
                int i = int.Parse(s);
                if (i == 42) Environment.FailFast("Special number entered");
            }
            finally{
                Console.WriteLine("Program complete");

            }
        }

        public void usingValuesFromException() {
            try
            {
                int i = ReadAndParse();
                Console.WriteLine("Parsed: {0}", i);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Message: {0}", ex.Message); //a human friendly message
                Console.WriteLine("stackTrace: {0}", ex.StackTrace); //describes all the methods that are currently in execution
                Console.WriteLine("HelpLink: {0}", ex.HelpLink); //Url that points to a help file.
                Console.WriteLine("HResult: {0}", ex.HResult); //a 32-bit value that describes the severity of an error.
                Console.WriteLine("Source: {0}", ex.Source); //the name of the app that caused the exception
                Console.WriteLine("Targetsite: {0}", ex.TargetSite.Name); //contains the name of the method that caused the exception
                Console.WriteLine("Data: {0}", ex.Data); //A dictionary pairs that you can use to store extra data for your exception
            
            }
        }

        private int ReadAndParse()
        {
            string s = Console.ReadLine();
            int i = int.Parse(s);
            return i;
        }

        public void RaiseAException()
        {
            try
            {

                int t = 1;
                int m = 0;

                int w = t / m;
            }
            catch (Exception ex)
            {

                throw new DivideByZeroException("there was a problem", ex);
            }

        }


        public void UsingDispatcher()
        {
            ExceptionDispatchInfo possibleException = null;
            try
            {

                string s = "NaN";
                int.Parse(s);

            }
            catch (FormatException ex) {

                possibleException = ExceptionDispatchInfo.Capture(ex);
            }

            if (possibleException != null)
                possibleException.Throw();

        }
    }
}
