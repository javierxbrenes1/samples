#define MySymbol
using System;
using System.Diagnostics;

namespace Programing_in_Csharp
{
    public class DirectivesCompilerClass
    {
        public void DebudDirective()
        {
            #if DEBUG
            Console.WriteLine("Debug mode");
            #else
            Console.WriteLine("Not debugin");
            #endif

        }

        public void useCustomSymbol()
        {
            #if MySymbol
            Console.WriteLine("Custom symbol is defined");
#else
            Console.WriteLine("picha mama");
#endif


            //warning
#warning This code is obsolete
#if DEBUG
//#error //Debug build is not allowed
#endif


            //dehabilitar warninga
#pragma warning disable
            while (false)
            {
                Console.WriteLine("Unreachable code");
            }
#pragma warning restore


            //line 
#pragma warning disable
#line 200 "OtherFileName"
            int a; // line 200
#line default
            int b; // line 4
#line hidden
            int c; // hidden
            int d; // line 7
#pragma warning restore

        }


        public void SomeMethod()
        {
#if DEBUG
            Log("Step1");
#endif
        }
        private static void Log(string message)
        {
            Console.WriteLine(message);
        }

        //metodo sera llamado sola cuando este en modo debug
        [Conditional("DEBUG")]
        private static void Log2(string message)
        {
            Console.WriteLine(message);
        }

        [DebuggerDisplay("Name = {FirstName} {LastName}")]
        public class PersonCompiler
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

}
}
