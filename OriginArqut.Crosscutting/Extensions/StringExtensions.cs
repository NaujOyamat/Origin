using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Crosscutting.Extensions
{
    /// <summary>
    /// Provee métodos de extensión para el tipo <see cref="String"/>
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Obtiene un Hash MD5 a partir de una cadena de texto
        /// </summary>
        /// <param name="str">Cadena de texto a convertir</param>
        /// <returns>Hash MD5 resultado</returns>
        public static string ToMD5(this string str)
        {
            string result = str;
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(str));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                result = sBuilder.ToString();
            }

            return result;
        }
    }
}
