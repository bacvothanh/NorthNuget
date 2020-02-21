using System;
using System.Security.Cryptography;
using System.Text;
using NN.Standard.Encrypt.Domain.Enums;

namespace NN.Standard.Encrypt.Application
{
    public class EncryptionService
    {
        public string Hash(string input, HashType hashType)
        {
            switch (hashType)
            {
                case HashType.Sha256:
                    return Sha256(input);
                case HashType.Md5:
                    return Md5(input);
            }

            throw new NotSupportedException();
        }

        private string Sha256(string inputString)
        {
            var sb = new StringBuilder();
            foreach (byte b in GetSha256Hash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        private byte[] GetSha256Hash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        private string Md5(string source)
        {
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(source);
            var hash = md5.ComputeHash(inputBytes);
            var result = new StringBuilder();
            foreach (var b in hash)
                result.Append(b.ToString("X2"));
            return result.ToString();
        }
    }
}
