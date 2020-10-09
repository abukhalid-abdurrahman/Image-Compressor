using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageCompressor
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePth = @"https://s3-images-mygaleon-ru.storage.cloud.croc.ru/369043cb-b401-4091-8fc1-fa5ce631f77a.jpg";
            string newImage = @"E:\Faridun's Projects\Faridun's\Back-End\Console\ImageCompressor\ImageCompressor\Downloaded_compressed.jpg";

            Stream imageFromServer = StreamFromResponseContext.StreamFromResponse(sourcePth).GetAwaiter().GetResult();
            Bitmap srcBmp = new Bitmap(imageFromServer);
            Bitmap newBmp = new Bitmap(ImageCompressorContext.CompressImage(srcBmp, 20));

            newBmp.Save(newImage, ImageFormat.Jpeg);
        }
    }
}
