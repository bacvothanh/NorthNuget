using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace NN.Standard.Image.Application
{
    public class ImageService : IImageService
    {
        public void CompressImage(string soucePath, string destPath, int quality)
        {
            var fileName = Path.GetFileName(soucePath);
            destPath = Path.Combine(destPath, fileName);

            using (var sourceFile = new Bitmap(soucePath))
            {
                var encoder = Path.GetExtension(soucePath)?.ToUpper() == ".PNG"? GetEncoder(ImageFormat.Png): GetEncoder(ImageFormat.Jpeg);
                var qualityEncoder = System.Drawing.Imaging.Encoder.Quality;
                var encoderParameters = new EncoderParameters(1);
                var encoderParameter = new EncoderParameter(qualityEncoder, quality);

                encoderParameters.Param[0] = encoderParameter;
                sourceFile.Save(destPath, encoder, encoderParameters);
            }
        }

        public Stream CompressImage(Bitmap image, int quality)
        {
            var encoder = GetEncoder(ImageFormat.Jpeg);
            var qualityEncoder = System.Drawing.Imaging.Encoder.Quality;
            var encoderParameters = new EncoderParameters(1);
            var encoderParameter = new EncoderParameter(qualityEncoder, quality);
            encoderParameters.Param[0] = encoderParameter;
            var memory = new MemoryStream();
            image.Save(memory, encoder, encoderParameters);

            return memory;
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            var codecs = ImageCodecInfo.GetImageDecoders();
            return codecs?.FirstOrDefault(x => x.FormatID == format.Guid);
        }
    }
}
