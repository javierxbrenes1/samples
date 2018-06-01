

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Programing_in_Csharp
{
    public class CertificateClass
    {
        public void SignAndVerify() {
            string texttosign = "test paragraph";

            byte[] signature = sign(texttosign, "cn=WouterDeKort");

            Console.WriteLine(verify(texttosign, signature));

        }


        private byte[] sign(string text, string certSubjet)
        {
            X509Certificate2 cert = GetCertificate();
            var csp = (RSACryptoServiceProvider)cert.PrivateKey;
            byte[] hash = HashData(text);
            return csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));

        }

        private bool verify(string text, byte[] signature)
        {
            X509Certificate2 cert = GetCertificate();
            var csp = (RSACryptoServiceProvider)cert.PublicKey.Key;
            byte[] hash = HashData(text);

            return csp.VerifyData(hash, CryptoConfig.MapNameToOID("SHA1"), signature);

        }

        private byte[] HashData(string text)
        {
            HashAlgorithm hashAlgorithm = new SHA1Managed();
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] data = encoding.GetBytes(text);
            byte[] hash = hashAlgorithm.ComputeHash(data);

            return hash;
        }


        private X509Certificate2 GetCertificate()
        {
            X509Store my = new X509Store("testCertStore", StoreLocation.CurrentUser);

            my.Open(OpenFlags.ReadOnly);

            var certificate = my.Certificates[0];

            return certificate;
        }
    }
}
