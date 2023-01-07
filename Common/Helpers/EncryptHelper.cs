using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class EncryptHelper
    {
        private static string hash
        {
            get
            {
                return "b14ca5898a4e4133bbce2ea2315a1916";
            }
        }

        public static string Encriptar(string clave)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(hash);
                aes.IV = new byte[16];

                ICryptoTransform encriptador = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(ms, encriptador, CryptoStreamMode.Write))
                    {
                        using (var sw = new StreamWriter(cryptoStream))
                        {
                            sw.Write(clave);
                        }
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }

        }

        public static string Desencriptar(string clave)
        {
            byte[] claveBytes = Convert.FromBase64String(clave);
            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(hash);
                aes.IV = new byte[16];

                ICryptoTransform desencriptador = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream(claveBytes))
                {
                    using (var cryptoStream = new CryptoStream(ms, desencriptador, CryptoStreamMode.Read))
                    {
                        using (var sw = new StreamReader(cryptoStream))
                        {
                            return sw.ReadToEnd();
                        }
                    }
                }
            }

        }
    }
}

