using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
   public class AESAlgorithm
    {

        public void EncryptsomeText()
        {
            string original = "My secret data!";

            using (SymmetricAlgorithm algo = new AesManaged()) {

                //define a password
                PasswordDeriveBytes pdb = new PasswordDeriveBytes("carolinaMora", null);
                algo.Key = pdb.GetBytes(algo.KeySize / 8);
                //encrypt
                byte[] encrypted = Encrypt(algo, original);
                //Decrypt
                string decrypted = Decrypt(algo, encrypted);

                Console.WriteLine("key {0}", Encoding.UTF8.GetString(algo.Key));
                Console.WriteLine("encrypt {0}", Encoding.UTF8.GetString(encrypted));

                Console.WriteLine("dencrypt {0}", decrypted);
            }
        }


        //
        private byte[] Encrypt(SymmetricAlgorithm aesalg, string text)
        {
            ICryptoTransform crypto = aesalg.CreateEncryptor(aesalg.Key, aesalg.IV);


            using (MemoryStream msSncrypt = new MemoryStream())
            {
                using (CryptoStream csenc = new CryptoStream(msSncrypt, crypto, CryptoStreamMode.Write)) {

                    using (StreamWriter swEncrypt = new StreamWriter(csenc))
                    {
                        swEncrypt.Write(text);
                    }

                    return msSncrypt.ToArray();

                }
            }
        }


        private string Decrypt(SymmetricAlgorithm aesalg, byte[] cipherText)
        {
            ICryptoTransform crypto = aesalg.CreateDecryptor(aesalg.Key, aesalg.IV);


            using (MemoryStream msdecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csdecrypt = new CryptoStream(msdecrypt, crypto, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csdecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }

        }

    }
}
