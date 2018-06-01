using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    public class AbstractClass
    {

    }

    abstract class BaseAbstract {
        public virtual void MethodWithImplementation() { }

        public abstract void AbstractMethod();
    }

    class DerivedAbstract : BaseAbstract
    {

        

        public override void AbstractMethod()
        {
           
        }
    }
}
