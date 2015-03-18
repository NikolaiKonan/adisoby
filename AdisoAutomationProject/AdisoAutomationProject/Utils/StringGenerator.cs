using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdisoAutomationProject.Utils
{
    public static class StringGenerator
    {
        public static string GetRandomString(int length)
        {
            string chars = "abcdefghijklmnopqrstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            string result = new string(
                Enumerable.Repeat(chars, length)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}
