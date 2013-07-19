using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;

namespace GrooveSharp.Cryptography
{
    internal class HashFactory : IHashFactory
    {
        public string Md5(string originalPassword)
        {
            return this.ComputeHash("MD5", originalPassword);
        }

        public string Sha1(string originalPassword)
        {
            return this.ComputeHash("SHA1", originalPassword);
        }

        private string ComputeHash(string algorithm, string originalPassword)
        {
            var alg = HashAlgorithmProvider.OpenAlgorithm(algorithm);
            var buff = CryptographicBuffer.ConvertStringToBinary(originalPassword, BinaryStringEncoding.Utf8);
            var hashed = alg.HashData(buff);
            var res = CryptographicBuffer.EncodeToHexString(hashed);
            return res;
        }
    }
}
