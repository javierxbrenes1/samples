using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    public class enumclass
    {
        enum days : byte
        {
            Sat = 1, 
            sun, 
            Mon, 
            tue, 
            Wed, 
            Thu,
            Fri
        }

        [Flags]
        enum Days {
            //none = 0x0,
            //sun = 0x1,
            //mon = 0x2,
            //tue = 0x3,
            //wed = 0x4,
            //thu = 0x10,
            //fri = 0x20,
            //sat = 0x40
            none = 1,
            sun = 2,
            mon = 3,
            tue = 4,
            wed = 5,
            thu = 6,
            fri = 7,
            sat = 40

        }

        public void usingFlagAttribute() {
            Days readingDays = Days.mon | Days.sat;

            

            Console.WriteLine(readingDays.HasFlag(Days.mon));

        }
    }
}
