using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using NN.Standard.Encrypt.Domain.Enums;

namespace NN.Standard.Encrypt.Application
{
    public class EncryptionService : IEncryptionService
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

        public string Encrypt(string input, string key, EncryptType encryptType)
        {
            switch (encryptType)
            {
                case EncryptType.Aes:
                    return AesEncrypt(input, key);
                case EncryptType.Des:
                    return DesEncrypt(input, key);
            }

            throw new NotSupportedException();
        }

        public string Decrypt(string input, string key, EncryptType encryptType)
        {
            switch (encryptType)
            {
                case EncryptType.Aes:
                    return AesDecrypt(input, key);
                case EncryptType.Des:
                    return DesDecrypt(input, key);
            }

            throw new NotSupportedException();
        }

        private string AesEncrypt(string input, string key)
        {
            var iv = new byte[16];
            byte[] array;
            using (var aes = Aes.Create())
            {
                if (aes == null)
                {
                    throw new Exception("Cannot init aes instance");
                }

                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                var encryption = aes.CreateEncryptor(aes.Key, aes.IV);
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryption, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(input);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        private string AesDecrypt(string input, string key)
        {
            var iv = new byte[16];
            var buffer = Convert.FromBase64String(input);
            using (var aes = Aes.Create())
            {
                if (aes == null)
                {
                    throw new Exception("Cannot init aes instance");
                }

                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                var decryption = aes.CreateDecryptor(aes.Key, aes.IV);
                using (var memoryStream = new MemoryStream(buffer))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decryption, CryptoStreamMode.Read))
                    {
                        using (var streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        private string DesEncrypt(string input, string key)
        {
            byte[] iv = { 10, 20, 30, 40, 50, 60, 70, 80 };
            var rgbKey = Encoding.UTF8.GetBytes(key);
            var desCryptoServiceProvider = new DESCryptoServiceProvider();
            var inputByteArray = Encoding.UTF8.GetBytes(input);
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, desCryptoServiceProvider.CreateEncryptor(rgbKey, iv), CryptoStreamMode.Write);
            cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
            cryptoStream.FlushFinalBlock();

            return Convert.ToBase64String(memoryStream.ToArray());
        }

        private string DesDecrypt(string input, string key)
        {
            byte[] iv = { 10, 20, 30, 40, 50, 60, 70, 80 };
            var rgbKey = Encoding.UTF8.GetBytes(key);
            var desCryptoServiceProvider = new DESCryptoServiceProvider();
            var inputByteArray = Convert.FromBase64String(input);
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, desCryptoServiceProvider.CreateDecryptor(rgbKey, iv), CryptoStreamMode.Write);
            cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
            cryptoStream.FlushFinalBlock();
            var encoding = Encoding.UTF8;

            return encoding.GetString(memoryStream.ToArray());
        }

        private string Sha256(string inputString)
        {
            var sb = new StringBuilder();
            foreach (var b in GetSha256Hash(inputString))
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
