using System.Drawing;
using System.IO;

namespace NN.Standard.Image.Application
{
    public interface IImageService
    {
        void CompressImage(string soucePath, string destPath, int quality);
        Stream CompressImage(Bitmap image, int quality);
        Bitmap ResizeImage(Bitmap image, int width, int height);
    }
}
