using System;
using System.IO;
using System.Security.Cryptography;

namespace Google_Sync.src
{
    /// <summary>
    /// Encrypten und Decrypten von Strings
    /// </summary>
    public class Encryption
    {
        /// <summary>
        /// Encryptet den String
        /// </summary>
        /// <param name="clearText">Der Clear Text</param>
        /// <param name="Key">Der Verschlüsselungskey</param>
        /// <param name="IV">IV</param>
        /// <returns></returns>
        private static byte[] EncryptString(byte[] clearText, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;

            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearText, 0, clearText.Length);
            cs.Close();
            byte[] encryptedData = ms.ToArray();
            return encryptedData;
        }

        /// <summary>
        /// Encrypted den String
        /// </summary>
        /// <param name="clearText">Der Clear Text</param>
        /// <param name="Password">Das Passwort</param>
        /// <returns>Den Encrypteten String</returns>
        public static string EncryptString(string clearText, string Password)
        {
            byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            byte[] encryptedData = EncryptString(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return Convert.ToBase64String(encryptedData);
        }

        /// <summary>
        /// Decryptation des Strings
        /// </summary>
        /// <param name="cipherData">Der Verschlüsselte Text</param>
        /// <param name="Key">Der Key</param>
        /// <param name="IV">IV</param>
        /// <returns></returns>
        private static byte[] DecryptString(byte[] cipherData, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(cipherData, 0, cipherData.Length);
            cs.Close();
            byte[] decryptedData = ms.ToArray();
            return decryptedData;
        }

        /// <summary>
        /// Decryptation des Strings.
        /// </summary>
        /// <param name="cipherText">Der Verschlüsselte Text</param>
        /// <param name="Password">Das Passwort.</param>
        /// <returns></returns>
        public static string DecryptString(string cipherText, string Password)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            byte[] decryptedData = DecryptString(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return System.Text.Encoding.Unicode.GetString(decryptedData);
        }
    }
}
