using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    class InterfaceClass
    {

        //Intanciate an object
        public void Method()
        {
            IAnimal animal = new dog();

            moveAnimal(animal);

            ((dog)animal).Bark();

        }

        void moveAnimal(IAnimal animal)
        {
            animal.Move();
        }
    
    }


    interface IExample
    {
        string GetResult();
        int Value { get; set; }
        event EventHandler ResultRetrieved;
        int this[string index] { get;set; }
    }

    class ExampleImplementation : IExample
    {
        public int this[string index] { get { return 42; } set { } }

        public int Value { get; set; }

        public event EventHandler ResultRetrieved;

        public string GetResult()
        {
            return "result";
        }
    }

    //interface con un tipo generico
    interface IRepository<T> {
        T FindById(int id);
        IEnumerable<T> All();
    }

    class Books { }

    class BooksRepository : IRepository<Books>
    {
        public IEnumerable<Books> All()
        {
            throw new NotImplementedException();
        }

        public Books FindById(int id)
        {
            throw new NotImplementedException();
        }
    }



    interface IAnimal {
        void Move();
    }

    class dog : IAnimal
    {
        public void Move() { }

        public void Bark() { }
    }
}
