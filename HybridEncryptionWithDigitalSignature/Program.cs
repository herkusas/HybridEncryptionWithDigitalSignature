using System;
using System.Security.Cryptography;
using System.Text;

namespace HybridEncryptionWithDigitalSignature
{
    static class Program
    {
        static void Main()
        {
            const string original = "Petras";

            //Testavimas

            var hybrid = new HybridEncryption();

            var rsaParams = new RsaWithRsaParameterKey();
            rsaParams.AssignNewKey();

            var digitalSignature = new DigitalSignature();
            digitalSignature.AssignNewKey();

            Console.WriteLine("Hybrid Encryption");
            Console.WriteLine();

            try
            {
                var encryptedBlock = hybrid.EncryptData(Encoding.UTF8.GetBytes(original),
                    rsaParams, digitalSignature);

                var decrypted = hybrid.DecryptData(encryptedBlock, rsaParams, digitalSignature);

                Console.WriteLine("Original Message = " + original);
                Console.WriteLine();
                Console.WriteLine("Message After Decryption = " + Encoding.UTF8.GetString(decrypted));
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}
