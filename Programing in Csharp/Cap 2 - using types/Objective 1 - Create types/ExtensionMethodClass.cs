using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    public class ExtensionMethodClass
    {
        public void Invoque()
        {
            //uso 
            Calculator c = new Calculator();
            Product p = new Product();
            p.Price = 12;

            c.CalculateDiscount(p);

        }

    }

    public class Product
    {
        public decimal Price { get; set; }
    }


    public static class MyExtensions
    {
        public static decimal Discount(this Product product)
        {
            return product.Price * .9M;
        }

    }

    public class Calculator
    {
        public decimal CalculateDiscount(Product p)
        {
            return p.Discount();
        }
    }


    class  Base
    {
        public virtual int MyMethod()
        {
            return 42;
        }
    }


    class derived : Base
    {
        public override int MyMethod() {
            return base.MyMethod() * 2;
        }
    }

}
