using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCCQ.Util
{
    public static class Key
    {
        public static string Base64String(string str)
        {
            Byte[] bye = Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(bye);
        }

        public static string FromBase64String(string srt)
        {
            Byte[] Bye = Convert.FromBase64String(srt);
            return Encoding.UTF8.GetString(Bye);
        }
    }
}
