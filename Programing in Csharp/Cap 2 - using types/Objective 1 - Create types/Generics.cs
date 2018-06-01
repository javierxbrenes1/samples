using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    public class Generics<T> where T: class, new()
    {

        public Generics()
        {
            MyProperty = new T();
        }

        T MyProperty { get; set; }

        public void MyGenericMethod<T>()
        {
            T defaultValue = default(T);
        }


    }


    
}
