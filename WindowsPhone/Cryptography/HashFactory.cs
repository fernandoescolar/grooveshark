using System;
using System.Security.Cryptography;
using System.Text;

namespace GrooveSharp.Cryptography
{
    internal class HashFactory : IHashFactory
    {
        public string Md5(string originalPassword)
        {
            return ComputeHash(originalPassword, new Md5Managed());
        }

        public string Sha1(string originalPassword)
        {
            return ComputeHash(originalPassword, new SHA1Managed());
        }

        private static string ComputeHash(string originalPassword, HashAlgorithm algorithm)
        {
            var originalBytes = Encoding.UTF8.GetBytes(originalPassword);
            var encodedBytes = algorithm.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes).Replace("-", string.Empty).ToLower();
        }
    }
}