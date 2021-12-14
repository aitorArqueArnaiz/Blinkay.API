using Newtonsoft.Json;

namespace Blinkay.Infrastructure.Entities
{
    public class User
    {
        /// <summary>
        /// user table primary key.
        /// </summary>
        [JsonProperty("Id")]
        public virtual int Id { get; set; }

        /// <summary>
        /// User table information string/Json.
        /// </summary>
        [JsonProperty("Info")]
        public virtual string Info { get; set; }
    }
}
