using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Extensions
{
    public class StringExtensions
    {
        public static string Base64Decode(string base64Encoded)
        {
            if (string.IsNullOrEmpty(base64Encoded))
                return string.Empty;

            byte[] data = Convert.FromBase64String(base64Encoded);

            return Encoding.ASCII.GetString(data);
        }
    }
}
