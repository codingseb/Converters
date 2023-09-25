using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace CodingSeb.Converters
{
    internal static class InternalExtensions
    {
        public static string EscapeForXaml(this string text)
        {
            return text?.Replace("[apos]", "'")
                .Replace("[quot]", "\"")
                .Replace("[lt]", "<")
                .Replace("[gt]", ">")
                .Replace("[amp]", "&")
                .Replace("[br]", "\r\n");
        }

        public static bool IsEqual(this BitmapImage image1, BitmapImage image2)
        {
            if (image1 == null || image2 == null)
            {
                return false;
            }
            return image1.ToBytes().SequenceEqual(image2.ToBytes());
        }

        public static byte[] ToBytes(this BitmapImage image)
        {
            byte[] data = new byte[] { };
            if (image != null)
            {
                try
                {
                    var encoder = new BmpBitmapEncoder();

                    encoder.Frames.Add(BitmapFrame.Create(image));
                    using (MemoryStream ms = new MemoryStream())
                    {
                        encoder.Save(ms);
                        data = ms.ToArray();
                    }
                    return data;
                }
                catch
                { }
            }
            return data;
        }

        public static object GetFieldValue(this object obj, string fieldName, Type forceType = null)
        {
            return (forceType ?? obj?.GetType())?
                .GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?
                .GetValue(obj);
        }

        public static object GetPropertyValue(this object obj, string propertyName, Type forceType = null)
        {
            return (forceType ?? obj?.GetType())?
                .GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?
                .GetValue(obj);
        }
    }
}
