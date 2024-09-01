/*
 * copyright reserved
 * https://www.github.com/bian-sh
 * MIT license
 */


using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static Steganography.DataProcessHandler;
namespace Steganography
{
    /// <summary>
    /// 提供使用最低有效位（LSB）隐写术技术编码和解码数据的方法。
    /// </summary>
    public static class LSB
    {
        const int HEADER_SIZE = 135;
        /// <summary>
        /// 从位图图像中读取从指定偏移量开始的数据。
        /// </summary>
        /// <param name="bitmap">要读取的位图图像。</param>
        /// <param name="offset">以像素为单位的起始偏移量。</param>
        /// <param name="size">要读取的数据大小（以字节为单位）。</param>
        /// <returns>提取的数据字节数组。</returns>
        /// <exception cref="Exception">读取位图数据时发生错误时抛出。</exception>
        private static byte[] Read(Bitmap bitmap, int offset, int size)
        {
            int bitCount = size * 8; // 总共要读取的位数
            int pixelCount = (int)Math.Ceiling(bitCount / 3.0); // 每个像素提供3个位
            var height = bitmap.Height;
            var width = bitmap.Width;
            var capacity = height * width;
            if (offset + pixelCount > capacity)
            {
                throw new DataTooLargeException("数据过大");
            }

            byte[] data = new byte[size];
            int bitIndex = 0;

            for (int i = offset; i < offset + pixelCount; i++)
            {
                var x = i % width;
                var y = i / width;
                Color color = bitmap.GetPixel(x, y);

                // 从每个颜色通道中提取最低有效位
                byte[] rgb = { color.R, color.G, color.B };
                for (int j = 0; j < 3 && bitIndex < bitCount; j++)
                {
                    int byteIndex = bitIndex / 8;
                    int bitPosition = bitIndex % 8;
                    byte bit = (byte)((rgb[j] & 1) << bitPosition);
                    data[byteIndex] |= bit;
                    bitIndex++;
                }
            }
            return data;
        }

        /// <summary>
        /// 从指定偏移量开始将数据写入位图图像。
        /// </summary>
        /// <param name="bitmap">要写入的位图图像。</param>
        /// <param name="offset">以像素为单位的起始偏移量。</param>
        /// <param name="data">要写入的字节数组数据。</param>
        /// <exception cref="Exception">写入位图数据时发生错误时抛出。</exception>
        private static void Write(Bitmap bitmap, int offset, byte[] data)
        {
            int bitCount = data.Length * 8; // 总共要写入的位数
            int pixelCount = (int)Math.Ceiling(bitCount / 3.0); // 每个像素提供3个位
            var height = bitmap.Height;
            var width = bitmap.Width;
            if (offset + pixelCount > height * width)
            {
                throw new FileTooLargeException("数据过大");
            }

            int bitIndex = 0;

            for (int i = offset; i < offset + pixelCount; i++)
            {
                var x = i % width;
                var y = i / width;
                Color color = bitmap.GetPixel(x, y);

                // 修改每个颜色通道的最低有效位
                byte[] rgb = { color.R, color.G, color.B };
                for (int j = 0; j < 3 && bitIndex < bitCount; j++)
                {
                    int byteIndex = bitIndex / 8;
                    int bitPosition = bitIndex % 8;
                    byte bit = (byte)((data[byteIndex] >> bitPosition) & 1);

                    // 设置颜色通道的最低有效位
                    rgb[j] = (byte)((rgb[j] & ~1) | bit);
                    bitIndex++;
                }

                // 使用修改后的RGB值更新像素
                bitmap.SetPixel(x, y, Color.FromArgb(rgb[0], rgb[1], rgb[2]));
            }
        }

        /// <summary>
        /// 使用指定的密码将数据编码到位图图像中。
        /// </summary>
        /// <param name="bitmap">要编码数据的位图图像。</param>
        /// <param name="data">要编码的字节数组数据。</param>
        /// <param name="password">用于加密的密码。</param>
        /// <exception cref="Exception">将数据编码到位图时发生错误时抛出。</exception>
        public static void Encode(Bitmap bitmap, byte[] data, string password)
        {
            // 数据预处理：压缩，加密，添加 消息头
            // 1. 压缩
            var compressedData = CompressData(data);
            // todo show size in the UI
            // 2. 加密
            var encryptedData = EncryptData(compressedData, password);
            // todo show size in the UI
            // 3. 添加消息头
            var finaldata = WriteHeaderInfo(encryptedData);
            // todo show size in the UI
            Write(bitmap, 0, finaldata);
        }

        /// <summary>
        /// 获取位图图像中编码数据的大小。
        /// </summary>
        /// <param name="bitmap">要检查的位图图像。</param>
        /// <returns>编码数据的大小（以字节为单位）。</returns>
        public static int GetEncodedDataSize(Bitmap bitmap)
        {
            try
            {
                var header = Read(bitmap, 0, HEADER_SIZE);
                using (MemoryStream headerStream = new MemoryStream(header))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    var info = (Info)formatter.Deserialize(headerStream);
                    return info.size;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static byte[] Decode(Bitmap bitmap, string password)
        {
            var datasize = GetEncodedDataSize(bitmap);
            if (datasize == 0)
            {
                throw new DataNotFoundException("没有找到隐藏的数据");
            }
            var offset = (int)Math.Ceiling(HEADER_SIZE * 8 / 3.0);
            var encryptedDataWithSalt = Read(bitmap, offset, datasize);
            var decryptedData = DecryptData(encryptedDataWithSalt, password);
            var decompressedData = DecompressData(decryptedData);
            return decompressedData;
        }
    }

    // Custom Exception for LSB
    public class FileTooLargeException : Exception
    {
        public FileTooLargeException(string message) : base(message)
        {
        }
    }

    public class DataTooLargeException : Exception
    {
        public DataTooLargeException(string message) : base(message)
        {
        }
    }

    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string message) : base(message)
        {
        }
    }


}
