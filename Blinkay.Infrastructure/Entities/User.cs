using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Blinkay.Infrastructure.Entities
{
    public class User
    {
        public User()
        {
            this.userinfo = this.CreateRandomString(100);
        }
        /// <summary>
        /// user table primary key.
        /// </summary>
        [JsonProperty("iduser")]
        [Key]
        public virtual int iduser { get; set; }

        /// <summary>
        /// User table information string/Json.
        /// </summary>
        [JsonProperty("userinfo")]
        public virtual string userinfo { get; set; }

        /// <summary>
        /// Method that creates/generated a new random string for user info DB column.
        /// </summary>
        /// <param name="length"></param>
        /// <returns>Random string.</returns>
        private string CreateRandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
