using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blinkay.API.DTOs
{
    public class SelectPlusUpdatePlusInsertionResponse
    {
        /// <summary>
        /// Variable that containd the total time in seconds that a given thread least in executing a given number of record iterations.
        /// </summary>
        public long TimeOfExecution { get; set; }
    }
}
