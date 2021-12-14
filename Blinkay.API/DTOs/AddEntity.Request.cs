
namespace Blinkay.API.DTOs
{
    public class AddEntityrequest
    {
        /// <summary>
        /// Number of registers to be added into DB repository.
        /// </summary>
        public int NumRegistres { get; set; }

        /// <summary>
        /// The number of threads to be created.
        /// </summary>
        public int NumThreads { get; set; }
    }
}
