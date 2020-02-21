using NN.Standard.Encrypt.Domain.Enums;

namespace NN.Standard.Encrypt.Application
{
    public interface IEncryptionService
    {
        string Hash(string input, HashType hashType);
        string Encrypt(string input, string key, EncryptType encryptType);
        string Decrypt(string input, string key, EncryptType encryptType);
    }
}
