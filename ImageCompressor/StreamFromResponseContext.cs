using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ImageCompressor
{
    class StreamFromResponseContext
    {
        /// <summary>
        /// Возвращает ответ от сервера в виде потока(Stream)
        /// </summary>
        /// <param name="url">Ссылка на объект</param>
        /// <returns>Данные полученные в ответ от url в виде потока(Stream)</returns>
        public static async Task<Stream> StreamFromResponse(string url)
        {
            try
            {
                var webRequest = WebRequest.Create(url);
                var webResponse = await webRequest.GetResponseAsync();
                return webResponse.GetResponseStream();
            }
            catch
            {
                return null;
            }
        }
    }
}
