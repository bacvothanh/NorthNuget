using NN.Standard.Encrypt.Domain.Enums;

namespace NN.Standard.Encrypt.Application
{
    public interface IEncryptionService
    {
        string Hash(string input, HashType hashType);
    }
}
