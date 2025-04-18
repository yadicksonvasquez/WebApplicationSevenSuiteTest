﻿using NLog;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WebApplicationSevenSuiteTest.util
{
    /// <summary>
    /// Clase para encriptar y desencriptar utilizando Rfc
    /// </summary>
    public class CryptographyUtil
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();


        public static string EncryptPassword(String password)
        {
            try
            {
                string encryptionKey = "sevensuiteTest1";
                byte[] clearBytes = Encoding.Unicode.GetBytes(password);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        password = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return password;
        }


        public static string DecryptPassword(String cipherPassword)
        {
            try
            {
                string encryptionKey = "sevensuiteTest1";
                byte[] clearBytes = Convert.FromBase64String(cipherPassword);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        cipherPassword = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return cipherPassword;
        }
    }
}