using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    public class StructClass
    {
        public struct Point {
            public int x, y;

            public Point(int p1, int p2) {
                x = p1;
                y = p2;
            }

            public int sum()
            {
                return x + y;
            }

        }


        void MyMethod(int firstArgument, string secondArgument = "default value", bool thirdArgument = false)
        {

        }


        void CallingMethod()
        {
            MyMethod(1, thirdArgument: true);
            MyMethod(1, secondArgument: "xxx");
            MyMethod(1, "vvv", true);

            Myclass myclass = new Myclass();
            myclass.MyInstanceField = "Some new Value";
            myclass.Concatenate(" :)");


        }

    }


    public class Myclass
    {
        public string MyInstanceField;

        public string Concatenate(string valueToappend)
        {
            return MyInstanceField + valueToappend;
        }
    }


    //index attribute
    public class card { }

    public class deck {


        public card this[int index]
        {
            get { return Cards[index]; }
            set { Cards[index] = value; }
        }

        private int _maximunNumberOfCards;

        public card[] Cards { get; set; }

        public deck(int maxNumberOfCards)
        {
            this._maximunNumberOfCards = maxNumberOfCards;
            Cards = new card[maxNumberOfCards];
        }
       
    }



}
