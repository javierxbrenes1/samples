using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    class ExplicitInterfaceClass
    {
        public void AccessToAnExplicitInterfaceMethod() {

            Implementation im = new Implementation();

            ((IInterfaceA)im).MyMethod();
        }
    }

    interface IInterfaceA
    {
        void MyMethod();
    }


    class Implementation : IInterfaceA
    {

        void IInterfaceA.MyMethod() {

        }
    }



    interface ILeft
    {
        void Move();
    }

    interface IRight
    {
        void Move();
    }

    class MoveableObject : ILeft, IRight {

        void ILeft.Move(){}

        void IRight.Move() { }
    }
}
