using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    class ConvertingClass
    {
        public void implicitConversion() {
            //int to double
            int i = 0;
            double d = i;

            //an object to a base type (Object) or Interface
            HttpClient client = new HttpClient();
            object o = client;
            IDisposable Id = client;
        }

        public void explicitConversion()
        {
            double x = 1234.7;
            //cast double to int
            int a = (int)x;

            //cast base type to a reference type.
            Object stream = new MemoryStream();
            MemoryStream memoryStream = (MemoryStream)stream;
        }



        public void UserDefinedConversion()
        {
            Money money = new Money(42.2M);

            decimal amount = money;

            int TruncatedAmount = (int)money;
        }

        public void UsingconvertAndTryParsing()
        {
            int value = Convert.ToInt32("42");
            value = int.Parse("42");

            bool success = int.TryParse("42", out value);

        }


        public void OpenConnection(DbConnection connection)
        {
            if (connection is SqlConnection)
            {
                //do something
            }
        }

        public void LogStream(Stream stream)
        {
            MemoryStream memory = stream as MemoryStream;
            if (memory != null)
            {
                // do something
            }
        }


        public void useDynamicsWithExcel(IEnumerable<dynamic> entities)
        {
            //var excelApp = new Excel.Application();
            //excelApp.Visible = true;


            //excelApp.WorkBook.add();

            //dynamic workSheet = excelApp.ActiveSheet;

            //workSheet.Cells[1, "A"] = "header a";


        }

        public void UseDynamicObject() {
            dynamic obj = new SimpleObject();
            Console.Write(obj.SomeProperty);
        }

    }


    public class SimpleObject : DynamicObject
    {
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = binder.Name;
            return true;
        }
    }

    public class Money {
        public Money(decimal amount)
        {
            Amount = amount;
        }

        //allows implicit conversion
        public static implicit operator decimal(Money money)
        {
            return money.Amount;
        }

        //allow explicit conversion 
        public static explicit operator int(Money money)
        {
            return (int)money.Amount;
        }



        public decimal Amount { get; set; }
    }
}
