using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    class AttributesClasses
    {
        public void SeeWhetherAnAttIsThere() {
            if (Attribute.IsDefined(typeof(Person), typeof(SerializableAttribute)) ) { }
        }

        public void gettingAnAttributeInstance() {
            ConditionalAttribute cAt = (ConditionalAttribute)Attribute.GetCustomAttribute(typeof(conditionalClass), typeof(ConditionalAttribute));

            var name = cAt.ConditionString;
        }

        [MyMethodAndParameter("javier")]
        public void UsingMyOwnAttribute() {

        }

    }

    [Serializable]
    class Person { }


    
    class conditionalClass {

        [Conditional("cond1")]
        public void Method() { }
    }

    //allowMultiple enables multiple intances of one attribute.
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class MyMethodAndParameterAttribute : Attribute {

        public MyMethodAndParameterAttribute(string description)
        {
            Description = description;
        }

        public string Description { get; set; }
    }

    
}
