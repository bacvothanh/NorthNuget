using System.Drawing;
using System.IO;

namespace NN.Standard.Image.Application
{
    public interface IImageService
    {
        void CompressImage(string soucePath, string destPath, int quality);
        System.Drawing.Image CompressImage(System.Drawing.Image image, int quality);
        System.Drawing.Image ResizeImage(System.Drawing.Image image, int width, int height);
    }
}
