using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    public class AsymmetricClass
    {
        string publicKey;
        string privatekey;

        public void ExportAsymmetricKeys()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            publicKey = rsa.ToXmlString(false);
            privatekey = rsa.ToXmlString(true);



        }


        public byte[] UsePublicKeyToEncryptData()
        {
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = byteConverter.GetBytes("my love for her is amazing");

            byte[] encryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(publicKey);
                encryptedData = RSA.Encrypt(dataToEncrypt, false);
            }


            Console.WriteLine(Convert.ToBase64String(encryptedData));

            return encryptedData;
        }

        public void UsePrivateLeyToDecryptedData()
        {
            UnicodeEncoding byteConververter = new UnicodeEncoding();

            byte[] DecryptedData;
            byte[] encrytedData = UsePublicKeyToEncryptData();

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privatekey);
                DecryptedData = rsa.Decrypt(encrytedData, false);
            }

            string decryptedString = byteConververter.GetString(DecryptedData);
            Console.WriteLine(decryptedString);
        }

        public void useKeycontainer(byte[] dataToEncrypt)
        {
            string containerName = "SecretContainer";
            CspParameters csp = new CspParameters() { KeyContainerName = containerName };
            byte[] encryptedData;

            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(csp))
            {
                encryptedData = RSA.Encrypt(dataToEncrypt, false);
            }
        }


    }


}
