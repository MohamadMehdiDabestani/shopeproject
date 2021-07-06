using System;
using System.Linq;

namespace Core
{
    public class RandowString
    {
        private static Random random = new Random();
        public static string GetString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}