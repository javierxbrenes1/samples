using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    class AccessModifiersClass
    {
    }

    //using the private access modifier
    public class Accessibility
    {
        private string _myField;



        public string MyProperty
        {
            get { return _myField; }
            set { _myField = value; }
        }

    }


    //using protected access modifiers
    public class Base2 {
        private int _privateField;
        protected int _protectedField;


        private void PrivateMethod() { }
        protected void ProtectedMethod() { }

    }


    public class Derived2: Base2 {
        public void MyDerivedMethod() {

            _protectedField = 43;
        }
    }


}
