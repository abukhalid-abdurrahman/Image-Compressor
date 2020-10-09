using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageCompressor
{
    class ImageCompressorContext
    {
        /// <summary>
        /// Сжимает исходное изображение заданное в sourceBitmap, и возвращает результат сжатия (сжатое изображение)
        /// </summary>
        /// <param name="sourceBitmap">Исходное изображение</param>
        /// <param name="quality">Степень сжатия</param>
        /// <returns>Сжатое изображение</returns>
        public static Image CompressImage(Bitmap sourceBitmap, int quality)
        {
            using (var compressedImage = new Bitmap(sourceBitmap))
            using (var memoryStream = new MemoryStream())
            {
                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                Encoder QualityEncoder = Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(QualityEncoder, quality);
                myEncoderParameters.Param[0] = myEncoderParameter;

                compressedImage.Save(memoryStream, jpgEncoder, myEncoderParameters);
                return Image.FromStream(memoryStream);
            }
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}
