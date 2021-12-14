using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blinkay.API.DTOs
{
    public class SelectPlusUpdateRequest
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
