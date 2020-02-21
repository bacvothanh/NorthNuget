using System.Drawing;
using System.Drawing.Drawing2D;
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
                var qualityEncoder = Encoder.Quality;
                var encoderParameters = new EncoderParameters(1);
                var encoderParameter = new EncoderParameter(qualityEncoder, quality);

                encoderParameters.Param[0] = encoderParameter;
                sourceFile.Save(destPath, encoder, encoderParameters);
            }
        }

        public Stream CompressImage(Bitmap image, int quality)
        {
            var encoder = GetEncoder(ImageFormat.Jpeg);
            var qualityEncoder = Encoder.Quality;
            var encoderParameters = new EncoderParameters(1);
            var encoderParameter = new EncoderParameter(qualityEncoder, quality);
            encoderParameters.Param[0] = encoderParameter;
            var memory = new MemoryStream();
            image.Save(memory, encoder, encoderParameters);

            return memory;
        }

        public Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            var desRectangle = new Rectangle(0, 0, width, height);
            var resizedImage = new Bitmap(width, height);
            resizedImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (var graphics = Graphics.FromImage(resizedImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, desRectangle, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return resizedImage;
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            var codecs = ImageCodecInfo.GetImageDecoders();
            return codecs?.FirstOrDefault(x => x.FormatID == format.Guid);
        }
    }
}
