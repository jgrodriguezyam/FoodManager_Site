using System;
using System.Security.Cryptography;
using System.Text;
using FoodManager.Infrastructure.Constants;

namespace FoodManager.Infrastructure.Security
{
    public static class Cryptography
    {
        public static string Encrypt(string code)
        {
            var arrayToEncrypt = Encoding.UTF8.GetBytes(code);
            var tripleDesCryptoServiceProvider = TripleDesCrypt();
            var cTransform = tripleDesCryptoServiceProvider.CreateEncryptor();
            var arrayResultado = cTransform.TransformFinalBlock(arrayToEncrypt, 0, arrayToEncrypt.Length);
            tripleDesCryptoServiceProvider.Clear();
            return Convert.ToBase64String(arrayResultado, 0, arrayResultado.Length);
        }

        public static string Decrypt(string code)
        {
            var arrayToDecrypt = Convert.FromBase64String(code);
            var tripleDesCryptoServiceProvider = TripleDesCrypt();
            var cTransform = tripleDesCryptoServiceProvider.CreateDecryptor();
            var resultArray = cTransform.TransformFinalBlock(arrayToDecrypt, 0, arrayToDecrypt.Length);
            tripleDesCryptoServiceProvider.Clear();
            return Encoding.UTF8.GetString(resultArray);
        }

        private static TripleDESCryptoServiceProvider TripleDesCrypt()
        {
            var hashmd5 = new MD5CryptoServiceProvider();
            var keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(SystemConstants.Key));
            hashmd5.Clear();

            return new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
        }
    }
}