/*
 * copyright reserved
 * https://www.github.com/bian-sh
 * MIT license
 */

using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;
namespace Steganography
{
    public static class DataProcessHandler
    {
        public static byte[] CompressData(byte[] datas)
        {
            using (var compressedStream = new MemoryStream())
            {
                using (var gzip = new GZipStream(compressedStream, CompressionMode.Compress))
                {
                    gzip.Write(datas, 0, datas.Length);
                }
                return compressedStream.ToArray();
            }
        }
        public static byte[] DecompressData(byte[] compressedData)
        {
            using (var compressedStream = new MemoryStream(compressedData))
            {
                using (var decompressedStream = new MemoryStream())
                {
                    using (var gzip = new GZipStream(compressedStream, CompressionMode.Decompress))
                    {
                        gzip.CopyTo(decompressedStream);
                    }
                    return decompressedStream.ToArray();
                }
            }
        }

        public static byte[] EncryptData(byte[] compressedData, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return compressedData;
            }

            using (var encryptedStream = new MemoryStream())
            {
                byte[] salt = new byte[16];
                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(salt);
                }

                var pdb = new Rfc2898DeriveBytes(password, salt, 1000);
                var key = pdb.GetBytes(32);
                var iv = pdb.GetBytes(16);

                using (var aes = new AesManaged())
                {
                    aes.Key = key;
                    aes.IV = iv;
                    aes.Padding = PaddingMode.PKCS7;

                    using (var encryptor = aes.CreateEncryptor())
                    {
                        using (var cs = new CryptoStream(encryptedStream, encryptor, CryptoStreamMode.Write))
                        {
                            cs.Write(compressedData, 0, compressedData.Length);
                        }
                    }
                }

                byte[] encryptedData = encryptedStream.ToArray();
                byte[] result = new byte[salt.Length + encryptedData.Length];
                Buffer.BlockCopy(salt, 0, result, 0, salt.Length);
                Buffer.BlockCopy(encryptedData, 0, result, salt.Length, encryptedData.Length);
                return result;
            }
        }
        public static byte[] DecryptData(byte[] encryptedDataWithSalt, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return encryptedDataWithSalt;
            }

            byte[] salt = new byte[16];
            Buffer.BlockCopy(encryptedDataWithSalt, 0, salt, 0, salt.Length);

            byte[] encryptedData = new byte[encryptedDataWithSalt.Length - salt.Length];
            Buffer.BlockCopy(encryptedDataWithSalt, salt.Length, encryptedData, 0, encryptedData.Length);

            var pdb = new Rfc2898DeriveBytes(password, salt, 1000);
            var key = pdb.GetBytes(32);
            var iv = pdb.GetBytes(16);

            using (var aes = new AesManaged())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Padding = PaddingMode.PKCS7;

                using (var decryptedStream = new MemoryStream())
                {
                    using (var decryptor = aes.CreateDecryptor())
                    {
                        using (var cs = new CryptoStream(decryptedStream, decryptor, CryptoStreamMode.Write))
                        {
                            cs.Write(encryptedData, 0, encryptedData.Length);
                        }
                    }
                    return decryptedStream.ToArray();
                }
            }
        }

        public static byte[] WriteHeaderInfo(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Info info = new Info { size = data.Length };
                formatter.Serialize(ms, info);
                byte[] header = ms.ToArray();
                byte[] result = new byte[header.Length + data.Length];
                Buffer.BlockCopy(header, 0, result, 0, header.Length);
                Buffer.BlockCopy(data, 0, result, header.Length, data.Length);
                return result;
            }
        }
    }
}