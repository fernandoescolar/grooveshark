using System;
using System.Security.Cryptography;
using System.Text;

namespace GrooveSharp.Cryptography
{
    internal class HashFactory : IHashFactory
    {
        public string Md5(string originalPassword)
        {
            return ComputeHash(originalPassword, new MD5CryptoServiceProvider());
        }

        public string Sha1(string originalPassword)
        {
            return ComputeHash(originalPassword, SHA1.Create());
        }

        private static string ComputeHash(string originalPassword, HashAlgorithm algorithm)
        {
            var originalBytes = Encoding.ASCII.GetBytes(originalPassword);
            var encodedBytes = algorithm.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes).Replace("-", string.Empty).ToLower();
        }
    }
}
