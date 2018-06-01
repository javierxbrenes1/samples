using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    class SecureStringClass
    {
        public void SecureStringMethod()
        {
            using (SecureString ss = new SecureString())
            {
                Console.Write("Please enter password");
                while (true)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Enter)
                    {
                        break;
                    }

                    ss.AppendChar(cki.KeyChar);
                    Console.WriteLine("*");
                }
                ss.MakeReadOnly();
            }

        }

        public static void ConvertToUnsecureString(SecureString securePass)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePass);
                Console.WriteLine(Marshal.PtrToStringUni(unmanagedString));
            }
            catch (Exception)
            {

                throw;
            }
            finally {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
