using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace NN.Standard.Image.Application
{
    public interface IImageService
    {
        void CompressImage(string soucePath, string destPath, int quality);
        Stream CompressImage(Bitmap image, int quality);
    }
}
