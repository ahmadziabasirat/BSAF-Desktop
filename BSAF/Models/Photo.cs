using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace BSAF.Models
{
    public static class Photo
    {
        public static Bitmap photo { get; set; }
        public static byte[] ToByteArray(this Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                return ms.ToArray();
            }
        }
    }
}
