using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace demo1.Common
{
    public class Utils
    {
        #region MD5加密
        /// <summary>
        /// MD5加密。
        /// </summary>
        public static string MD5(string Str)
        {
            byte[] m_b = Encoding.Default.GetBytes(Str);
            m_b = new MD5CryptoServiceProvider().ComputeHash(m_b);
            string m_r = "";
            for (int m_i = 0; m_i < m_b.Length; m_i++)
                m_r += m_b[m_i].ToString("x").PadLeft(2, '0');
            return m_r;
        }
        #endregion
    }
}