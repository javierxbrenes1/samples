using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    class tracingAndDebuging
    {
        //this class is just used by debug mode
        public void useDebugClass()
        {
            Debug.WriteLine("Starting application");
            Debug.Indent();
            int i = 1 + 2;
            Debug.Assert(i == 3);
            Debug.WriteLineIf(i > 0, "i is greater than 0");
        }

        public void useTraceSource()
        {
            TraceSource traceSource = new TraceSource("myTraceSource",SourceLevels.All);
            traceSource.TraceInformation("Tracing application..");
            traceSource.TraceEvent(TraceEventType.Critical, 0, "Critical trace");
            traceSource.TraceData(TraceEventType.Information, 1,
            new object[] { "a", "b", "c" });
            traceSource.Flush();
            traceSource.Close();
            // Outputs:
            // myTraceSource Information: 0 : Tracing application..
            // myTraceSource Critical: 0 : Critical trace
            // myTraceSource Information: 1 : a, b, c
        }


        public void Counters()
        {
            if (CreatePerformanceCounters())
            {
                Console.WriteLine("Created performance counters");
                Console.WriteLine("Please restart application");
                Console.ReadKey();
                return;
            }
            var totalOperationsCounter = new PerformanceCounter("MyCategory",
            "# operations executed","",false);
            var operationsPerSecondCounter = new PerformanceCounter("MyCategory",
            "# operations / sec","",
            false);
            totalOperationsCounter.Increment();
            operationsPerSecondCounter.Increment();
        }



        private static bool CreatePerformanceCounters()
        {
            if (!PerformanceCounterCategory.Exists("MyCategory"))
            {
                CounterCreationDataCollection counters =
                new CounterCreationDataCollection
                {
                    new CounterCreationData(
                    "# operations executed",
                    "Total number of operations executed",
                    PerformanceCounterType.NumberOfItems32),
                    new CounterCreationData(
                    "# operations / sec",
                    "Number of operations executed per second",
                    PerformanceCounterType.RateOfCountsPerSecond32)
                                    };
                                    PerformanceCounterCategory.Create("MyCategory",
                                    "Sample category for Codeproject", counters);
                                    return true;
                                }
                                return false;
        }

    }
}


