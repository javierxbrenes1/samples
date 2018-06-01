using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    public class LambdaClass
    {
        public delegate int Calculate(int x, int y);

        public void LambdaToCreateDelegate()
        {
            Calculate calc = (x, y) => x + y;

            Console.WriteLine(calc(1, 2));

            calc = (x, y) => x * y;

            Console.WriteLine(calc(4, 4));


        }

        public void LambdaWithMultipleStatements() {
            Calculate c = 
                (x, y) =>
                {
                    Console.WriteLine("Adding numbers");
                    return x + y;
                };

            int result = c(3, 4);
        }

        public void ActionDelegate()
        {
            Action<int, int> calc = (x, y) =>
            {
                Console.WriteLine(x + y);
            };

            calc(3, 4);
        }


    }
}
