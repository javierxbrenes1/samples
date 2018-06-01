using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace Programing_in_Csharp
{ 
    class ReflectionClass
    {
        public void DumpObject(object obj)
        {
            FieldInfo[] fields = obj.GetType().GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof(int))
                {
                    Console.WriteLine(field.GetValue(obj));
                }
            }
        }

        public void ExecuteAMethod()
        {
            int i = 42;
            MethodInfo comparteToMethod = i.GetType().GetMethod("CompareTo", new Type[] { typeof(int) });
            int result = (int)comparteToMethod.Invoke(i, new object[] { 41 });
        }

    }
}
