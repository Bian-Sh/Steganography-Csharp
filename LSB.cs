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
    /// �ṩʹ�������Чλ��LSB����д����������ͽ������ݵķ�����
    /// </summary>
    public static class LSB
    {
        const int HEADER_SIZE = 135;
        /// <summary>
        /// ��λͼͼ���ж�ȡ��ָ��ƫ������ʼ�����ݡ�
        /// </summary>
        /// <param name="bitmap">Ҫ��ȡ��λͼͼ��</param>
        /// <param name="offset">������Ϊ��λ����ʼƫ������</param>
        /// <param name="size">Ҫ��ȡ�����ݴ�С�����ֽ�Ϊ��λ����</param>
        /// <returns>��ȡ�������ֽ����顣</returns>
        /// <exception cref="Exception">��ȡλͼ����ʱ��������ʱ�׳���</exception>
        private static byte[] Read(Bitmap bitmap, int offset, int size)
        {
            int bitCount = size * 8; // �ܹ�Ҫ��ȡ��λ��
            int pixelCount = (int)Math.Ceiling(bitCount / 3.0); // ÿ�������ṩ3��λ
            var height = bitmap.Height;
            var width = bitmap.Width;
            var capacity = height * width;
            if (offset + pixelCount > capacity)
            {
                throw new DataTooLargeException("���ݹ���");
            }

            byte[] data = new byte[size];
            int bitIndex = 0;

            for (int i = offset; i < offset + pixelCount; i++)
            {
                var x = i % width;
                var y = i / width;
                Color color = bitmap.GetPixel(x, y);

                // ��ÿ����ɫͨ������ȡ�����Чλ
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
        /// ��ָ��ƫ������ʼ������д��λͼͼ��
        /// </summary>
        /// <param name="bitmap">Ҫд���λͼͼ��</param>
        /// <param name="offset">������Ϊ��λ����ʼƫ������</param>
        /// <param name="data">Ҫд����ֽ��������ݡ�</param>
        /// <exception cref="Exception">д��λͼ����ʱ��������ʱ�׳���</exception>
        private static void Write(Bitmap bitmap, int offset, byte[] data)
        {
            int bitCount = data.Length * 8; // �ܹ�Ҫд���λ��
            int pixelCount = (int)Math.Ceiling(bitCount / 3.0); // ÿ�������ṩ3��λ
            var height = bitmap.Height;
            var width = bitmap.Width;
            if (offset + pixelCount > height * width)
            {
                throw new FileTooLargeException("���ݹ���");
            }

            int bitIndex = 0;

            for (int i = offset; i < offset + pixelCount; i++)
            {
                var x = i % width;
                var y = i / width;
                Color color = bitmap.GetPixel(x, y);

                // �޸�ÿ����ɫͨ���������Чλ
                byte[] rgb = { color.R, color.G, color.B };
                for (int j = 0; j < 3 && bitIndex < bitCount; j++)
                {
                    int byteIndex = bitIndex / 8;
                    int bitPosition = bitIndex % 8;
                    byte bit = (byte)((data[byteIndex] >> bitPosition) & 1);

                    // ������ɫͨ���������Чλ
                    rgb[j] = (byte)((rgb[j] & ~1) | bit);
                    bitIndex++;
                }

                // ʹ���޸ĺ��RGBֵ��������
                bitmap.SetPixel(x, y, Color.FromArgb(rgb[0], rgb[1], rgb[2]));
            }
        }

        /// <summary>
        /// ʹ��ָ�������뽫���ݱ��뵽λͼͼ���С�
        /// </summary>
        /// <param name="bitmap">Ҫ�������ݵ�λͼͼ��</param>
        /// <param name="data">Ҫ������ֽ��������ݡ�</param>
        /// <param name="password">���ڼ��ܵ����롣</param>
        /// <exception cref="Exception">�����ݱ��뵽λͼʱ��������ʱ�׳���</exception>
        public static void Encode(Bitmap bitmap, byte[] data, string password)
        {
            // ����Ԥ����ѹ�������ܣ���� ��Ϣͷ
            // 1. ѹ��
            var compressedData = CompressData(data);
            // todo show size in the UI
            // 2. ����
            var encryptedData = EncryptData(compressedData, password);
            // todo show size in the UI
            // 3. �����Ϣͷ
            var finaldata = WriteHeaderInfo(encryptedData);
            // todo show size in the UI
            Write(bitmap, 0, finaldata);
        }

        /// <summary>
        /// ��ȡλͼͼ���б������ݵĴ�С��
        /// </summary>
        /// <param name="bitmap">Ҫ����λͼͼ��</param>
        /// <returns>�������ݵĴ�С�����ֽ�Ϊ��λ����</returns>
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
                throw new DataNotFoundException("û���ҵ����ص�����");
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
