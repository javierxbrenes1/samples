using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    public class ConstructorChaining
    {
        private int _p;


        public ConstructorChaining() : this(3){}

        public ConstructorChaining(int p)
        {
            _p = p;
        }

    }
}
