using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    class BaseClasses
    {
    }

    interface IEntity {
        int id { get; }
    }

    class Repository<T> where T : IEntity
    {
        protected IEnumerable<T> _elements;

        public Repository(IEnumerable<T> elements)
        {
            _elements = elements;
        }

        public T FindById(int id)
        {
            return _elements.SingleOrDefault(e => e.id == id);
        }
    }

    class Order : IEntity
    {
        public int id { get; }
    }

    class OrderRepository : Repository<Order> {
        public OrderRepository(IEnumerable<Order> orders) : base(orders)
        {

        }

        public IEnumerable<Order> FilterOrderOnAmount(decimal amount)
        {
            List<Order> result = null;

            return result;
        }


    }


    //overriding
    class bass3 {
        protected virtual void Execute() {

        }
    }


    class Derived3 : bass3
    {
        protected override void Execute()
        {
            log("before executing");
            base.Execute();
            log("after executing");
        }

        private void log(string message) { }
    }

    //hiding a method using new
    public class Base4 {
        public void Execute() { Console.WriteLine("Base.Execute"); }
    }

    public class Derived4 : Base4
    {
        public new void Execute() { Console.WriteLine("Derived.Execute"); }
    }

}
