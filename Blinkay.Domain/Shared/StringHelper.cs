using System;
using System.Linq;

namespace Blinkay.Domain.Shared
{
    public static class StringHelper
    {

        /// <summary>
        /// Method that creates/generated a new random string for user info DB column.
        /// </summary>
        /// <param name="length"></param>
        /// <returns>Random string.</returns>
        public static string CreateRandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
